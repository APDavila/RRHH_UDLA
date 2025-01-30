import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import SplashScreen from './components/SplashScreen';
import Menu from './components/Menu';
import InternalUsers from './components/InternalUsers';
import ExternalUsers from './components/ExternalUsers';
import ListUsers from './components/ListUsers';
import '../src/styles/styles.css';

const App = () => {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<SplashScreen />} />
                <Route path="/menu" element={<Menu />} />
                <Route path="/internal" element={<InternalUsers />} />
                <Route path="/external" element={<ExternalUsers />} />
                <Route path="/listUser" element={<ListUsers />} />
            </Routes>
        </Router>
    );
};

export default App;
