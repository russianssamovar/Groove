import React, { Component } from 'react';
import { Dashboard } from '../components/Dashboard';
import { LoginTabsLayout } from '../components/Auth/LoginTabsLayout';
import { connect } from 'react-redux'
import { Grid } from '@material-ui/core';
import { setAuth } from '../actions/AuthActions'
import { setTab } from '../actions/AuthTabsActions'


export  class App extends Component {
  displayName = App.name

  render() {
    const { auth, dashboard, authTab, setAuthAction, setTabAction} = this.props
    if(auth.isLogin)
    {
      return (
        <Grid container >
          <Dashboard dashboard={dashboard}/>
        </Grid>
    );
    }
    else
    {
      return (
        <Grid container >
          <LoginTabsLayout authTab={authTab} auth={auth} setAuth={setAuthAction} setTab={setTabAction}/>
        </Grid>
    );
    }
  }
}

const mapStateToProps = store => {
  console.log(store) 
  return {
    auth: store.auth,
    dashboard: store.dashboard,
    authTab: store.authTab
  }
}

const mapDispatchToProps = dispatch => ({
    setAuthAction: auth => dispatch(setAuth(auth)), 
    setTabAction: value => dispatch(setTab(value)), 
})

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(App)