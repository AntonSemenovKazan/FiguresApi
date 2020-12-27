using AutoMapper;
using FiguresApi.Db;
using FiguresApi.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using FiguresApi.Domain;
using Figure = FiguresApi.Contracts.Figure;

namespace FiguresApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FigureController : ControllerBase
    {
        private readonly IMapper mapper;

        private readonly FiguresDbContext dbContext;
        private readonly FigureFactory figureFactory;

        public FigureController(IMapper mapper, FiguresDbContext dbContext, FigureFactory figureFactory)
        {
            this.mapper = mapper;
            this.dbContext = dbContext;
            this.figureFactory = figureFactory;
        }

        [HttpPost]
        public async Task<ActionResult<int>> PostFigure(Figure figure)
        {
            if (!FigureValidator.IsValid(figure))
                return BadRequest();

            var dbFigure = mapper.Map<Db.Figure>(figure);

            dbContext.Add(dbFigure);

            await dbContext.SaveChangesAsync();

            return dbFigure.FigureId;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<double>> GetFigure(int id)
        {
            var dbFigure = await dbContext.Figures.
                Include(f => f.Coordinates).
                SingleOrDefaultAsync(f => f.FigureId == id);

            if (dbFigure == null)
            {
                return NotFound();
            }

            var figure = figureFactory.CreateFrom(dbFigure);
            return figure.GetSquare();
        }
    }
}