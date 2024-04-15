using DotNet8Authentication.Data;
using DotNet8Authentication.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNet8Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly DataContextNews _context;

        public NewsController(DataContextNews context)
        {
            _context = context;
        }




        [HttpGet]
        public async Task<IActionResult> GetAllNews()
        {
            var noticias = await _context.News.ToListAsync();


            return Ok(new { news = noticias });
        }

        [HttpGet("{id}")]
        
        public async Task<ActionResult<News>> GetNews(int id)
        {
            var noticia = await _context.News.FindAsync(id);
            if(noticia is null)
            {
                return NotFound("Noticia não encontrada");
            }



            return Ok(noticia);
        }

        [Authorize]
        [HttpPost]
        
        public async Task<ActionResult<List<News>>> AddNews( News noticia)
        {
            
            _context.News.Add(noticia);
            await _context.SaveChangesAsync();


            return Ok(await _context.News.ToListAsync());
        }
    }
}
