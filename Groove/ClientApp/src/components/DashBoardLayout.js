import React, { Component } from 'react';
import { Col, Grid, Row } from 'react-bootstrap';

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
