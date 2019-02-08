import React, { Component } from 'react';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import Icon from '@material-ui/core/Icon';

export class ItemTile extends Component {
  displayName = ItemTile.name

  render() {
    return (
    <Grid item xs={3} >
     <Paper elevation={1} style={{height: 150}}> ;
        <Icon color="secondary" fontSize="large" style={{textAlign: "center"}}>
            add_circle
          </Icon>
      </Paper>
      </Grid>
    );
  }
}
