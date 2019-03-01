export const SET_ACCOUNTS = 'SET_ACCOUNTS'


export function setAccounts(value) {
    return {
      type: SET_ACCOUNTS,
      payload: value,
    }
  }