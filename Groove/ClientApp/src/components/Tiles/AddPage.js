import React, { Component } from 'react';
import Cookies from 'js-cookie';
import axios from 'axios';

export default class AddPage extends Component {
  displayName = AddPage.name

  render() {
    const { auth } = this.props
    var config = {
      headers: { 'Authorization': "bearer " + auth.token }
    };
    var urlParams = new URLSearchParams(window.location.search);
    axios.post('/api/accounts/add',
      {
        code: urlParams.get('code')
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


