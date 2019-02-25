import React, { Component } from 'react';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import FormLabel from '@material-ui/core/FormLabel';

export class AccountTile extends Component {
  displayName = AccountTile.name

  constructor(props) {
    super(props);
  }

  render() {
    return (
    <Grid item xs={3} >
     <Paper elevation={1} style={{height: 150}}> 
     <FormLabel>{this.props.account.accessToken}</FormLabel>
      </Paper>
      </Grid>
    );
  }
}
export default AccountTile;

