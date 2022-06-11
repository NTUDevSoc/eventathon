import React, { Fragment, useState, useCallback, useMemo } from 'react'
import { Calendar, momentLocalizer } from 'react-big-calendar';
import moment from 'moment';
import 'react-big-calendar/lib/css/react-big-calendar.css';
import events from '../resources/events'

const localizer = momentLocalizer(moment);




export const EventsCalendar = () => {
    const [myEventsList, setEvents] = useState(events)
    
    const handleSelectSlot = useCallback(
        ({ start, end }) => {
            const title = window.prompt('New Event name')
            console.log(start)
            if (title) {
                setEvents((prev) => [...prev, { start, end, title }])
            }
        },
        [setEvents]
    )

    const handleSelectEvent = useCallback(
        (event) => window.alert(event.title),
        []
    )
    
    return (
        <div>
            <h1>BASIC CALENDAR PAGE EXAMPLE!</h1>
            <Calendar
                localizer={localizer} 
                events={myEventsList}
                startAccessor="start"
                endAccessor="end"
                onSelectSlot={handleSelectSlot}
                onSelectEvent={handleSelectEvent}
                selectable
            />
        </div>
    );
};