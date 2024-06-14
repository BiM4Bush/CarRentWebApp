namespace CarRentWebApi.Models.Request
{
    public class CreateReservationRequest
    {
        public int CarId { get; set; }
        public int PickupLocationId { get; set; }
        public int ReturnLocationId { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
