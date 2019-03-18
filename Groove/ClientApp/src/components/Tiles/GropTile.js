import React, { Component } from 'react';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import FormLabel from '@material-ui/core/FormLabel';
import Avatar from '@material-ui/core/Avatar';
import Group from '@material-ui/icons/Group';
import Settings from '@material-ui/icons/Settings';
import MoreIcon from '@material-ui/icons/More';
import Menu from '@material-ui/core/Menu';
import Fab from '@material-ui/core/Fab';
import MenuItem from '@material-ui/core/MenuItem';

export class GroupTile extends Component {
  displayName = GroupTile.name

  constructor(props) {
    super(props);
    this.state = { anchorEl: null };
    this.handleClick = this.handleClick.bind(this);
    this.closeHandle = this.closeHandle.bind(this);
  }

  handleClick (event) {
    this.setState({ anchorEl: event.currentTarget });
  };
  closeHandle(event)
  {
    this.setState({ anchorEl: null });
  };
  render() {
    const { anchorEl } = this.state;
    const open = Boolean(anchorEl);

    return (
      <Grid item xs={3} direction="row" justify="center" alignItems="center">
        <Paper elevation={1} style={{ height: 140, padding: 5 }}>
          <Grid container>
            <Grid item xs={3}>
              <Avatar alt={this.props.group.name} style={{ width: 45, height: 45 }} />
            </Grid>
            <Grid style={{ marginTop: 10 }} item xs={6}>
              <FormLabel filled={true} >{this.props.group.name}</FormLabel>
            </Grid>
            <Grid item xs={3}>
            <Fab style={{ margin: 5 }} size="small" onClick={this.handleClick} color="secondary" aria-label="Add" aria-owns={open ? 'long-menu' : undefined} aria-haspopup="true">
                <MoreIcon />
              </Fab>
              <Menu
                id="long-menu"
                anchorEl={anchorEl}
                open={open}
                onClose={this.closeHandle}
                PaperProps={{
                  style: {
                    maxHeight: 48 * 4.5,
                    width: 200,
                  },
                }}>
                <MenuItem><Group style={{ marginRight: 10 }}>Group</Group>Group</MenuItem>
                <MenuItem><Settings style={{ marginRight: 10 }}>Settings</Settings>Settings</MenuItem>
              </Menu>
            </Grid>
          </Grid>
        </Paper>
      </Grid>
    );
  }
}
export default GroupTile;

