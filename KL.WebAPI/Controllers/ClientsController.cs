using Microsoft.AspNetCore.Mvc;
using KL.Repository;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using KL.Domain;

namespace KL.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]   
    public class ClientsController : ControllerBase
    {
        //Dependency Injected in the Startup.cs
        public IKLRepository _repo { get; }
        
        public ClientsController(IKLRepository repo)
        {
            _repo = repo;

        }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var results = await _repo.GetAllClients(true);

            return Ok(results);
        }
        catch (System.Exception)
        {            
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Ops! Algo ocorreu errado!");
        }
    }

    [HttpGet ("{ClientId}")]
    public async Task<IActionResult> Get(int ClientId)
    {
        try
        {
            var results = await _repo.GetClientById(ClientId, true);

            return Ok(results);
        }
        catch (System.Exception)
        {            
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Ops! Algo ocorreu errado!");
        }
    }

    [HttpGet ("getByName{name}")]
    public async Task<IActionResult> Get(string name)
    {
        try
        {
            var results = await _repo.GetAllClientsByName(name, true);

            return Ok(results);
        }
        catch (System.Exception)
        {            
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Ops! Algo ocorreu errado!");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Clients model)
    {
        try
        {
            _repo.Add(model);

            if (await _repo.SaveChangesAsync())
            {
                //If saved call rote getbyId
                return Created($"/api/client/{model.Id}", model);
            }
        }
        catch (System.Exception)
        {            
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Ops! Algo ocorreu errado!");
        }
        //If no Exception and no Saved
        return BadRequest();
    }  

    [HttpPut]
    public async Task<IActionResult> Put(int ClientId, Clients model)
    {
        try
        {
            //Get Client no joins (Without relationship tables)
            var client = await _repo.GetClientById(ClientId, false);

            if (client == null) return NotFound(); 

            _repo.Update(model);

            if (await _repo.SaveChangesAsync())
            {
                //If saved call rote getbyId
                return Created($"/api/client/{model.Id}", model);
            }
        }
        catch (System.Exception)
        {            
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Ops! Algo ocorreu errado!");
        }
        //If no Exception and no Saved
        return BadRequest();
    }

     [HttpDelete]
    public async Task<IActionResult> Delete(int ClientId)
    {
        try
        {
            //Get Client no joins (Without relationship tables)
            var client = await _repo.GetClientById(ClientId, false);

            if (client == null) return NotFound(); 

            _repo.Delete(client);

            if (await _repo.SaveChangesAsync())
            {             
                return Ok();
            }
        }
        catch (System.Exception)
        {            
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Ops! Algo ocorreu errado!");
        }
        //If no Exception and no Saved
        return BadRequest();
    }
  }  
}