using Microsoft.AspNetCore.Mvc;
using PoprawaKol2.Services;
using System;
using System.Threading.Tasks;

namespace PoprawaKol2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public TeamsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {
            try
            {
                return Ok(await _dbService.GetTeam(id));
            } catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
