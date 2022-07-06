import { Calendar, momentLocalizer } from 'react-big-calendar';
import moment from 'moment';
import 'react-big-calendar/lib/css/react-big-calendar.css';
import events from '../resources/events'
import React, { useState } from 'react'

const localizer = momentLocalizer(moment);

export const UsersEvents = () => {
    const [myEventsList] = useState(events)
    
    return (
        <div className="my-3">
            <h1><u>My Events!</u></h1>
            <p>Here you will see all scheduled events you are attending:</p>
            <hr></hr>
            <Calendar
                className = "rbc-calendar"
                localizer={localizer}
                events={myEventsList}
                startAccessor="start"
                endAccessor="end"
            />
         </div>
    );
}