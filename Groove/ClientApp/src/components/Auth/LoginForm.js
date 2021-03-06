import React, { Component } from 'react';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';
import RaisedButton from 'material-ui/RaisedButton';
import TextField from 'material-ui/TextField';
import Grid from '@material-ui/core/Grid';
import axios from 'axios';
import Cookies from 'js-cookie';
import FormLabel from '@material-ui/core/FormLabel';
import "./LoginForm.css";

export class LoginForm extends Component {
  constructor(props) {
    super(props);
    this.state = { isSuccess: false, isHidden: true };
    this.handleSubmit = this.handleSubmit.bind(this);
  }
  handleSubmit(event) {
    event.preventDefault();
    axios.post('/api/identity/token', {
      login: event.target.login.value,
      password: event.target.password.value
    }).then((response) => {
      if (response.data !== null && response.data.accessToken !== "") {
        this.props.setAuth({access_token: response.data.accessToken, isLogin: true, username: response.data.userName, userId: response.data.userId, message: response.data.message, isLoading: false});
        Cookies.set('token', response.data.accessToken);
      }
      else {
        this.props.setAuth({access_token: response.data.accessToken, isLogin: false, username: response.data.userName, userId: response.data.userId, message: response.data.message, isLoading: false});
        this.setState({ isHidden: false });
      }
    })
  }

  render() {
    return (
      <div>
        <MuiThemeProvider>
          <form onSubmit={this.handleSubmit}>
            <div>
              <TextField
                id="login"
                name="login"
                hintText="Enter your email"
                floatingLabelText="email"
                onChange={(event, newValue) => this.setState({ email: newValue })}
                fullWidth={true}
                required
              />
              <br />
              <TextField
                id="password"
                name="password"
                type="password"
                hintText="Enter your Password"
                floatingLabelText="Password"
                onChange={(event, newValue) => this.setState({ password: newValue })}
                fullWidth={true}
                required
              />
              <br />
              <Grid
                justify="space-between"
                container
                spacing={8}
                margin="15"
              >
                <RaisedButton type="submit" label="Submit" primary={true} />
              </Grid>
              <FormLabel className={this.state.isHidden ? 'hidden' : 'nonHidden'} error={true}> {this.props.message}</FormLabel>
            </div>
          </form>
        </MuiThemeProvider>
      </div>
    );
  }
}
export default LoginForm;

