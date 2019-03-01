export const SET_AUTH = 'SET_AUTH'

export function setAuth(auth) {
    return {
      type: SET_AUTH,
      payload: auth,
    }
  }