import React, { useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import '../styles/styles.css';
import loadingGif from '../assets/loading.gif'; 
const SplashScreen = () => {
    const navigate = useNavigate();

    useEffect(() => {
        const timer = setTimeout(() => {
            navigate('/menu'); 
        }, 5000); 

        return () => clearTimeout(timer); 
    }, [navigate]);

    return (
        <div className="splash-screen">
            <img src={loadingGif} alt="Cargando..." className="loading-gif" />
            <h1>Recursos Humanos</h1>
        </div>
    );
};

export default SplashScreen;
