import React, { Component } from 'react';
import { Dashboard } from '../components/Dashboard';
import { LoginTabsLayout } from '../components/Auth/LoginTabsLayout';
import { connect } from 'react-redux'
import { Grid } from '@material-ui/core';
import { setAuth } from '../actions/AuthActions'
import { setTab } from '../actions/AuthTabsActions'
import AddPage from '../components/Tiles/AddPage'
import axios from 'axios';
import { Route } from 'react-router';
import Cookies from 'js-cookie';

export  class App extends Component {
  displayName = App.name
  
    render() {
      const { auth, dashboard, authTab, setAuthAction, setTabAction} = this.props
      axios.get('/api/identity/isValid?token=' + Cookies.get('token')
      ).then((response) =>
      {
        if(response.data !== false)
        {
          setAuthAction({access_token: response.data.access_token, username: response.data.userName})
        }
        else
        {
          setAuthAction({access_token: "", username: ""})
        }
      })
      .catch((error) => {
        console.log(error);
    });

    if(!auth.isLogin)
    {
      return (
        <Grid container >
          <LoginTabsLayout authTab={authTab} auth={auth} setAuth={setAuthAction} setTab={setTabAction}/>
        </Grid>
    );
    }
    else
    {
      return (
        <Grid container >
          <Route exact path="/accounts/add" render={() => (<AddPage auth={auth} />)} />
          <Dashboard auth={auth} dashboard={dashboard}/>
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