import React from 'react';
import PropTypes from 'prop-types';
import AppBar from '@material-ui/core/AppBar';
import Tabs from '@material-ui/core/Tabs';
import Tab from '@material-ui/core/Tab';
import Typography from '@material-ui/core/Typography';
import RegistrationForm from './RegistrationForm'
import LoginForm from './LoginForm'
import Grid from '@material-ui/core/Grid';

function TabContainer(props) {
  return (
    <Typography component="div">
      {props.children}
    </Typography>
  );
}

TabContainer.propTypes = {
  children: PropTypes.node.isRequired,
};

export class LoginTabsLayout extends React.Component {
  handleChange = (event, value) => {
    this.props.setTab(value);
  };
  render() {
    const { authTab, auth, setAuth } = this.props
    return (
      <Grid container justify="center" alignItems="center" style={{ minHeight: '100vh' }} item xs={12}>
        <div>
          <AppBar position="static" color="primary">
            <Tabs value={authTab.value} onChange={this.handleChange} centered>
              <Tab label="Login" />
              <Tab label="Registration" />
            </Tabs>
          </AppBar>
          <Grid container spacing={24}>
            {authTab.value === 0 && <Grid item xs={12}><TabContainer><LoginForm auth={auth} setAuth={setAuth}/></TabContainer></Grid>}
            {authTab.value === 1 && <Grid item xs={12}><TabContainer><RegistrationForm auth={auth} setAuth={setAuth}/></TabContainer></Grid>}
          </Grid>
        </div>
      </Grid>
    );
  }
}

export default LoginTabsLayout;
