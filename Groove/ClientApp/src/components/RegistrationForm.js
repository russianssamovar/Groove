import React, { Component } from 'react';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';
import RaisedButton from 'material-ui/RaisedButton';
import { LinkContainer } from 'react-router-bootstrap';
import TextField from 'material-ui/TextField';
import Grid from '@material-ui/core/Grid';
import axios from 'axios';
import Cookies from 'js-cookie';
import FormLabel from '@material-ui/core/FormLabel';
import "./LoginForm.css";

export class RegistrationForm extends Component {
  constructor(props) {
    super(props);
    this.state = { isSuccess: false, isHidden: true, message: "" };
    this.handleSubmit = this.handleSubmit.bind(this);
  }
  handleSubmit(event) {
    event.preventDefault();
    axios.post('/api/identity/registration', {
      login: event.target.email.value,
      confirmEmail: event.target.confirmEmail.value,
      password: event.target.password.value,
      confirmPassword: event.target.confirmPassword.value
    }).then((response) =>
    {
      if(response.data.access_token != "")
      {
        Cookies.set('token', response.data.access_token);
      }
      else
      {
        alert(response.data.message);
        this.setState(
          {
            isHidden: false, 
            message: response.data.message
          }
        );
      }
    })
  }

render() {
    return (
        <MuiThemeProvider>
          <form onSubmit={this.handleSubmit}>
          <Grid item xs={12}>
             <TextField
               hintText="Email"
               name="email"
               floatingLabelText="Email"
               margin="normal"
               fullWidth={true}
               required
               />
             <br/>
             <TextField
               hintText="Confirm Email"
               name="confirmEmail"
               floatingLabelText="Confirm Email"
               margin="normal"
               fullWidth={true}
               required
               />
             <br/>
             <TextField
               type="Password"
               name="password"
               hintText="Password"
               floatingLabelText="Password"
               margin="normal"
               fullWidth={true}
               required
               />
             <br/>
             <TextField
               type="Confirm Password"
               hintText="Password"
               name="confirmPassword"
               floatingLabelText="Confirm Password"
               margin="normal"
               fullWidth={true}
               required
               />
             <br/>
             <RaisedButton type="submit" label="Submit" primary={true}/>
         </Grid>
         <FormLabel className={this.state.isHidden ? 'hidden' : 'nonHidden'} error="true">
                {this.state.message}
            </FormLabel>
         </form>
         </MuiThemeProvider>
         
    );
  }
}
export default RegistrationForm;