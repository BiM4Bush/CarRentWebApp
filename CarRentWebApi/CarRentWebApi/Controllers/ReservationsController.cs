using CarRentWebApi.Data;
using CarRentWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRentWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);

            if(reservation == null)
            {
                return NotFound();
            }

            return reservation;
        }

        [HttpPost]
        public async Task<ActionResult<Reservation>> CreateReservation (Reservation reservation)
        {
            var car = await _context.Cars.FindAsync(reservation.CarId);
            if(car == null)
            {
                return NotFound();
            }

            //Calculation total cost of reservation
            reservation.RentCost = (reservation.ReturnDate - reservation.PickupDate).Days * car.RentCostPerDay;

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReservation), new { id = reservation.Id }, reservation);

        }
    }
}
