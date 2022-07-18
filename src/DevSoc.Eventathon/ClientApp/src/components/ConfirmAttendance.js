import React from 'react'
import axios from "axios";
import {useHistory} from "react-router-dom";
import {SendAttendance} from "../api/events-endpoint";

export const ConfirmAttendance = () => {
    const history = useHistory();
    
    const givenID = history.location.state.givenID
    const givenTitle = history.location.state.givenTitle
    const givenDescription = history.location.state.givenDescription
    const givenStart = history.location.state.givenStart
    const givenEnd = history.location.state.givenEnd
    
    console.log(history.location.state)
    SendAttendance(givenID, givenTitle)

    return (
        <div className="my-3">
            <h1><u>Event!</u></h1>
            <ul>
                <li> Event ID: {givenID}</li>
                <li> Title: {givenTitle}</li>
                <li> Description: {givenDescription}</li>
                <li> Start: {givenStart.toString()}</li>
                <li> End: {givenEnd.toString()}</li>
            </ul>
            <button className="btn btn-primary" onClick={SendAttendance}>Register Attendance</button>
            
        </div>
    );
}