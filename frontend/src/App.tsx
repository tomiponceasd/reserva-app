import React from "react";
import ReservaForm from "./components/ReservaForm";
import ListaReservas from "./components/ListaReservas";

const App: React.FC = () => {
    return (
        <div>
            <h1>Gestión de Reservas</h1>
            <ReservaForm />
            <ListaReservas />
        </div>
    );
};

export default App;
