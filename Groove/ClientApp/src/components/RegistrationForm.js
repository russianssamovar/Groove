import React, { Component } from 'react';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';
import RaisedButton from 'material-ui/RaisedButton';
import { LinkContainer } from 'react-router-bootstrap';
import TextField from 'material-ui/TextField';
import Grid from '@material-ui/core/Grid';

export class RegistrationForm extends Component {
render() {
    return (
        <MuiThemeProvider>
          <form>
             <TextField
             hintText="First Name"
             floatingLabelText="First Name"
             style = {{width: 160}}
             required
             />
             <TextField
               hintText="Last name"
               floatingLabelText="Last Name"
               style = {{width: 160}}
               required
               />
          <Grid item xs={12}>
             <TextField
               hintText="Email"
               floatingLabelText="Email"
               margin="normal"
               fullWidth={true}
               required
               />
             <br/>
             <TextField
               hintText="Confirm Email"
               floatingLabelText="Confirm Email"
               margin="normal"
               fullWidth={true}
               required
               />
             <br/>
             <TextField
               type="Password"
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