using Microsoft.AspNetCore.Mvc;
using KL.Repository;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using KL.Domain;

namespace KL.WebAPI.Controllers
{
    [ApiController]
    [Route("api/customers")]   
    public class CustomersController : ControllerBase
    {
        //Dependency Injected in the Startup.cs
        public IKLRepository _repo { get; }
        
        public CustomersController(IKLRepository repo)
        {
            _repo = repo;

        }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var results = await _repo.GetAllCustomers(true);

            return Ok(results);
        }
        catch (System.Exception)
        {            
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Ops! Algo ocorreu errado!");
        }
    }

    [HttpGet ("{CustomersId}")]
    public async Task<IActionResult> Get(int CustomersId)
    {
        try
        {
            var results = await _repo.GetClientById(CustomersId, true);

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
            var results = await _repo.GetAllCustomersByName(name, true);

            return Ok(results);
        }
        catch (System.Exception)
        {            
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Ops! Algo ocorreu errado!");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Customers model)
    {
        try
        {
            _repo.Add(model);

            if (await _repo.SaveChangesAsync())
            {
                //If saved call rote getbyId using template string
                return Created($"/api/customers/{model.Id}", model);
            }
        }
        catch (System.Exception ex)
        {     
            var temp = ex.Message;       
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Ops! Algo ocorreu errado!");
        }
        //If no Exception and no Saved
        return BadRequest();
    }  

    [HttpPut ("{Id}")]
    public async Task<IActionResult> Put(int Id, Customers model)
    {
        try
        {
            //Get Client no joins (Without relationship tables)
            var client = await _repo.GetClientById(Id, false);

            if (client == null) return NotFound(); 

            _repo.Update(model);

            if (await _repo.SaveChangesAsync())
            {
                //If saved call rote getbyId using template string
                return Created($"/api/customers/{model.Id}", model);
            }
        }
        catch (System.Exception)
        {            
            return this.StatusCode(StatusCodes.Status500InternalServerError, "Ops! Algo ocorreu errado!");
        }
        //If no Exception and no Saved
        return BadRequest();
    }

     [HttpDelete ("{Id}")]
    public async Task<IActionResult> Delete(int Id)
    {
        try
        {
            //Get Client no joins (Without relationship tables)
            var client = await _repo.GetClientById(Id, false);

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