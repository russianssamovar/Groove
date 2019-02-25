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
    
    var urlParams = new URLSearchParams(window.location.search);
    axios.post('/api/accounts/add', 
    {
        code: urlParams.get('code')
    },
     config
      ).then((response) =>
      {
        window.close();
      })
      .catch(error => {
        if (error.response.status === 401 || error.response.status === 403) {
          Cookies.remove('token');
          window.location.replace("/");
        }
    });

    return (
      <div>in progress...</div>
    );
  }
}


