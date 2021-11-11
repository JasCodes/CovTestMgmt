using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovTestMgmt.Application.IntegrationTests;
using NUnit.Framework;

namespace CovTestMgnt.Application.IntegrationTests
{
    using static Testing;
    public class TestBase
    {
        [SetUp]
        public async Task TestSetUp()
        {

            await ResetState();
        }
    }
}