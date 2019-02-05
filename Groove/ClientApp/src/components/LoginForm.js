import React, { Component } from 'react';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';
import RaisedButton from 'material-ui/RaisedButton';
import { LinkContainer } from 'react-router-bootstrap';
import TextField from 'material-ui/TextField';
import Grid from '@material-ui/core/Grid';

export class LoginForm extends Component {
constructor(props){
  super(props);
  this.state={
  username:'',
  password:''
  }
 }
render() {
    return (
      <div>
        <MuiThemeProvider>
        <form>
          <div>
           <TextField
             hintText="Enter your Username"
             floatingLabelText="Username"
             onChange = {(event,newValue) => this.setState({username:newValue})}
             fullWidth={true}
             required
             />
           <br/>
             <TextField
               type="password"
               hintText="Enter your Password"
               floatingLabelText="Password"
               onChange = {(event,newValue) => this.setState({password:newValue})}
               fullWidth={true}
               required
               />
             <br/>
             <Grid
                justify="space-between" 
                container 
                spacing={2}
                margin="15"
                >
             <LinkContainer to={'/dashboard'}>
                  <RaisedButton label="Submit" primary={true} onClick={(event) => this.handleClick(event)}/>
            </LinkContainer>
            </Grid>
         </div>
         </form>
         </MuiThemeProvider>
      </div>
    );
  }
}
export default LoginForm;

  