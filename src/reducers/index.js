import { combineReducers } from 'redux';
import { routerReducer } from 'react-router-redux';
import members from './memberReducer';
import ajaxCallsInProgress from './ajaxStatusReducer';

const rootReducer = combineReducers({
  members: members,
  routing: routerReducer,
  ajaxCallsInProgress: ajaxCallsInProgress
});

export default rootReducer;
