import React, { useEffect, useState } from "react";
import { postReserva, getServicios } from "../services/api";

const ReservaForm: React.FC = () => {
    const [cliente, setCliente] = useState("");
    const [fechaHora, setFechaHora] = useState("");
    const [servicioId, setServicioId] = useState<number | null>(null);
    const [servicios, setServicios] = useState<{ id: number; nombre: string }[]>([]);
    const [mensaje, setMensaje] = useState<string>("");

    useEffect(() => {
        getServicios().then(setServicios).catch(() => {
            setMensaje("Error al cargar los servicios.");
        });
    }, []);

    const handleReservar = async () => {
        if (!cliente || !fechaHora || servicioId === null) {
            setMensaje("Todos los campos son obligatorios.");
            return;
        }

        try {
            const response = await postReserva({ cliente, servicioId, fechaHora });

            // Si el backend devuelve un objeto con message
            if (typeof response === "object" && response.message) {
                setMensaje(response.message);
            } else {
                setMensaje("Reserva creada correctamente.");
            }
        } catch (error: any) {
            if (error.response?.data?.message) {
                setMensaje(error.response.data.message);
            } else {
                setMensaje("Error al crear la reserva.");
            }
        }
    };

    return (
        <div>
            <h2>Reservar Servicio</h2>
            <input
                type="text"
                placeholder="Cliente"
                value={cliente}
                onChange={e => setCliente(e.target.value)}
            />
            <input
                type="datetime-local"
                value={fechaHora}
                onChange={e => setFechaHora(e.target.value)}
            />

            <select value={servicioId ?? ""} onChange={e => setServicioId(Number(e.target.value))}>
                <option value="">Selecciona un servicio</option>
                {servicios.map(servicio => (
                    <option key={servicio.id} value={servicio.id}>
                        {servicio.nombre}
                    </option>
                ))}
            </select>

            <button onClick={handleReservar}>Reservar</button>

            {/* Mostrar mensaje solo si es texto */}
            {mensaje && <p>{mensaje}</p>}
        </div>
    );
};

export default ReservaForm;
