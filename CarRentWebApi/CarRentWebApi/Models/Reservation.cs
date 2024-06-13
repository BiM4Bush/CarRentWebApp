namespace CarRentWebApi.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int PickupLocationId { get; set; }
        public int ReturnLocationId { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal RentCost { get; set; }

        public Car Car { get; set; }
        public Location PickupLocation { get; set; }
        public Location ReturnLocation { get; set; }
    }
}
