import axios from "axios";

const API_URL = "https://localhost:7039/api";

export const getReservas = async () => {
    const response = await axios.get(`${API_URL}/reservas`);
    return response.data;
};

export const postReserva = async (reserva: { cliente: string; servicioId: number; fechaHora: string }) => {
    const response = await axios.post(`${API_URL}/reservas`, reserva);
    return response.data;
};

export const getServicios = async () => {
    const response = await axios.get(`${API_URL}/servicios`);
    return response.data;
};

