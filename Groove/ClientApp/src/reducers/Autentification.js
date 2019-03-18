import { SET_AUTH } from '../actions/AuthActions'

const initialState = {
    token: '',
    username: 'Unknow',
    userId: 0,
    message: "",
    isLogin: false,
    isLoading: true,
}
  
  export function autentificationReducer(state = initialState, action) {
    switch (action.type) {
      case SET_AUTH:
        return {...state, token: action.payload.access_token, isLogin: action.payload.isLogin, username: action.payload.username, isLoading: action.payload.isLoading, userId: action.payload.userId, message: action.payload.message}
      default:
        return state
    }
  }