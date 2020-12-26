using System.Threading.Tasks;
using FiguresApi.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FiguresApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FigureController : ControllerBase
    {
        public FigureController()
        {
            
        }

        [HttpPost]
        public async Task<ActionResult> PostFigure(Figure figure)
        {
            return CreatedAtAction(nameof(GetFigure), new {id = 1000}, figure);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Figure>> GetFigure(long id)
        {
            return new Figure();
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Figure>>> GetFigures()
        //{

        //}
    }
}