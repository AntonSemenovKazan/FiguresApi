using FiguresApi.Controllers;
using FiguresApi.Db;
using FiguresApi.Domain;
using FiguresApi.Tests.Helpers;
using Moq;
using NUnit.Framework;
using System;

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

            var (figure, expectedSquare) = GetFigure(figureType);
            var figureId = controller.PostFigure(figure).Result;

            Assert.IsTrue(figureId.Value > 0);

            var square = controller.GetFigure(figureId.Value).Result;
            Assert.AreEqual(expectedSquare, square.Value);
        }

        private (Contracts.Figure figure, double expectedSquare) GetFigure(string figureType)
        {
            switch (figureType)
            {
                case FigureType.Circle:
                    var circle = new Contracts.Figure()
                    {
                        Type = FigureType.Circle,
                        Coordinates = new[] { new Contracts.Coordinates(10, 10), new Contracts.Coordinates(5, 10) }
                    };
                    return (circle, 39.269908169872416);
                case FigureType.Triangle:
                    var triangle = new Contracts.Figure()
                    {
                        Type = FigureType.Triangle,
                        Coordinates = new[] { new Contracts.Coordinates(0, 0), new Contracts.Coordinates(5, 0), new Contracts.Coordinates(0, 5) }
                    };
                    return (triangle, 12.5);
                default:
                    throw new ArgumentOutOfRangeException(figureType);
            }
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