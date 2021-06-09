using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KL.WebAPI.Data;
using KL.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KL.WebAPI.Controllers
{
    [ApiController]
    [Route("api/values")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public DataContext _context { get; }

        public WeatherForecastController(DataContext context)
        {
            this._context = context;            
        }
       // Aqui exige utilizar o context passado no contrutor injetado pela classe Startup.cs
       // IActionResult requer retorno "OK"
       [HttpGet("{id}")] 
       public IActionResult Get (int id)
       {
           try
           {
               var result = _context.Provinces.FirstOrDefault(x => x.Id == id);
               return Ok(result);
           }
           catch (System.Exception)
           {
               return this.StatusCode(StatusCodes.Status500InternalServerError, "Ops! Algo ocorreu errado!");
           }           
       }      

       // Aqui não necessita utilizar o context passado no contrutor. Basta utilizar a diretiva "FromServices"
       // Exemplo também de Chamada Assincrona
        [HttpGet] 
        [Route("getAll")]     
       public async Task<ActionResult<List<Provinces>>> Get([FromServices] DataContext _context)
       {
           var provinces = await _context.Provinces.ToListAsync();
           return provinces;
       } 
    }
}
