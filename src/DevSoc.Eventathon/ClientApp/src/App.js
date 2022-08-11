import './custom.css'

import React from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { EventsCalendar } from './components/EventsCalendar';
import { HealthCheck } from './components/HealthCheck';
import { UsersEvents } from './components/UsersEvents';
import { ConfirmAttendance } from "./components/ConfirmAttendance.tsx";
import { AccountPage } from "./components/AccountPage";


export const App = () => {
  return (
    <Layout>
      <Route exact path='/' component={EventsCalendar} />
      <Route path='/your-events' component={UsersEvents} />
      <Route path='/attend' component={ConfirmAttendance} />
      <Route path='/account' component={AccountPage} />
      <Route path='/healthcheck' component={HealthCheck} />
    </Layout>
  );
}

