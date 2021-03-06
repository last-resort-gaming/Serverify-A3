﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using A3ServerTool.Helpers.ServerLauncher;
using A3ServerTool.Models;

namespace ServerifyA3.Tests
{
    /// <summary>
    /// Provides tests for ServerLauncher class.
    /// </summary>
    public class ServerLauncherTests
    {
        [Fact]
        private void Run_ShouldThrowInvalidOperationException()
        {
            var serverStringBuilder = new Mock<IServerStringBuilder>();
            serverStringBuilder.SetupGet(x => x.FinalArgumentString)
                .Returns("-port=2302 -name=sampleProfile");
            var launcher = new ServerLauncher(serverStringBuilder.Object);
            Assert.Throws<InvalidOperationException>(() => launcher.Run(new Profile()));
        }
    }
}
