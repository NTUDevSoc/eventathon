import React, { useState } from 'react';
import { Calendar, momentLocalizer } from 'react-big-calendar';
import moment from 'moment';
import 'react-big-calendar/lib/css/react-big-calendar.css';

const localizer = momentLocalizer(moment);

const myEventsList = [
    {
        id: 0,
        title: 'All Day Event',
        allDay: true,
        start: new Date(2022, 5, 11),
        end: new Date(2022, 5, 12),
      },
      {
        id: 1,
        title: 'Long Event',
        start: new Date(2022, 5, 10),
        end: new Date(2015, 5, 13),
      },
      {
        id: 2,
        title: 'Short event',
        start: new Date(2022, 5, 11, 11, 0, 0),
        end: new Date(2022, 5, 11, 14, 0, 0),
      }
];


export const EventsCalendar = () => {
    return (
        <div>
            <h1>BASIC CALENDAR PAGE EXAMPLE!</h1>
            <Calendar
                localizer={localizer} 
                events={myEventsList}
                startAccessor="start"
                endAccessor="end"
            />
        </div>
    );
};