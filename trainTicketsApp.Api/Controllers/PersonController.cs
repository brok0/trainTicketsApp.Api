using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTickets.BusinessLogic.Abstractions;
using TrainTickets.Domain.Models;
using trainTicketsApp.Api.DTO;
using System.Security.Principal;


namespace trainTicketsApp.Api.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _service;
        private readonly IMapper _mapper;

        public PersonController(IPersonService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        //[Authorize]
        //[Route("/allusers")]
        public IActionResult AllUsers() { return Ok($"{User.Identity.Name}"); }
       
        //[HttpGet]
        public async Task<IActionResult> GetAllPersonsAsync()
        {
            var persons = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<PersonReadDto>>(persons));
        }
        //[HttpGet("{id:int}")]

        public async Task<IActionResult> GetPersonById(int id)
        {
            var person = await _service.GetPersonAsync(id);
            return Ok(_mapper.Map<PersonReadDto>(person));

        }
       // [HttpPost]
        public async Task<IActionResult> CreatePerson(PersonCreateDto person)
        {
            var newPerson = await _service.CreateNewAsync(_mapper.Map<Person>(person));
            return Ok(_mapper.Map<PersonReadDto>(newPerson));

        }
       /// [HttpDelete("{id:int}")]

        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var PersonToDelete = await _service.GetPersonAsync(id);
            if (PersonToDelete == null) return NotFound();

            await _service.DeleteAsync(PersonToDelete);
            return NoContent();
        }

        //[HttpGet("{login}")]
        public async Task <IActionResult> GetPersonByName(string login)
        {
            var password= await _service.GetByLoginAsync(login);
            if (password == null) return NotFound();
            return Ok();
        }
    }
}
