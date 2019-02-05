import React, { Component } from 'react';
import { Col, Grid, Row } from 'react-bootstrap';

export class Root extends Component {
  displayName = Root.name

  render() {
    return (
      <Grid fluid>
            {this.props.children}
      </Grid>
    );
  }
}
