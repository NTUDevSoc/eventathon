import React, { useState, useCallback, useEffect } from 'react'
import { Calendar, momentLocalizer } from 'react-big-calendar';
import moment from 'moment';
import 'react-big-calendar/lib/css/react-big-calendar.css';
import { useGetEvents, createEvent } from '../api/events-endpoint';

const localizer = momentLocalizer(moment);

export const EventsCalendar = () => {
    const [eventList, setEvents] = useState(useGetEvents().eventList);

    const handleSelectSlot = useCallback(
        ({ start, end }) => {
            const title = window.prompt('Enter event name: ')
            if (title) {
                setEvents((prev) => [...prev, { start, end, title }])
            }
            createEvent(title, start, end);
        },
        [setEvents]
    )

    const handleSelectEvent = useCallback(
        (event) => window.alert(event.title),
        []
    )

    if (!eventList){
        return <p>Loading calendar...</p>
    }

    return (
        <div>
            <h1>Events Calendar!</h1>
            <p>Welcome to the DevSoc events calendar. Here you can see all scheduled events. 
                If you're a committee member you can also schedule new events from this page. 
                If you can schedule events and you're not a committtee member this is a bug.
                Be a good person and just don't use this immense power.</p>
            <hr></hr>
            <Calendar
                localizer={localizer} 
                events={eventList}
                startAccessor="start"
                endAccessor="end"
                onSelectSlot={handleSelectSlot}
                onSelectEvent={handleSelectEvent}
                selectable
            />         
        </div>
    );
}