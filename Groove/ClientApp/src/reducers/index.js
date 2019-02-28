import { combineReducers } from 'redux'
import { autentificationReducer } from './Autentification'
import { dashboardReducer } from './Dashboard'
import { authTabsReducer } from './AuthTabs'

export const rootReducer = combineReducers({
  auth: autentificationReducer,
  dashboard: dashboardReducer,
  authTab: authTabsReducer,
})