import { SET_ACCOUNTS, SET_GROUPS } from '../actions/DashboardActions'

const initialState = {
  accounts: [],
  groups: [],
  isLoading: true
}

export function dashboardReducer(state = initialState, action) {
  var config = {
    headers: { 'Authorization': "bearer " + action.payload.token }
  };
  switch (action.type) {
    case SET_ACCOUNTS:
    axios.get('/api/accounts/list?accountId='+action.payload.accId, config)
          .then((response) => {
            return { ...state, accounts: response.data.accounts, isLoading: false }
          })
          .catch((error) => {
            console.log(error);
          });

          case SET_GROUPS:
      axios.get('/api/groups/list', config)
        .then((response) => {
          return { ...state, groups: response.data.groups, isLoading: false }
        })
        .catch((error) => {
          console.log(error);
        });
    default:
      return state
  }
}