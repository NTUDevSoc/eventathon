import React from 'react';

import { Calendar, momentLocalizer } from 'react-big-calendar'
import moment from 'moment'
import 'react-big-calendar/lib/css/react-big-calendar.css';

const localizer = momentLocalizer(moment)

/*const myEventsList = [
    {
        "title": "on DST",
        "start": "2022-11-06T01:00:00.000Z",
        "end": "2022-11-06T03:30:00.000Z",
        "allDay": false
    },
    {
        "title": "crosses DST",
        "start": "2022-06-11T01:00:00.000Z",
        "end": "2022-11-06T06:30:00.000Z",
        "allDay": false
    },
    {
        "title": "After DST",
        "start": "2022-11-06T07:00:00.000Z",
        "end": "2022-11-06T07:45:00.000Z",
        "allDay": false
    }
]*/


export const MyCalendar = () => {
    return (
        <div>
            <h1>BASIC CALENDAR PAGE EXAMPLE!</h1>
            <Calendar
                localizer={localizer} 
                // events={myEventsList}
                startAccessor="start"
                endAccessor="end"
            />
        </div>
    );
}