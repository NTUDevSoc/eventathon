import React, { useState, useCallback, useEffect } from 'react'
import { Calendar, momentLocalizer } from 'react-big-calendar';
import moment from 'moment';
import 'react-big-calendar/lib/css/react-big-calendar.css';
import {useEvents, createEvent} from '../api/events-endpoint';
import { useSWRConfig } from 'swr'
import events from '../resources/events';

import { useHistory } from "react-router-dom";

const localizer = momentLocalizer(moment);

export const EventsCalendar = () => {
    const [eventList, setEvents] = useState(events)
    const history = useHistory();

    const { mutate } = useSWRConfig();
    const [realEventList, setRealEvents] = useState([]);

    const { data: eventsResponse } = useEvents();
    useEffect(() => {
        if (!eventsResponse) return; 
        setRealEvents(eventsResponse.events)
    }, [eventsResponse])
    
    const handleSelectSlot = useCallback(
        ({ start, end}) => {
            const title = window.prompt('Enter event name: ')
            const description = window.prompt('Enter event description: ')
            if (title) {
                setEvents((prev) => [...prev, { description, start, end, title}])
            }
            createEvent(title, start, end);
        },
        mutate('api/events')
        [setEvents]
    )

    const handleSelectEvent = useCallback(
        (event) => {
            history.push(
                {
                    pathname: "/attendance", 
                    state: {"givenID": event.id, "givenTitle": event.title,"givenDescription": event.description,
                        "givenStart": event.start, "givenEnd": event.end}
                }
            )
        },[]
    )

    return (
        <div className="my-3">
            <h1><u>Our Events!</u></h1>
            <p>Welcome to the DevSoc events calendar. Here you can see all scheduled events. 
                If you're a committee member you can also schedule new events from this page. 
                If you can schedule events and you're not a committtee member this is a bug.
                Be a good person and just don't use this immense power.</p>
            <hr></hr>
            {!eventList ? 
                <p>Loading calendar...
                    {mutate('api/events')}
                </p> : 
                <Calendar
                    className = "rbc-calendar"
                    localizer={localizer} 
                    events={eventList}
                    startAccessor="start"
                    endAccessor="end"
                    onSelectSlot={handleSelectSlot}
                    onSelectEvent={handleSelectEvent}
                    selectable
                />   
            }
        </div>
    );
}