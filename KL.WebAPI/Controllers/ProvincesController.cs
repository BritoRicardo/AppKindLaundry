using System.Threading.Tasks;
using KL.Domain;
using KL.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KL.WebAPI.Controllers
{
    [ApiController]
    [Route("api/provinces")]   
    public class ProvincesController : ControllerBase
    {
        public IKLRepository _repo { get; }

        public ProvincesController(IKLRepository repo)
        {
             _repo = repo;
        }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var results = await _repo.GetAllProvinces();

            return Ok(results);
        }
        catch (System.Exception)
        {            
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Ops! Error loading province list!");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Provinces model)
    {
        try
        {
            _repo.Add(model);

            if (await _repo.SaveChangesAsync())
            {
                //If saved call rote getbyId using template string
                return Created($"/api/provinces/{model.Id}", model);
            }
        }
        catch (System.Exception)
        {            
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Ops! Error inserting province!");
        }
        //If no Exception and no Saved
        return BadRequest();
    }  
  }
}