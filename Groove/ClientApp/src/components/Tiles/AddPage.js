import React, { Component } from 'react';
import axios from 'axios';

export default class AddPage extends Component {
  displayName = AddPage.name

  render() {
    const { auth } = this.props
    var config = {
      headers: { 'Authorization': "bearer " + auth.token }
    };
    axios.post('/api/accounts/add',
      {
        parametrs: window.location.hash
      },
      config
    ).then(() => {
      window.close();
    })
      .catch(error => {
        console.log(error);
      });
    return (
      <div>in progress...</div>
    );
  }
}


