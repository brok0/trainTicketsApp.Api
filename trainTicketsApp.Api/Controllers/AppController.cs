using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTickets.BusinessLogic.Abstractions;
using TrainTickets.Domain.Models;
using trainTicketsApp.Api.DTO;

namespace trainTicketsApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppController : ControllerBase
    {
        private readonly IAppService _service;
        private readonly IMapper _mapper;

        public AppController(IAppService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet("/tickets")]
        public async Task<IActionResult> GetAllTicketsAsync()
        {
            var tickets = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<TicketReadDto>>(tickets));
        }

       // [Authorize]
        [HttpGet("/ticket/findId")]
        public async Task <IActionResult> GetTicketById([FromQuery]int id)
        {
            var ticket = await _service.GetTicketAsync(id);
            return Ok(_mapper.Map<TicketReadDto>(ticket));

        }

        //[Authorize]
        [HttpPost]
        [Route("/ticket/new")]
        public async Task <IActionResult> CreateTicket(TicketCreateDto ticket)
        {
            var newTicket = await _service.CreateNewAsync(_mapper.Map<Ticket>(ticket));
            return Ok(_mapper.Map<TicketReadDto>(newTicket));

        }
        //[Authorize]
        [HttpDelete]
        [Route("/ticket/delete")]

        public async Task<IActionResult> DeleteAsync([FromQuery]int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var ticketToDelete = await _service.GetTicketAsync(id);
            if (ticketToDelete == null) return NotFound();

            await _service.DeleteAsync(ticketToDelete);
            return NoContent();
        }

        //[Authorize]
        [HttpPut]
        [Route("/ticket/update")]
        public async Task<IActionResult> UpdateTicket([FromQuery]int id,TicketUpdateDto newTicket)
        {
            var ticketToUpdate = await _service.GetTicketAsync(id);
            _mapper.Map(newTicket, ticketToUpdate);
            await _service.UpdateTicket(ticketToUpdate);
            return Ok();
        }
        [HttpGet]
        [Route("/ticket/search")]
        public async Task<IActionResult> GetTicketByQuery([FromQuery]string To,[FromQuery]string From)
        {
            var searchedTickets = await _service.GetTicketBySearchRequestAsync(To,From);
            return Ok(searchedTickets);
        }

        [HttpGet]
        [Route("/ticket/user")]
        public async Task<IActionResult> GetTicketsForUser([FromQuery]int userid)
        {
            var userTickets = await _service.GetTicketsForUser(userid);
            return Ok(userTickets);
        }

        [HttpPost]
        [Route("/ticket/user/add")]
        public async Task<IActionResult> UserAddsTicket([FromQuery]int ticketId,[FromQuery] int userid)
        {
             await _service.UserAddsTicket(ticketId,userid);
            return Ok();
        }


        [HttpGet]
        [Route("/ticket/cities")]
        public async Task<IActionResult> GetAllCities()
        {
            var listOfCities = await _service.GetAllCities();
            return Ok(listOfCities);
        }

        
    }
}
