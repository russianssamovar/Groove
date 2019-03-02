import React, { Component } from 'react';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import Fab from '@material-ui/core/Fab';
import AddIcon from '@material-ui/icons/Add';
import Menu from '@material-ui/core/Menu';
import MenuItem from '@material-ui/core/MenuItem';

export class AddAccountTile extends Component {
  displayName = AddAccountTile.name
  constructor(props) {
    super(props);
    this.state = { isSuccess: false, loading: true, anchorEl: null };
    this.oauthHandle = this.oauthHandle.bind(this);
    this.handleClick = this.handleClick.bind(this);
  }

  handleClick (event) {
    this.setState({ anchorEl: event.currentTarget });
  };

  oauthHandle(link)
{
  var newWindow = window.open(link, 'name', 'height=350,width=700');
    if (window.focus) {
      newWindow.focus();
    }
    this.setState({ anchorEl: null });
};

  render() {
    const { anchorEl } = this.state;
    const open = Boolean(anchorEl);

    return (
    <Grid item xs={3} >
     <Paper elevation={1} style={{height: 150}}> 
     <Fab style={{margin: 5}} size="small" onClick={this.handleClick} color="secondary" aria-label="Add" aria-owns={open ? 'long-menu' : undefined} aria-haspopup="true">
        <AddIcon />
      </Fab>
      <Menu
          id="long-menu"
          anchorEl={anchorEl}
          open={open}
          onClose={this.oauthHandle}
          PaperProps={{
            style: {
              maxHeight: 48 * 4.5,
              width: 200,
            },
          }}>
            <MenuItem onClick={() => this.oauthHandle("https://oauth.vk.com/authorize?client_id=6854870&display=page&redirect_uri=" + window.location.host + "/accounts/add&groups,stats,offline&response_type=token&v=5.92")}>Vk</MenuItem>
            <MenuItem onClick={() => this.oauthHandle("https://oauth.vk.com/authorize?client_id=6854870&display=page&redirect_uri=" + window.location.host + "/accounts/add&scope=offline&response_type=token&v=5.92")}>Instagram</MenuItem>
            <MenuItem onClick={() => this.oauthHandle("https://oauth.vk.com/authorize?client_id=6854870&display=page&redirect_uri=" + window.location.host + "/accounts/add&scope=offline&response_type=token&v=5.92")}>Test2</MenuItem>
        </Menu>
      </Paper>
      </Grid>
    );
  }
}

