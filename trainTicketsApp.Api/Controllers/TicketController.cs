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
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _service;
        private readonly IMapper _mapper;

        public TicketController(ITicketService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet("/tickets/all")]
        public async Task<IActionResult> GetAllTicketsAsync()
        {
            var tickets = await _service.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<TicketReadDto>>(tickets));
        }

        [Authorize]
        [HttpGet("/ticket/findId")]
        public async Task <IActionResult> GetTicketById([FromQuery]int id)
        {
            var ticket = await _service.GetTicketAsync(id);
            return Ok(_mapper.Map<IEnumerable<TicketReadDto>>(ticket));

        }

        [Authorize]
        [HttpPost]
        [Route("/newTicket")]
        public async Task <IActionResult> CreateTicket(TicketCreateDto ticket)
        {
            var newTicket = await _service.CreateNewAsync(_mapper.Map<Ticket>(ticket));
            return Ok(_mapper.Map<TicketReadDto>(newTicket));

        }
        [Authorize]
        [HttpDelete("{id:int}")]

        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var ticketToDelete = await _service.GetTicketAsync(id);
            if (ticketToDelete == null) return NotFound();

            await _service.DeleteAsync(ticketToDelete);
            return NoContent();
        }

        [Authorize]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTicket(int id,TicketUpdateDto newTicket)
        {
            var ticketToUpdate = await _service.GetTicketAsync(id);
            _mapper.Map(newTicket, ticketToUpdate);
            await _service.UpdateTicket(ticketToUpdate);
            return Ok(_mapper.Map<TicketReadDto>(newTicket));
        }

    }
}
