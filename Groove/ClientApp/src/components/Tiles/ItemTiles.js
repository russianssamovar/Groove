import React, { Component } from 'react';
import { AddAccountTile } from './AddAccountTile';
import axios from 'axios';
import Grid from '@material-ui/core/Grid';
import AccountTile from './AccountTile';
import CircularProgress from '@material-ui/core/CircularProgress';
import Paper from '@material-ui/core/Paper';

export class ItemTiles extends Component {
  displayName = ItemTiles.name

  componentDidMount() {
    var config = {
      headers: { 'Authorization': "bearer " + this.props.auth.token }
    };
    axios.get('/api/accounts/list', config)
      .then((response) => {
        this.props.setAccounts({ accounts: response.data.accounts, isLoading: false });
      })
      .catch((error) => {
        console.log(error);
      });
  }

  render() {
    const { dashboard } = this.props
    console.log(dashboard.accounts);

    if (dashboard.isLoading) {
      return (
        <Grid container item xs={12} spacing={16}>
          <Grid item xs={3}>
            <Paper elevation={1} style={{ height: 150 }}>
              <CircularProgress style={{ marginLeft: 60, marginTop: 50 }} color="secondary" />
            </Paper>
          </Grid>
          <AddAccountTile />
        </Grid>
      );
    }
    else {
      return (
        <Grid container item xs={12} spacing={16}>
          {dashboard.accounts.map(account => (
            <AccountTile key={account.accessToken} account={account} />
          ))
          }
          <AddAccountTile />
        </Grid>
      );
    }
  }
}

