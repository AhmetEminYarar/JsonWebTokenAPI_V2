using JsonWebToken.Dto;
using JsonWebToken.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JsonWebToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public PersonController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet(Name = "GetPerson"),Authorize(Roles ="Admin")]
        public async Task<IActionResult> Get()
        {
            return Ok(new PersonGetResponse().Map(await _appDbContext.People.ToListAsync<Person>()));
        }
        [HttpPost(Name = "AddPerson"),Authorize(Roles ="Admin")]
        public async Task<IActionResult> Add([FromForm] PersonAddRequest request)
        {           
            Person person = request.Map(request);
            await _appDbContext.People.AddAsync(person);
            await _appDbContext.SaveChangesAsync();
            return Ok(new { id = person.Id });          

        }
    }
}
