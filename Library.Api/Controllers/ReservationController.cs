using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IEnumerable<ReservationDto>> GetAll()
        {
            var reservations = await _reservationService.GetAllAsync();
            return reservations.Select(r => new ReservationDto
            {
                Id = r.Id,
                BookId = r.BookId,
                UserId = r.UserId,
                Until = r.Until
            });
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetById(int id)
        {
            var reservation = await _reservationService.GetByIdAsync(id);
            if (reservation == null) return NotFound();
            return Ok(reservation);
        }

        /*[HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateReservationDto dto)
        {
            var reservation = await _reservationService.CreateAsync(
                dto.BookId,
                dto.UserId,
                dto.Until
            );

            return CreatedAtAction(nameof(GetById), new { id = reservation.Id }, reservation);
        }*/


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateReservationDto dto)
        {
            // Виклик сервісу, який створює бронювання та публікує подію
            var reservation = await _reservationService.CreateAsync(dto.BookId, dto.UserId, dto.Until);

            // --- Рішення №1: повертаємо простий обʼєкт без циклічних навігацій ---
            return Ok(new
            {
                Message = "Reservation created successfully",
                ReservationId = reservation.Id
            });
        }


    }
}
