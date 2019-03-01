import { SET_TAB } from '../actions/AuthTabsActions'

const initialState = {
   value: 0
  }
  
  export function authTabsReducer(state = initialState, action) {
    switch (action.type) {
      case SET_TAB:
        return { ...state, value: action.payload }
  
      default:
        return state
    }
  }