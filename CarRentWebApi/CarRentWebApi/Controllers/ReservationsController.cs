using CarRentWebApi.Data;
using CarRentWebApi.Models;
using CarRentWebApi.Models.Request;
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
        public async Task<ActionResult<Reservation>> CreateReservation (CreateReservationRequest request)
        {
            var car = await _context.Cars.FindAsync(request.CarId);
            if (car == null)
            {
                return NotFound();
            }

            var pickupLocation = await _context.Locations.FindAsync(request.PickupLocationId);
            if (pickupLocation == null)
            {
                return NotFound();
            }

            var returnLocation = await _context.Locations.FindAsync(request.ReturnLocationId);
            if (returnLocation == null)
            {
                return NotFound();
            }


            //Calculation total days of reservation
            var rentalDays = (request.ReturnDate - request.PickupDate).Days;

            var reservation = new Reservation
            {
                CarId = request.CarId,
                NameSurname = request.NameSurname,
                Email = request.Email,
                PickupLocationId = request.PickupLocationId,
                ReturnLocationId = request.ReturnLocationId,
                PickupDate = request.PickupDate,
                ReturnDate = request.ReturnDate,
                RentCost = rentalDays == 0 ? car.RentCostPerDay : rentalDays * car.RentCostPerDay, //Calculation total cost of reservation
                Car = car,
                PickupLocation = pickupLocation,
                ReturnLocation = returnLocation
            };
            
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetReservation), new { id = reservation.Id }, reservation);

        }
    }
}
