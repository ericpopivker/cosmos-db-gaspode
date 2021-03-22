using System;
using NUnit.Framework;

using PandaTech.Infrastructure;
using PandaTech.Infrastructure.Helpers;

namespace CosmosDbGaspode.Core.Tests
{
    [SetUpFixture]
    public class SetUpFixture
    {
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var configuration = StartupHelper.SetupConfig(Env.Test);
            Config.Setup(configuration);

            StartupHelper.SetupLog(Config.LogDir, LogOutputType.Console | LogOutputType.File);

            Config.WriteEnvInfoToLog();
        }
    }
}
