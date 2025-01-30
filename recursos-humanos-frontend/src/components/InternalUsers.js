import React, { useState } from 'react';
import axios from 'axios';
import '../styles/InternalUsers.css';

const InternalUsers = () => {
    const [formData, setFormData] = useState({
        name: '',
        email: '',
        age: '',
        address: '',
        genderCode: 'M',  // "M" para masculino, "F" para femenino
        statusCode: 'A',  // "A" para activo, "I" para inactivo
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData({
            ...formData,
            [name]: value,
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const response = await axios.post('https://localhost:7237/api/People', formData);
            console.log('Usuario creado:', response.data);
            alert('Usuario creado exitosamente');
        } catch (error) {
            console.error('Error al crear el usuario:', error);
            alert('Error al crear el usuario');
        }
    };

    return (
        <div className="internal-users-container">
            <h1>Usuarios Internos</h1>
            <form onSubmit={handleSubmit} className="user-form">
                <div className="form-group">
                    <label>Nombre:</label>
                    <input
                        type="text"
                        name="name"
                        value={formData.name}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Correo Electrónico:</label>
                    <input
                        type="email"
                        name="email"
                        value={formData.email}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Edad:</label>
                    <input
                        type="number"
                        name="age"
                        value={formData.age}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Dirección:</label>
                    <input
                        type="text"
                        name="address"
                        value={formData.address}
                        onChange={handleChange}
                        required
                    />
                </div>
                <div className="form-group">
                    <label>Género:</label>
                    <select
                        name="genderCode"
                        value={formData.genderCode}
                        onChange={handleChange}
                        required
                    >
                        <option value="M">Masculino</option>
                        <option value="F">Femenino</option>
                        <option value="B">Binario</option>
                    </select>
                </div>
                <div className="form-group">
                    <label>Estado:</label>
                    <select
                        name="statusCode"
                        value={formData.statusCode}
                        onChange={handleChange}
                        required
                    >
                        <option value="A">Activo</option>
                        <option value="I">Inactivo</option>
                    </select>
                </div>
                <button type="submit" className="submit-button">Crear Usuario</button>
            </form>
        </div>
    );
};

export default InternalUsers;
