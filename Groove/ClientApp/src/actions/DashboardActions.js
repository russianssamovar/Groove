export const SET_ACCOUNTS = 'SET_ACCOUNTS'
export const SET_GROUPS = 'SET_GROUPS'


export function setAccounts(value) {
    return {
      type: SET_ACCOUNTS,
      payload: value,
    }
  }

  export function setGroups(value) {
    return {
      type: SET_GROUPS,
      payload: value,
    }
  }