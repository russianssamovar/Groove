import { SET_ACCOUNTS } from '../actions/DashboardActions'

const initialState = {
    accounts: [],
    isLoading: true
  }
  
  export function dashboardReducer(state = initialState, action) {
    switch (action.type) {
      case SET_ACCOUNTS:
        return { ...state, accounts: action.payload.accounts, isLoading: action.payload.isLoading}
  
      default:
        return state
    }
  }