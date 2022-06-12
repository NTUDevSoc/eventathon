import React from 'react'
import axios from "axios";

const SendAttendance = () => {
    const element = document.querySelector('#post-request .article-id');
    const article = {
        userID: 107,
        eventID: 162,
        name: "Arbitrarily Chosen Name Here",
    };
    axios.post('api/attendance', article).then(response => element.innerHTML = response.data.id);
}

export const ConfirmAttendance = () => {

    return (
        <div>
            <h1><u>Event!</u></h1>
            <ul>
                <li> Title: </li>
                <li> Description: </li>
                <li> Start: </li>
                <li> End: </li>
            </ul>
            <button className="btn btn-primary" onClick={SendAttendance}>Register Attendance</button>
            
        </div>
    );
}