using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CovTestMgmt.Domain.Entities
{
    // public class ApplicationResponse
    // {
    //     public HttpStatusCode StatusCode { get; init; } = HttpStatusCode.OK;
    //     public string ErrorMessage { get; init; }
    // }
    public interface IHttpResponse
    {
        public HttpStatusCode StatusCode { get; init; }
        public List<string> Errors { get; init; }
    }


    public class HttpResponse<T> : IHttpResponse
    {
        public HttpStatusCode StatusCode { get; init; } = HttpStatusCode.OK;
        public List<string> Errors { get; init; }
        public T Data { get; init; }
    }

}