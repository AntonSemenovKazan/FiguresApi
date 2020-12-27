using System;
using FiguresApi.Domain;
using FiguresApi.Tests.Helpers;
using FiguresApi.Validators;
using NUnit.Framework;
using Coordinates = FiguresApi.Domain.Coordinates;
using Figure = FiguresApi.Contracts.Figure;

namespace FiguresApi.Tests
{
    public class FiguresTests
    {
        [TestCase(0)]
        [TestCase(5)]
        public void CircleSquareTest(double radius)
        {
            var expectedRadius = Math.PI * radius * radius / 2;
            var circle = new Circle(new Coordinates(0, 0), radius);

            Assert.AreEqual(expectedRadius, circle.GetSquare());
        }

        [Test]
        public void TriangleSquareTest()
        {
            var coordinates = new[]
            {
                new Coordinates(0, 0),
                new Coordinates(5, 0),
                new Coordinates(0, 5)
            };

            var triangle = new Triangle(coordinates);

            const double expectedSquare = 12.5;
            Assert.AreEqual(expectedSquare, triangle.GetSquare());
        }

        [TestCase(FigureType.Circle, 0, false)]
        [TestCase(FigureType.Circle, 1, false)]
        [TestCase(FigureType.Circle, 2, true)]
        [TestCase(FigureType.Circle, 3, false)]
        [TestCase(FigureType.Triangle, 2, false)]
        [TestCase(FigureType.Triangle, 3, true)]
        [TestCase("unknownFigureType", 3, false)]
        public void FigureValidatorTest(string figureType, int coordinatesNumber, bool expectedIsValid)
        {
            var figure = new Figure()
            {
                Type = figureType,
                Coordinates = Generator.GenerateCoordinates(coordinatesNumber)
            };

            Assert.AreEqual(expectedIsValid, FigureValidator.IsValid(figure));
        }

        [TestCase(FigureType.Circle, typeof(Circle))]
        [TestCase(FigureType.Triangle, typeof(Triangle))]
        public void FigureFactoryTest(string figureType, Type expectedType)
        {
            var mapper = AutoMapperHelper.GetMapper();
            var figureFactory = Generator.GenerateFigureFactory();

            var dtoFigure = Generator.GenerateFigure(figureType);
            var dbFigure = mapper.Map<Db.Figure>(dtoFigure);
            var domainFigure = figureFactory.CreateFrom(dbFigure);

            Assert.AreEqual(expectedType, domainFigure.GetType());
        }
    }
}