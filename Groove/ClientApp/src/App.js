import React, { Component } from 'react';
import { Route } from 'react-router';
import { Root } from './components/Root';
import { Dashboard } from './components/Dashboard';
import { LoginTabsLayout } from './components/LoginTabsLayout';


export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Root>
        <Route exact path='/' component={LoginTabsLayout} />
        <Route path='/dashboard' component={Dashboard}/>
      </Root>
    );
  }
}
