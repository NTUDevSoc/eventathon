import React, { useCallback } from 'react'
import { Calendar, momentLocalizer } from 'react-big-calendar';
import moment from 'moment';
import 'react-big-calendar/lib/css/react-big-calendar.css';
import { useEvents, createEvent } from '../api/events-endpoints';

import { useHistory } from "react-router-dom";

const localizer = momentLocalizer(moment);

export const EventsCalendar = () => {
    const history = useHistory();
    const { data: events, mutate } = useEvents();

    const handleSelectSlot = useCallback(
        ({ start, end }) => {
            const title = window.prompt('Enter event name: ')
            const description = window.prompt('Enter event description: ')

            mutate(createEvent(title, description, start, end), { optimisticData: { title, description, start, end }, rollbackOnError: true });
        },
        [mutate]
    )

    const handleSelectEvent = useCallback(
        (event) => {
            history.push(
                {
                    pathname: "/attendance",
                    state: {
                        givenId: event.id,
                        givenTitle: event.title,
                        givenDescription: event.description,
                        givenStart: event.start,
                        givenEnd: event.end
                    }
                }
            )
        }, [history]
    )

    return (
        <div className="my-3">
            <h1><u>Our Events!</u></h1>
            <p>Welcome to the DevSoc events calendar. Here you can see all scheduled events.
            If you're a committee member you can also schedule new events from this page.
            If you can schedule events and you're not a committtee member this is a bug.
                Be a good person and just don't use this immense power.</p>
            <hr></hr>
            {!events ?
                <p>Loading calendar...</p> :
                <Calendar
                    className="rbc-calendar"
                    localizer={localizer}
                    events={events}
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