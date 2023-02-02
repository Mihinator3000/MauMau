import React from 'react';
import './App.css';
import Account from './Pages/account'
import Game from "./Pages/game";
import Lobby from "./Pages/lobby";
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import Login from "./Pages/Auth/login";
import Registration from "./Pages/Auth/registration";

const App = () => {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Lobby />} />
                <Route path="/login" element={<Login />} />
                <Route path="/register" element={<Registration />} />
                <Route path="/account" element={<Account />} />
                <Route path="/game/:id" element={<Game />} />
            </Routes>
        </BrowserRouter>
    );
};
export default App;
