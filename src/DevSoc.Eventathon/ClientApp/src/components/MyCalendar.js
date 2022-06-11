import React from 'react';

import { Calendar, momentLocalizer } from 'react-big-calendar'
import moment from 'moment'

// Setup the localizer by providing the moment (or globalize, or Luxon) Object
// to the correct localizer.
const localizer = momentLocalizer(moment) // or globalizeLocalizer

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