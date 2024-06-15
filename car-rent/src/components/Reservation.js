import React, { useEffect, useState } from "react";
import axios from "axios";

const Reservation = () => {
    const [locations, setLocations] = useState([]);
    const [cars, setCars] = useState([]);
    const [reservation, setReservation] = useState({
        carId: '',
        pickupLocationId: '',
        returnLocationId: '',
        pickupDate: '',
        returnDate: '',
    });

    useEffect(() => 
    {
        axios.get('https://localhost:7069/Locations')
        .then(response => setLocations(response.data))
        .catch(error => console.error("An error occured while getting locations!", error));

        axios.get('https://localhost:7069/Cars')
        .then(response => setCars(response.data))
        .catch(error => console.error("An error occured while getting cars!", error));

    }, []);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setReservation(prevState => ({...prevState, [name]:value }));
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        const { carId, pickupDate, returnDate, pickupLocationId, returnLocationId } = reservation;
        axios.post('https://localhost:7069/Reservations', { carId, pickupDate, returnDate, pickupLocationId, returnLocationId })
        .then(response => alert("Reservation created successfully!"))
        .catch(error => console.error("An error occured while posting reservation", error))
    };

    return (
        <form onSubmit={handleSubmit}>
            <h1>Rent a Tesla</h1>
            <label>
                Car Model:
                <select name="carId" onChange={handleChange} required>
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
                <select name="pickupLocationId" onChange={handleChange} required>
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
                <select name="returnLocationId" onChange={handleChange} required>
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
                <input type="date" name="pickupDate" onChange={handleChange} required />
            </label>
            <label>
                Return Date:
                <input type="date" name="returnDate" onChange={handleChange} required />
            </label>
            <button type="submit">Reserve</button>
        </form>
    );
}

export default Reservation;