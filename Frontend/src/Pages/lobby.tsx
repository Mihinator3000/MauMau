import React, {useEffect} from "react";
import {HubConnectionBuilder, LogLevel} from "@microsoft/signalr";

const Lobby = () => {
    useEffect(() => {
        const connection = new HubConnectionBuilder()
            .withUrl("https://localhost:7017/lobby")
            .configureLogging(LogLevel.Information)
            .withAutomaticReconnect()
            .build();

        //Maybe set connection.serverTimeoutInMilliseconds = 1000 * 60 * 10;

        connection.on("Send", (data) => {
            let elem = document.createElement("p");
            elem.appendChild(document.createTextNode(data));
            let firstElem = document.getElementById("chatroom")!.firstChild;
            document.getElementById("chatroom")!.insertBefore(elem, firstElem);
        });


        document.getElementById("sendBtn")!.addEventListener("click", function (e) {
            let message = (document.getElementById("message") as HTMLInputElement).value;
            connection.invoke("Send", message);
        });

        connection.start();

        return () => {
            connection.stop();
        };
    }, []);
/*
    document.getElementById("loginBtn")!.addEventListener("click", async () => {
        const userName = (document.getElementById("username") as HTMLInputElement).value;
        const password = (document.getElementById("password") as HTMLInputElement).value;

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

        if (response.ok)
        {
            elem = document.createElement("p");
            elem.appendChild(document.createTextNode("Слушай, ты реально крутой"));
        }
        else
        {
            elem = document.createElement("img");
            elem.setAttribute("src", "images/huh.png")
        }

        let firstElem = document.getElementById("chatroom")!.firstChild;
        document.getElementById("chatroom")!.insertBefore(elem, firstElem);
    })*/

    return (
        <div>
            <div id="inputForm">
                <input type="text" id="message" />
                <input type="button" id="sendBtn" value="Отправить" />
            </div>
            <div id="chatroom"></div>
        </div>
    );
};

export default Lobby;