import React, { Component } from 'react';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';
import RaisedButton from 'material-ui/RaisedButton';
import { LinkContainer } from 'react-router-bootstrap';
import TextField from 'material-ui/TextField';
import Grid from '@material-ui/core/Grid';

export class RegistrationForm extends Component {
  constructor(props) {
    super(props);
    this.state = { isSuccess: false, loading: true };
    this.handleSubmit = this.handleSubmit.bind(this);
  }
  handleSubmit(event) {
    event.preventDefault();
    const data = new FormData(event.target);
    fetch('/api/identity/registration', {
      method: 'POST',
      body: data,
    }).then(response => response.json())
    .then(data => {
      this.state.isSuccess = data;
    }).then(res => {
      if(this.state.isSuccess)
      {
        window.location.href = "/dashboard";
      }
      else
      {
        alert("Email alredy used");
      }});
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
             <LinkContainer to={'/dashboard'}>
                  <RaisedButton label="Submit" primary={true} onClick={(event) => this.handleClick(event)}/>
            </LinkContainer>
         </Grid>
         </form>
         </MuiThemeProvider>
         
    );
  }
}
export default RegistrationForm;