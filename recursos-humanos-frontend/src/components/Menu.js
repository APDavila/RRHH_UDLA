import React from 'react';
import { useNavigate } from 'react-router-dom';

const Menu = () => {
    const navigate = useNavigate();

    return (
        <div className="menu">
            <h1 className="menu-title">Menú Principal</h1>
            <button onClick={() => navigate('/internal')}>Agregar Usuario</button>
            <button onClick={() => navigate('/listUser')}>Usuarios Internos</button>
            <button onClick={() => navigate('/external')}>Usuarios Externos</button>
            <button onClick={() => alert('Saliendo...')}>Salir</button>
        </div>
    );
};

export default Menu;
