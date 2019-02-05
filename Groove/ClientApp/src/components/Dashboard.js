import React, { Component } from 'react';
import { Route } from 'react-router';
import { NavBar } from './NavBar';
import { Col, Grid, Row } from 'react-bootstrap';
import {DashBoardLayout} from './DashBoardLayout';
import {Counter} from './Counter';
import {FetchData} from './FetchData';


export class Dashboard extends Component {
  displayName = Dashboard.name

  render() {
    return (
      <Grid fluid>
      <Row>
        <Col sm={3}>
        <NavBar/>
        </Col>
        <Col sm={9}>
          <DashBoardLayout>
            <Route exact path='/dashboard/counter' component={Counter} />
            <Route path='/dashboard/fetchData' component={FetchData}/>
          </DashBoardLayout>
        </Col>
      </Row>
    </Grid>
    );
  }
}
