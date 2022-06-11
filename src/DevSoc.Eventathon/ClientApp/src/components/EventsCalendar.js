import React, { useState, useCallback } from 'react'
import { Calendar, momentLocalizer } from 'react-big-calendar';
import moment from 'moment';
import 'react-big-calendar/lib/css/react-big-calendar.css';
import events from '../resources/events'
import axios from "axios";

const localizer = momentLocalizer(moment);


export const EventsCalendar = () => {
    const [myEventsList, setEvents] = useState(events)
    
    const handleSelectSlot = useCallback(
        ({ start, end }) => {
            const title = window.prompt('Enter event name: ')
            console.log(start)
            if (title) {
                setEvents((prev) => [...prev, { start, end, title }])
            }
            
            const element = document.querySelector('#post-request .article-id');
            const article = { example: 'example data' };
            axios.post('api/test', article).then(response => element.innerHTML = response.data.id);
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