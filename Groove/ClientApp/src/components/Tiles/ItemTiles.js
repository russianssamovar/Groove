import React, { Component } from 'react';
import { AddAccountTile } from './AddAccountTile';
import Grid from '@material-ui/core/Grid';
import AccountTile from './AccountTile';
import GroupTile from './GropTile';
import CircularProgress from '@material-ui/core/CircularProgress';
import Paper from '@material-ui/core/Paper';

export class ItemTiles extends Component {
  displayName = ItemTiles.name

  componentDidMount() {
    switch (window.location.pathname) {
      case "/groups":
        var url = new URL(window.location);
        var accId = url.searchParams.get("accountId");
        this.props.setGroups({token: this.props.auth.token, accId: accId});
        break;
      default:
        this.props.setAccounts({token: this.props.auth.token});
    }
  }

  render() {
    const { dashboard } = this.props
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
      switch (window.location.pathname) {
        case "/groups":
          return (
            <Grid container item xs={12} spacing={16}>
              {dashboard.groups.map(group => (
                <GroupTile key={account.accessToken} group={group} />
              ))
              }
            </Grid>
          );
        default:
          return (
            <Grid container item xs={12} spacing={16}>
              {dashboard.accounts.map(account => (
                <AccountTile key={account.accessToken} account={account} setGroups={this.props.setGroups} />
              ))
              }
              <AddAccountTile />
            </Grid>
          );
      }
    }
  }
}
