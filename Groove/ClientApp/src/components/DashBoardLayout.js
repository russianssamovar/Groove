import React, { Component } from 'react';
import { Grid } from 'react-bootstrap';

export class DashBoardLayout extends Component {
  displayName = DashBoardLayout.name

  render() {
    return (
      <Grid fluid>
          {this.props.children}
    </Grid>
    );
  }
}
