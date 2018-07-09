import * as types from './actionTypes';
import axios from 'axios';
import {beginAjaxCall} from './ajaxStatusActions';

export function loadSubgroupsSuccess(subgroups){
  return { type: types.LOAD_SUBGROUPS_SUCCESS, subgroups};
}

export function loadSubgroups(){
  return function (dispatch) {
    dispatch(beginAjaxCall());
    axios.get('/api/subgroups')
    .then(result => {result.json();})
    .then(subgroups => {dispatch(loadSubgroupsSuccess(subgroups));})
    .catch(error => {throw(error);});};}