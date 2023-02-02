import React, { useState } from 'react';
import axios from 'axios';
import {useNavigate} from "react-router-dom";

interface State {
    username: string;
    email: string;
    password: string;
    confirmationPassword: string;
    showPassword: boolean;
}

const Registration = () => {
    const [state, setState] = useState<State>({ username: '', email: '', password: '', confirmationPassword: '', showPassword: false});


    const navigate = useNavigate();

    const onLogin = async (username: string, password: string) => {

        console.log(username + " " + password);

        //const userName = (document.getElementById("username") as HTMLInputElement).value;
        //const password = (document.getElementById("password") as HTMLInputElement).value;

        /*const response = await axios.post("https://localhost:7017/api/auth/login", {
            emailOrUsername: username,
            password: password
        });*/

        /*
        const response = await fetch('https://localhost:7017/api/auth/login', {
            method: 'POST',
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                emailOrUsername: username,
                password: password
            })
        });*/

        /*let elem;

        if (response.status === 400) {
            navigate("/");
            return;
        } else {
            elem = document.createElement("img");
            elem.setAttribute("src", "images/huh.png")
        }

        let firstElem = document.getElementById("huh")!.firstChild;
        document.getElementById("huh")!.insertBefore(elem, firstElem);*/
    };


    const handleSubmit = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        await onLogin(state.email, state.password);
    };

    const togglePasswordVisibility = () => {
        setState({ ...state, showPassword: !state.showPassword});
    }

    return (
        <form onSubmit={handleSubmit}>
            <label>
                Email:
                <input
                    type="text"
                    value={state.email}
                    onChange={e =>
                        setState({ ...state, email: e.target.value })
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
        </form>
    );
};

export default Registration;