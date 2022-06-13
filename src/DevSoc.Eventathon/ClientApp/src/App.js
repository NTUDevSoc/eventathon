import React from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Counter } from './components/Counter';
import { EventsCalendar } from './components/EventsCalendar';
import { HealthCheck } from './components/HealthCheck';
import { UsersEvents } from './components/UsersEvents';
import {ConfirmAttendance} from "./components/ConfirmAttendance";

import './custom.css'
import {AccountPage} from "./components/AccountPage";


export const App = () => {
  return (
    <Layout>
      <Route exact path='/' component={Home} />
      <Route path='/counter' component={Counter} />
      <Route path='/calendar' component={EventsCalendar} />  
      <Route path='/healthcheck' component={HealthCheck} />
      <Route path='/userEvents' component={UsersEvents} />
      <Route path='/attendance' component={ConfirmAttendance} />
      <Route path='/account' component={AccountPage} />
    </Layout>
  );
}

