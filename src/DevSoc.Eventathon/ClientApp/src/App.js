import React from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Counter } from './components/Counter';
import { EventsCalendar } from './components/EventsCalendar';
import { HealthCheck } from './components/HealthCheck';
import { UsersEvents } from './components/UsersEvents';

import './custom.css'

export const App = () => {
  return (
    <Layout>
      <Route exact path='/' component={Home} />
      <Route path='/counter' component={Counter} />
      <Route path='/calendar' component={EventsCalendar} />  
      <Route path='/healthcheck' component={HealthCheck} />
      <Route path='/attendance' component={UsersEvents} />
    </Layout>
  );
}
