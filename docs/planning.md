# Aims & Objectives

The main goal for this system is to be able to:
- Plan events
- Display events on a calendar
- Allow people to register attendance for a particular event

# Requirements

## Notes

There is purposely some ambiguity around these requirements, as we don't want to infer implementation too much. In particular, there is no mention of exactly what data is collected for things like events, users, or even people registering or marking interest in events.
This is left up to implementation detail, and will be discussed further as we get into design.

## General definitions:
- Event: In this context, an event is a planned occasion of some kind organised by DevSoc, or potentially in collaboration with DevSoc. These can be anything from workshops and presentations to hackathons and game jams.
- User: There will need to be some concept of a 'login' so that certain people can be identified. Not everyone will necessarily need to have a user, but this is important so that random people can't add events to the DevSoc events calendar.
- Person/People: Whenever a person or people are mentioned, we typically mean any person using this system. It is purposely not mentioned whether or not they have a user, as this is likely down to implementation.
- Attendance: This means the person is or was explicitly at the event. Note that this is different to marking interest in an event; if we say someone attended an event, it means they should've actually been there.
- Calendar: When referring to the calendar, the expectation here is that there'll be some kind of grid-based interface like Google calendar which shows events on it.

## Must-haves

1. It **must** be possible to create and schedule events
2. Events **must** only be added/scheduled by users who are authorised to do so
3. Events **must** be visible on a calendar so that anyone can see them
4. People **must** be able to register their attendance for an event
5. It **must** only be possible to register event attendance when the event is happening
6. Authorised users **must** be able to view event attendees

## Should-haves

1. It **should** only be possible to register event attendance if the person is actually attending the event
2. It **should** be possible for a person to mark themselves as 'interested' in an event
3. When events are created, they **should** also be created in the DevSoc discord
4. The calendar **should** be embeddable on the DevSoc main website (https://devsoc.co.uk)
5. It **should** be possible to create draft events (without publishing them publicly)
6. It **should** be possible to edit scheduled events.
7. Events **should** be cancellable.

## Could-haves

1. It **could** support external people registering event attendance (people who do not attend NTU, alumni, etc.)
2. People **could** make event suggestions or request collaboration events
3. The event calendar **could** support calendar link generation (such as an iCal link) so that people can add the DevSoc events calendar to their own personal calendar.
4. Event updates **could** send out automated emails to people who have marked themselves as interested.