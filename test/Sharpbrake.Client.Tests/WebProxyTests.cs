﻿#if NETCOREAPP2_0
using System;
using Xunit;

namespace Sharpbrake.Client.Tests
{
    /// <summary>
    /// Unit tests for the <see cref="WebProxy"/> class.
    /// </summary>
    public class WebProxyTests
    {
        [Fact]
        public void Ctor_ShouldThrowExceptionIfUriParamIsEmpty()
        {
            var exception = Record.Exception(() => new WebProxy(null, true));

            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
            Assert.Equal("uri", ((ArgumentNullException)exception).ParamName);
        }

        [Fact]
        public void GetProxy_ShouldReturnValuePassedToCtor()
        {
            var uri = new Uri("http://proxy-example.com:9090");

            var proxy = new WebProxy(uri, true);

            Assert.True(proxy.GetProxy(new Uri("https://airbrake.io/")) == uri);
        }

        [Theory,
         InlineData(true),
         InlineData(false)]
        public void IsBypassed_ShouldReturnValuePassedToCtor(bool bypassOnLocal)
        {
            var uri = new Uri("http://proxy-example.com:9090");

            var proxy = new WebProxy(uri, bypassOnLocal);

            Assert.True(proxy.IsBypassed(new Uri("https://airbrake.io/")) == bypassOnLocal);
        }
    }
}
#endif
