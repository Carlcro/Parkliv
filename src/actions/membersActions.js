import * as types from './actionTypes';
import axios from 'axios';
import {
  beginAjaxCall
} from './ajaxStatusActions';

export function loadMembersSuccess(members) {
  return {
    type: types.LOAD_MEMBERS_SUCCESS,
    members
  };
}

export function createMemberSuccess(member) {
  return {
    type: types.SAVED_MEMBER_SUCCESS,
    member
  };
}

export function updateMemberSuccess(member) {
  return {
    type: types.UPDATE_MEMBER_SUCCESS,
    member
  };
}

export function deleteMemberSuccess(member) {
  return {
    type: types.DELETE_MEMBER_SUCESS,
    member
  }
}

export function loadMembers() {

  return function (dispatch) {
    dispatch(beginAjaxCall());
    fetch('/api/members')
      .then(result => {
        result.json()
          .then(members => {
            dispatch(loadMembersSuccess(members));
          });
      })
      .catch(error => {
        throw (error);
      });
  };
}

export function saveMember(member) {
  return function (dispatch) {
    dispatch(beginAjaxCall());
    axios.post('/api/members', {
        fname: member.fname,
        lname: member.lname,
        description: member.description
      })
      .then(savedMember => {
        dispatch(createMemberSuccess(savedMember.data));
      })
      .catch(error => {
        throw (error);
      });
  };
}

export function updateMember(member) {
  return function (dispatch) {
    axios.put('/api/members/' + member.id, {
        member
      })
      .then(savedMember => {
        dispatch(updateMemberSuccess(savedMember));
      })
      .catch(error => {
        throw (error);
      });
  };
}

export function deleteMember(member) {
  return function (dispatch) {
    debugger;
    axios.delete('/api/members/' + member.id)
      .then(() => {
        dispatch(deleteMemberSuccess(member));
      })
      .catch(error => {
        throw (error);
      });
  };
}
