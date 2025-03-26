import React, { useEffect, useState } from "react";
import { getReservas } from "../services/api";

type Reserva = {
    cliente: string;
    fechaHora: string;
    servicioNombre: string;
};

const ListaReservas: React.FC = () => {
    const [reservas, setReservas] = useState<Reserva[]>([]);

    useEffect(() => {
        getReservas()
            .then(setReservas)
            .catch(() => {
                console.error("Error al obtener reservas.");
            });
    }, []);

    return (
        <div>
            <h2>Lista de Reservas</h2>
            <ul>
                {reservas.map((reserva, index) => (
                    <li key={index}>
                        {reserva.cliente} -{" "}
                        {new Date(reserva.fechaHora).toLocaleString()} -{" "}
                        {reserva.servicioNombre}
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default ListaReservas;
