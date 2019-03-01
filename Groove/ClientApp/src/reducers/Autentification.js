const initialState = {
    token: '',
    username: 'Unknow',
    isLogin: false,
    isLoading: true,
}
  
  export function autentificationReducer(state = initialState, action) {
    switch (action.type) {
      case 'SET_AUTH':
        return {...state, token: action.payload.access_token, isLogin: action.payload.isLogin, username: action.payload.username, isLoading: action.payload.isLoading}
      default:
        return state
    }
  }