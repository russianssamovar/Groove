import React, { Component } from 'react';
import {AddAccountTile} from './AddAccountTile';
import axios from 'axios';
import Cookies from 'js-cookie';
import Grid from '@material-ui/core/Grid';
import AccountTile from './AccountTile';

export class ItemTiles extends Component {
  displayName = ItemTiles.name
  constructor(props) {
    super(props);
    this.state = { accounts: [] };
  }
  componentDidMount()
  {
    var token = Cookies.get('token');
    if(token == null)
    {
     window.location.replace("/");
    }
    axios.get('/api/accounts/list', { headers: { Authorization: "bearer " + token } }
      ).then((response) =>
      {
        this.setState({accounts: response.data.accounts});
      })
      .catch((error) => {
        console.log(error);
        if (error.response.status === 401 || error.response.status === 403) {
          Cookies.remove('token');
          window.location.replace("/");
        }
    });
  }
  render() {
   console.log(this.state.accounts)
    return (
     
    <Grid container item xs={12} spacing={16}>
         {this.state.accounts.map(account => (
            <AccountTile key={account.accessToken} account={account}/>
          ))
         }  
        <AddAccountTile/>
      </Grid>
    );
  }
}

