import * as statusActionsTypes from '../actions/statusActionsTypes'
import initialState from "./initialState"

function statusReducer(state = initialState.statusData, action) {
    switch (action.type) {
        case statusActionsTypes.GET_STATUS_LIST_SUCCESS:
            return {
                ...state,
                status: action.payload.items, // 'items' içinde olduğunu varsayıyoruz
                error: null,
            }; 
        case statusActionsTypes.GET_STATUS_LIST_FAILURE:
            return {
                ...state,
                status: [], // 'items' içinde olduğunu varsayıyoruz
                error: action.payload,
                };     
            
        default:
            return state;
    }
}

export default statusReducer;