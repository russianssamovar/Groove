const initialState = {
    token: '',
    username: 'Unknow',
    isLogin: false,
  }
  
  export function autentificationReducer(state = initialState, action) {
    switch (action.type) {
      case 'SET_AUTH':
        return {...state, token: action.payload.access_token, isLogin: true, username: action.payload.username}
  
      default:
        return state
    }
  }