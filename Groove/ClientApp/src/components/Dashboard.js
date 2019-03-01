import React, { Component } from 'react';
import { Route } from 'react-router';
import { NavBar } from './NavBar';
import { DashBoardLayout } from './DashBoardLayout';
import { ItemTiles } from './Tiles/ItemTiles';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import Grid from '@material-ui/core/Grid';

export class Dashboard extends Component {
  displayName = Dashboard.name

  render() {
    const { dashboard, auth, setAccounts} = this.props
    console.log(dashboard);
    return (
      <Grid container spacing={24}>
        <Grid item xs={12}>
          <AppBar color="primary" position="static">
            <Toolbar>
              <Typography variant="h6" color="inherit">
                Groove
              </Typography>
            </Toolbar>
          </AppBar>
        </Grid>
        <Grid item xs={3}>
          <NavBar />
        </Grid>
        <Grid item xs={9}>
          <DashBoardLayout>
            <Route exact path='/' render={()=><ItemTiles  auth={auth} dashboard={dashboard} setAccounts={setAccounts}/>} />
          </DashBoardLayout>
        </Grid>
      </Grid>
    );
  }
}
