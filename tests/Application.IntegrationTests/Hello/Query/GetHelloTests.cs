using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovTestMgmt.Application.Exceptions;
using CovTestMgmt.Application.Handlers;
using CovTestMgnt.Application.IntegrationTests;
using FluentAssertions;
using NUnit.Framework;

namespace CovTestMgmt.Application.IntegrationTests.Hello.Query
{
    using static Testing;
    public class GetHelloTests : TestBase
    {
        [Test]
        public async Task GetHelloEmptyShouldThrowValidationError()
        {
            var query = new GetHelloQuery();

            await FluentActions.Invoking(() =>
                SendAsync(query)).Should().ThrowAsync<ValidationException>();
        }

        [Test]
        public async Task GetHelloTest()
        {
            var query = new GetHelloQuery { Name = "Jas" };
            var response = await SendAsync(query);
            response.Message.Should().Be("Hello Jas");
        }
    }
}