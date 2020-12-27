using FiguresApi.Controllers;
using FiguresApi.Db;
using FiguresApi.Domain;
using FiguresApi.Tests.Helpers;
using Moq;
using NUnit.Framework;

namespace FiguresApi.Tests
{
    public class FigureControllerTests
    {
        [OneTimeSetUp]
        public void Setup()
        {
            using var figuresDbContext = CreateDbContext();
            figuresDbContext.Database.EnsureDeleted();
            figuresDbContext.Database.EnsureCreated();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            using var figuresDbContext = CreateDbContext();
            figuresDbContext.Database.EnsureDeleted();
        }

        [TestCase(FigureType.Circle)]
        [TestCase(FigureType.Triangle)]
        public void BaseControllerTest(string figureType)
        {
            var mapper = AutoMapperHelper.GetMapper();
            var figureFactory = Generator.GenerateFigureFactory();
            using var dbContext = CreateDbContext();

            var controller = new FigureController(mapper, dbContext, figureFactory);

            var figure = Generator.GenerateFigure(figureType);
            var figureId = controller.PostFigure(figure).Result;

            Assert.IsTrue(figureId.Value > 0);

            var square = controller.GetFigure(figureId.Value).Result;
            Assert.IsTrue(square.Value >= 0);
        }

        private FiguresDbContext CreateDbContext()
        {
            var settings = GetDbSettings();
            return new FiguresDbContext(settings);
        }

        private IDbSettings GetDbSettings()
        {
            var mock = new Mock<IDbSettings>();
            mock.Setup(x => x.ConnectionString).Returns("Data Source=test.db");

            return mock.Object;
        }

        

    }
}