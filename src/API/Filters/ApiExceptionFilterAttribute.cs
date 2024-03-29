﻿using CovTestMgmt.Application.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

namespace CovTestMgmt.WebUI.Filters
{

    public static class ExceptionFilterExtensions
    {
        public static ProblemDetails AddDevDetails(this ProblemDetails problemDetails, ExceptionContext exceptionContext, IHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                problemDetails.Detail = exceptionContext.Exception.ToString();
                problemDetails.Extensions.Add("source", exceptionContext.Exception.Source);
                problemDetails.Extensions.Add("stackTrace", exceptionContext.Exception.StackTrace);
                problemDetails.Extensions.Add("helpLink", exceptionContext.Exception.HelpLink);
            }

            return problemDetails;
        }
    }
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {

        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;
        private readonly IHostEnvironment _iHostEnvironment;

        public ApiExceptionFilterAttribute(IHostEnvironment iHostEnvironment)
        {

            _iHostEnvironment = iHostEnvironment;
            // Register known exception types and handlers.
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), HandleValidationException },
                { typeof(NotFoundException), HandleNotFoundException },
                { typeof(UnauthorizedAccessException), HandleUnauthorizedAccessException },
                { typeof(ForbiddenAccessException), HandleForbiddenAccessException },
                { typeof(DbUpdateException), HandleDbUpdateException },
            };
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            if (!context.ModelState.IsValid)
            {
                HandleInvalidModelStateException(context);
                return;
            }

            HandleUnknownException(context);
        }

        private void HandleValidationException(ExceptionContext context)
        {
            var exception = context.Exception as ValidationException;

            var details = new ValidationProblemDetails(exception.Errors)
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
            };

            details.AddDevDetails(context, _iHostEnvironment);

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
        }

        private void HandleInvalidModelStateException(ExceptionContext context)
        {
            var details = new ValidationProblemDetails(context.ModelState)
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
            };
            details.AddDevDetails(context, _iHostEnvironment);

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as NotFoundException;

            var details = new ProblemDetails()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                Title = "The specified resource was not found.",
                Detail = exception.Message
            };


            if (_iHostEnvironment.IsDevelopment())
            {
                details.Detail = context.Exception.ToString();
                details.Extensions.Add("stackTrace", context.Exception.StackTrace);
            }
            details.AddDevDetails(context, _iHostEnvironment);

            context.Result = new NotFoundObjectResult(details);

            context.ExceptionHandled = true;
        }

        private void HandleUnauthorizedAccessException(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status401Unauthorized,
                Title = "Unauthorized",
                Type = "https://tools.ietf.org/html/rfc7235#section-3.1"
            };

            details.AddDevDetails(context, _iHostEnvironment);

            context.Result = new ObjectResult(details);
            context.ExceptionHandled = true;
        }

        private void HandleForbiddenAccessException(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status403Forbidden,
                Title = "Forbidden",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3"
            };
            details.AddDevDetails(context, _iHostEnvironment);
            context.Result = new ObjectResult(details);
            context.ExceptionHandled = true;
        }

        private void HandleDbUpdateException(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Database Update Error",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            };

            details.AddDevDetails(context, _iHostEnvironment);

            context.Result = new ObjectResult(details);
            context.ExceptionHandled = true;
        }


        private void HandleUnknownException(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An error occurred while processing your request.",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            };
            details.AddDevDetails(context, _iHostEnvironment);

            context.Result = new ObjectResult(details);
            context.ExceptionHandled = true;
        }
    }
}
