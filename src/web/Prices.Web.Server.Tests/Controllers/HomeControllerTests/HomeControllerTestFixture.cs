﻿namespace Prices.Web.Server.Tests.Controllers.HomeControllerTests
{
    public class HomeControllerTestFixture
    {
        public HomeControllerTestBuilder Builder { get; }

        public HomeControllerTestFixture() 
            => Builder = new HomeControllerTestBuilder();
    }
}