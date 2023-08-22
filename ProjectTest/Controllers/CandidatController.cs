using ProjectTest.Data;
using ProjectTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTest.Services.UserService;

namespace WeCount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatController : ControllerBase
    {
        private readonly DatabaseContext _registerContext;
        public CandidatController(DatabaseContext talentApp_MasterDbContext)
        {
            _registerContext = talentApp_MasterDbContext;
        }

        [HttpGet]
        [Route("/api/get")]
        public async Task<ActionResult<List<Candidat>>> GetAllCandidate()
        {
            try
            {
                var candidates = await _registerContext.Candidats
                    .ToListAsync();

                return Ok(candidates);
            }
            catch (Exception ex)
            {
                // Handle any exceptions or log errors
                return StatusCode(500, "An error occurred while retrieving the candidates.");
            }
        }

        [HttpPost("/api/registerC")]
        public async Task<IActionResult> RegisterCandidate([FromBody] Candidat candidatObj)
        {
            if (candidatObj == null)
                return BadRequest();
            
            

            await _registerContext.Candidats.AddAsync(candidatObj);
            await _registerContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "Candidate Registered!"
            });
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Candidat>>> DeleteCandidate(int id)
        {
            var dbCandidate = await _registerContext.Candidats.FindAsync(id);
            if (dbCandidate == null)
                return BadRequest("Candidate not found");

            _registerContext.Candidats.Remove(dbCandidate);
            await _registerContext.SaveChangesAsync();
            return Ok(await _registerContext.Candidats.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Candidat>>> GetCandidate(int id)
        {
            var dbCandidate = await _registerContext.Candidats.FindAsync(id);
            if (dbCandidate == null)
                return BadRequest("Candidate not found");

            return Ok(dbCandidate);
        }
    }
}
