import React from 'react'
import axios from "axios";
import {useHistory} from "react-router-dom";

export const ConfirmAttendance = () => {
    
    // Retrieve parameters from the EventsCalender page
    const history = useHistory();
    const givenTitle = history.location.state.givenTitle
    const givenDescription = history.location.state.givenDescription
    const givenStart = history.location.state.givenStart
    const givenEnd = history.location.state.givenEnd
    
    // Send a POST request representing a user registering attendance
    const SendAttendance = () => {
        const element = document.querySelector('#post-request .article-id');
        const article = {
            userID: 107, // Arbitrarily chosen until user accounts are created
            eventID: 162,
            name: givenTitle,
        };
        axios.post('api/attendance', article).then(response => element.innerHTML = response.data.id);
    }

    return (
        <div>
            <h1><u>Event!</u></h1>
            <ul>
                <li> Title: {givenTitle}</li>
                <li> Description: {givenDescription}</li>
                <li> Start: {givenStart.toString()}</li>
                <li> End: {givenEnd.toString()}</li>
            </ul>
            <button className="btn btn-primary" onClick={SendAttendance}>Register Attendance</button>
            
        </div>
    );
}