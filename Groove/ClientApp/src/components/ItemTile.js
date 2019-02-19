import React, { Component } from 'react';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import Fab from '@material-ui/core/Fab';
import AddIcon from '@material-ui/icons/Add';

export class ItemTile extends Component {
  displayName = ItemTile.name
  constructor(props) {
    super(props);
    this.state = { isSuccess: false, loading: true };
    this.oauthHandle = this.oauthHandle.bind(this);
  }
  oauthHandle(event)
{
  var newWindow = window.open('https://oauth.vk.com/authorize?client_id=6854870&display=page&redirect_uri=http://localhost:54096/api/accounts/add&scope=offline&response_type=code&v=5.92', 'name', 'height=350,width=700');
    if (window.focus) {
      newWindow.focus();
    }
}

  render() {
    return (
    <Grid item xs={3} >
     <Paper elevation={1} style={{height: 150}}> 
     <Fab style={{margin: 5}} size="small" onClick={this.oauthHandle} color="secondary" aria-label="Add">
        <AddIcon />
      </Fab>
      </Paper>
      </Grid>
    );
  }
}

