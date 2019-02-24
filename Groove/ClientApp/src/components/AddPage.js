import React, { Component } from 'react';
import Cookies from 'js-cookie';
import axios from 'axios';

export class AddPage extends Component {
  displayName = AddPage.name

  constructor(props) {
    super(props);
  }

  render() {

    var token = Cookies.get('token');
    if(token == null)
    {
     window.location.replace("/");
    }
    var config = {
        headers: {'Authorization': "bearer " + token}
    };
    axios.post('/api/accounts/add', 
    {
        code:"aaaaaaaaaaa"
    },
     config
      ).then((response) =>
      {
        window.close();
      });

    return (
      <div>in progress...</div>
    );
  }
}


