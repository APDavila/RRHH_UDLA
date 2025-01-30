import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { FaUser, FaMale, FaFemale, FaRegHandPointer } from 'react-icons/fa';
import '../styles/ExternalUsers.css'; // Importamos los estilos

const ExternalUsers = () => {
    const [users, setUsers] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        axios.get('https://localhost:7237/api/People/ExternalUsers')
            .then(response => {
                setUsers(response.data);
                setLoading(false);
            })
            .catch(error => {
                console.error(error);
                setLoading(false);
            });
    }, []);

    return (
        <div className="external-users">
            <h1>Usuarios Externos</h1>
            {loading ? (
                <p>Cargando...</p>
            ) : (
                <div className="user-list">
                    <ul className="user-items">
                        {users.map(user => (
                            <li key={user.id} className={`user-item ${user.status === 'inactive' ? 'inactive' : 'active'}`}>
                                {/* Ícono de perfil */}
                                <FaUser className="user-icon" />
                                <div className="user-info">
                                    <div className="user-name">
                                        {/* Nombre del usuario */}
                                        <strong>{user.name}</strong>
                                    </div>
                                    {/* Género con íconos */}
                                    <div className="gender-icon">
                                        {user.gender === 'male' ? <FaMale /> : <FaFemale />}
                                    </div>
                                    {/* Detalles */}
                                    <div>{user.email}</div>
                                    <div>{user.status}</div>
                                    {/* Ícono de click para usuarios activos */}
                                    {user.status === 'active' && <FaRegHandPointer className="clickable-icon" />}
                                </div>
                            </li>
                        ))}
                    </ul>
                </div>
            )}
        </div>
    );
};

export default ExternalUsers;
