import React from 'react'
import { useHistory } from "react-router-dom";
import { registerAttendance } from '../api/attendance-endpoints';

export const ConfirmAttendance = () => {
    const history = useHistory();

    const givenId = history.location.state.givenId
    const givenTitle = history.location.state.givenTitle
    const givenDescription = history.location.state.givenDescription
    const givenStart = history.location.state.givenStart
    const givenEnd = history.location.state.givenEnd

    const SendAttendance = async () => {
        const mockUserId = 107;
        await registerAttendance(mockUserId, givenId);
    }

    return (
        <div className="my-3">
            <h1><u>Event!</u></h1>
            <ul>
                <li> Event ID: {givenId}</li>
                <li> Title: {givenTitle}</li>
                <li> Description: {givenDescription}</li>
                <li> Start: {givenStart.toString()}</li>
                <li> End: {givenEnd.toString()}</li>
            </ul>
            <button className="btn btn-primary" onClick={SendAttendance}>Register Attendance</button>

        </div>
    );
}