import React, { useEffect, useState } from "react";
import axios from "axios";
import ReservationForm from "../pages/Reservation/ReservationForm";

const Reservation = () => {
    const [locations, setLocations] = useState([]);
    const [cars, setCars] = useState([]);
    const [reservation, setReservation] = useState({
        carId: '',
        nameSurname: '',
        email: '',
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
        const { carId, nameSurname, email, pickupDate, returnDate, pickupLocationId, returnLocationId } = reservation;
        axios.post('https://localhost:7069/Reservations', { carId, nameSurname, email, pickupDate, returnDate, pickupLocationId, returnLocationId })
        .then(response =>{
            const rentCost = response.data.rentCost;
            alert(`Reservation created successfully! Total cost of reservation: ${rentCost}`);
            setReservation({
                carId: '',
                nameSurname: '',
                email: '',
                pickupLocationId: '',
                returnLocationId: '',
                pickupDate: '',
                returnDate: '',
            });
        })
        .catch(error => console.error("An error occured while posting reservation", error))
    };

    return (
        <ReservationForm
            cars={cars}
            locations={locations}
            handleChange={handleChange}
            handleSubmit={handleSubmit}
            reservation={reservation}
        />
    );
}

export default Reservation;