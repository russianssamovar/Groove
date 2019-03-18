import React, { Component } from 'react';
import { Dashboard } from '../components/Dashboard';
import { LoginTabsLayout } from '../components/Auth/LoginTabsLayout';
import { connect } from 'react-redux'
import { Grid } from '@material-ui/core';
import { setAuth } from '../actions/AuthActions'
import { setTab } from '../actions/AuthTabsActions'
import { setAccounts } from '../actions/DashboardActions'
import AddPage from '../components/Tiles/AddPage'
import axios from 'axios';
import { Route } from 'react-router';
import Cookies from 'js-cookie';
import LinearProgress from '@material-ui/core/LinearProgress';

export class App extends Component {
  displayName = App.name

  componentDidMount() {
    axios.get('/api/identity/isValid?token=' + Cookies.get('token')
    ).then((response) => {
      if (response.data.accessToken !== "") {
        this.props.setAuth({access_token: response.data.accessToken, isLogin: true, username: response.data.userName, userId: response.data.userId, message: response.data.message, isLoading: false});
      }
      else {
        Cookies.remove('token');
        this.props.setAuth({access_token: response.data.accessToken, isLogin: false, username: response.data.userName, userId: response.data.userId, message: response.data.message, isLoading: false});
      }
    })
      .catch((error) => {
        console.log(error);
      });
  }
  render() {
    const { auth, dashboard, authTab, setAuthAction, setTabAction, setAccounts } = this.props

    if (!auth.isLogin && !auth.isLoading) {
      return (
        <Grid container >
          <LoginTabsLayout authTab={authTab} auth={auth} setAuth={setAuthAction} setTab={setTabAction} />
        </Grid>
      );
    }
    if (!auth.isLoading) {
      return (
        <Grid container >
          <Route path="/accounts/add" render={() => (<AddPage auth={auth} />)} />
          <Dashboard auth={auth} dashboard={dashboard} setAccounts={setAccounts} />
        </Grid>
      );
    }
    else {
      return (
        <Grid container>
          <LinearProgress style={{ flexGrow: 1 }} color="secondary" />
        </Grid>
      );
    }
  }
}

const mapStateToProps = store => {
  return {
    auth: store.auth,
    dashboard: store.dashboard,
    authTab: store.authTab
  }
}

const mapDispatchToProps = dispatch => ({
  setAuthAction: auth => dispatch(setAuth(auth)),
  setTabAction: value => dispatch(setTab(value)),
  setAccounts: accounts => dispatch(setAccounts(accounts)),
})

export default connect(
  mapStateToProps,
  mapDispatchToProps
)(App)