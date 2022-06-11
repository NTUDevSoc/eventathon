import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { Counter } from './components/Counter';
import { Calendar } from './components/Calendar';

import './custom.css'

export const App = () => {
  return (
    <Layout>
      <Route exact path='/' component={Home} />
      <Route path='/counter' component={Counter} />
      <Route path='/calendar' component={Calendar} />  
    </Layout>
  );
}
