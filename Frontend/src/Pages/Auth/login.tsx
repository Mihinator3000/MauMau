/*import React, {ChangeEvent, useState} from "react";
import './../App.css';

const Login = () => {

    const [username, setUsername] = useState<string>();
    const [password, setPassword] = useState();

    const login = async () => {

        console.log(username + " " + password);
        return;

        const userName = (document.getElementById("username") as HTMLInputElement).value;
        //const password = (document.getElementById("password") as HTMLInputElement).value;

        const response = await fetch('https://localhost:7017/api/auth/login', {
            method: 'POST',
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                emailOrUsername: userName,
                password: password
            })
        });

        let elem;

        if (response.ok) {
            elem = document.createElement("p");
            elem.appendChild(document.createTextNode("Слушай, ты реально крутой"));
        } else {
            elem = document.createElement("img");
            elem.setAttribute("src", "images/huh.png")
        }

        let firstElem = document.getElementById("chatroom")!.firstChild;
        document.getElementById("chatroom")!.insertBefore(elem, firstElem);
    };

    const onChange = (e: ChangeEvent<HTMLInputElement>) => {
        const newValue = e.target.value;
        setUsername(newValue);
    };

    return (
        <div>
            <input type="text" value={username} onChange={e => setUsername({ })} />
            <input type="text" value={password} />
            <input type="button" value="Login" onClick={login} />
        </div>
    );
};

export default Login;*/

import React, { useState } from 'react';
import {useNavigate} from "react-router-dom";
import axios from "axios";

interface State {
    emailOrUsername: string;
    password: string;
    showPassword: boolean;
}

const Login = () => {
    const [state, setState] = useState<State>({ emailOrUsername: '', password: '', showPassword: false});

    const navigate = useNavigate();

    const onLogin = async (username: string, password: string) => {
        const loginData = {
            emailOrUsername: username,
            password: password
        }

        const response = await axios.post("https://localhost:7017/api/auth/login", loginData);

        if (response.status === 200) {
            navigate("/");
            return;
        }

        let elem = document.createElement("img");
        elem.setAttribute("src", "images/huh.png")
        let firstElem = document.getElementById("huh")!.firstChild;
        document.getElementById("huh")!.insertBefore(elem, firstElem);
    };


    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        await onLogin(state.emailOrUsername, state.password);
    };

    const togglePasswordVisibility = () => {
        setState({ ...state, showPassword: !state.showPassword});
    }

    return (
        <form onSubmit={handleSubmit}>
            <label>
                Email or username:
                <input
                    type="text"
                    value={state.emailOrUsername}
                    onChange={e =>
                        setState({ ...state, emailOrUsername: e.target.value })
                    }
                />
            </label>
            <br />
            <label>
                Password:
                <input
                    type={state.showPassword ? "text" : "password"}
                    value={state.password}
                    onChange={e =>
                        setState({ ...state, password: e.target.value })
                    }
                />
            </label>
            <button
                type="button"
                onMouseOver={togglePasswordVisibility}
                onMouseOut={togglePasswordVisibility}
            >
                Show Password
            </button>
            <br />
            <button type="submit">Login</button>
            <div id="huh"></div>
            <br />
            <button
                type="button"
                onClick={() => navigate("/register")}
            >
                Register
            </button>
        </form>
    );
};

export default Login;