﻿import React, { Component } from 'react';
import MenuList from '@material-ui/core/MenuList';
import MenuItem from '@material-ui/core/MenuItem';
import Paper from '@material-ui/core/Paper';
import { withStyles } from '@material-ui/core/styles';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import InboxIcon from '@material-ui/icons/MoveToInbox';
import DraftsIcon from '@material-ui/icons/Drafts';
import SendIcon from '@material-ui/icons/Send';
import { LinkContainer } from 'react-router-bootstrap';

const styles = theme => ({
  menuItem: {
    '&:focus': {
      backgroundColor: theme.palette.primary.main,
      '& $primary, & $icon': {
        color: theme.palette.common.white,
      },
    },
  },
  primary: {},
  icon: {},
});

export class NavBar extends Component {
  displayName = NavBar.name

  render() {
    return (
        <Paper>
        <MenuList>
        <LinkContainer to={'/dashboard'}>
          <MenuItem>
            <ListItemIcon>
              <SendIcon />
            </ListItemIcon>
                <ListItemText inset primary="Accounts" />
          </MenuItem>
          </LinkContainer>
          <LinkContainer to={'/dashboard/groups'}>
          <MenuItem>
            <ListItemIcon>
              <DraftsIcon />
            </ListItemIcon>
                <ListItemText inset primary="Groups" />
          </MenuItem>
          </LinkContainer>
          <LinkContainer to={'/dashboard/reports'}>
          <MenuItem >
            <ListItemIcon>
              <InboxIcon />
            </ListItemIcon>
                <ListItemText inset primary="Reports" />
          </MenuItem>
          </LinkContainer>
        </MenuList>
      </Paper>
    );
  }
}

export default withStyles(styles)(NavBar);