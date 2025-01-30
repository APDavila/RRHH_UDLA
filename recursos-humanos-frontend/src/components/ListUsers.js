import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { FaMale, FaFemale, FaTrash } from 'react-icons/fa'; // Íconos de hombre, mujer y basurero
import '../styles/ListUsers.css'; // Asegúrate de tener estilos en este archivo

const ListUsers = () => {
    const [users, setUsers] = useState([]);
    const [selectedUser, setSelectedUser] = useState(null); // Para almacenar el usuario seleccionado
    const [loading, setLoading] = useState(true);

    // Obtener los usuarios
    useEffect(() => {
        axios.get('https://localhost:7237/api/People')
            .then(response => {
                setUsers(response.data);
                setLoading(false);
            })
            .catch(error => {
                console.error('Error al obtener usuarios:', error);
                setLoading(false);
            });
    }, []);

    // Eliminar un usuario
    const handleDelete = async (id) => {
        try {
            await axios.delete(`https://localhost:7237/api/People/${id}`);
            setUsers(users.filter(user => user.id !== id)); // Filtrar el usuario eliminado
            alert('Usuario eliminado exitosamente');
        } catch (error) {
            console.error('Error al eliminar el usuario:', error);
            alert('Error al eliminar el usuario');
        }
    };

    // Mostrar los detalles del usuario
    const handleSelectUser = (user) => {
        setSelectedUser(user);
    };

    // Cerrar el pop-up
    const closeModal = () => {
        setSelectedUser(null);
    };

    return (
        <div className="list-users-container">
            <h1>Lista de Usuarios</h1>
            {loading ? (
                <p>Cargando...</p>
            ) : (
                <div>
                    <ul className="user-list">
                        {users.map(user => (
                            <li key={user.id} className="user-item" onClick={() => handleSelectUser(user)}>
                                {/* Icono según género */}
                                {user.genderCode === 'M' ? <FaMale className="gender-icon" /> : <FaFemale className="gender-icon" />}
                                <div className="user-info">
                                    <strong>{user.name}</strong>
                                    <p>{user.email}</p>
                                </div>
                                <button onClick={() => handleDelete(user.id)} className="delete-btn">
                                    <FaTrash />
                                    Eliminar
                                </button>
                            </li>
                        ))}
                    </ul>

                    {/* Modal con los detalles del usuario seleccionado */}
                    {selectedUser && (
                        <div className="modal">
                            <div className="modal-content">
                                <span className="close-btn" onClick={closeModal}>×</span>
                                <h2>{selectedUser.name}</h2>
                                <p><strong>Email:</strong> {selectedUser.email}</p>
                                <p><strong>Edad:</strong> {selectedUser.age}</p>
                                <p><strong>Dirección:</strong> {selectedUser.address}</p>
                                <p><strong>Género:</strong> {selectedUser.gender.description}</p>
                                <p><strong>Estado:</strong> {selectedUser.status.description}</p>
                            </div>
                        </div>
                    )}
                </div>
            )}
        </div>
    );
};

export default ListUsers;
