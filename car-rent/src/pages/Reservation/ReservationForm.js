import React from "react";
import './ReservationForm.css';

const ReservationForm = ({ cars, locations, handleChange, handleSubmit, reservation }) => {
    return (
        <form className="reservation-form" onSubmit={handleSubmit}>
        <h1>Rent a Tesla</h1>
        <label>
          Name and Surname:
          <input type="text" name="nameSurname" value={reservation.nameSurname} onChange={handleChange} required />
        </label>
        <label>
          Email:
          <input type="text" name="email" value={reservation.email} onChange={handleChange} required />
        </label>
        <label>
          Car Model:
          <select name="carId" value={reservation.carId} onChange={handleChange} required>
            <option value="">Select a car</option>
            {cars.map(car => (
              <option key={car.id} value={car.id}>
                {car.model}
              </option>
            ))}
          </select>
        </label>
        <label>
          Pickup Location:
          <select name="pickupLocationId" value={reservation.pickupLocationId} onChange={handleChange} required>
            <option value="">Select a location</option>
            {locations.map(location => (
              <option key={location.id} value={location.id}>
                {location.name}
              </option>
            ))}
          </select>
        </label>
        <label>
          Return Location:
          <select name="returnLocationId" value={reservation.returnLocationId} onChange={handleChange} required>
            <option value="">Select a location</option>
            {locations.map(location => (
              <option key={location.id} value={location.id}>
                {location.name}
              </option>
            ))}
          </select>
        </label>
        <label>
          Pickup Date:
          <input type="date" name="pickupDate" value={reservation.pickupDate} onChange={handleChange} required />
        </label>
        <label>
          Return Date:
          <input type="date" name="returnDate" value={reservation.returnDate} onChange={handleChange} required />
        </label>
        <button type="submit">Reserve</button>
      </form>
    );
};

export default ReservationForm;