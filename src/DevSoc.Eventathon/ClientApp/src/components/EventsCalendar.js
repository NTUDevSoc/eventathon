import React, { useState, useCallback } from 'react'
import { Calendar, momentLocalizer } from 'react-big-calendar';
import moment from 'moment';
import 'react-big-calendar/lib/css/react-big-calendar.css';
import { getEvents, createEvent } from '../api/events-endpoint';
import events from '../resources/events'

const localizer = momentLocalizer(moment);

export const EventsCalendar = () => {
    const [myEventsList, setEvents] = useState(events)

    // Makes the call but returned structure doesn't include the events in an array
    const eventList = getEvents();
    const isLoading = useState(() => eventList == null, [eventList]);
    
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