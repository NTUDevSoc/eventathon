import { Calendar, momentLocalizer } from 'react-big-calendar';
import moment from 'moment';
import 'react-big-calendar/lib/css/react-big-calendar.css';
import events from '../resources/events'
import React, { useState, useCallback } from 'react'
import axios from "axios";

const localizer = momentLocalizer(moment);

const ConfirmAttendance = () => {
    const element = document.querySelector('#post-request .article-id');
    const article = {
        userID: 107,
        eventID: 162,
        name: "Arbitrarily Chosen Name Here",
    };
    axios.post('api/attendance', article).then(response => element.innerHTML = response.data.id);
}

export const UsersEvents = () => {
    const [myEventsList, setEvents] = useState(events)
    
    return (
        <div>
            <h1>My Events!</h1>

            <button className="btn btn-primary" onClick={ConfirmAttendance}>Register Attendance</button>
            
            <p>Here you will see all scheduled events you are attending:</p>
            <Calendar
                localizer={localizer}
                events={myEventsList}
                startAccessor="start"
                endAccessor="end"
                selectable
            />
         </div>
    );
}