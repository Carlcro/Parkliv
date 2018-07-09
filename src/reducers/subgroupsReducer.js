import initialState from './initialState';
import * as types from '../actions/actionTypes';
export default function subgroupReducer(state = initialState.subgroup, action){
    switch (action.types){
        case types.LOAD_SUBGROUPS_SUCCESS:
            return action.subgroup; 

            default:
                return state;
    }  

}