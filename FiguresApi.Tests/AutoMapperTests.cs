using FiguresApi.Tests.Helpers;
using NUnit.Framework;

namespace FiguresApi.Tests
{
    public class AutoMapperTests
    {
        [Test]
        public void AutoMapperConfigTest()
        {
            var config = AutoMapperHelper.GetConfig();

            config.AssertConfigurationIsValid();
        }
    }
}