﻿namespace CarRentWebApi.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Location(int id, string name)//only for test use, may change in the future for random generating Guid Id 
        {
            Id = id;
            Name = name;
        }
    }
}
