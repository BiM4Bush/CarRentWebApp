namespace CarRentWebApi.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public decimal RentCostPerDay { get; set; }

        public Car(int id, string model, decimal rentCostPerDay) //only for test use, may change in the future for random generating Guid Id 
        {
            Id = id;
            Model = model;
            RentCostPerDay = rentCostPerDay;
        }
    }
}
