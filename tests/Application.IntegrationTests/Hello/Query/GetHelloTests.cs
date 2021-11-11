using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task GetHelloEmptyShouldReturnDefault()
        {
            var query = new GetHelloQuery();

            // FluentActions.Invoking(() =>
            //     SendAsync(query)
            //     )
            //     .Should().;

            var response = await SendAsync(query);
            response.Should().Equals("Hello, World!");
        }
    }
}