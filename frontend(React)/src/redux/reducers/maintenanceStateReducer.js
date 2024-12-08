import initialState from "./initialState"
import * as maintenanceStateActionTypes from "../actions/maintenanceStateActionTypes"
function maintenanceStateReducer(state = initialState.maintenanceStateData, action) {
switch (action.type) {
    
    case maintenanceStateActionTypes.GET_MAINTENANCE_STATE_LIST_SUCCESS:
        return {
            ...state,
            maintenanceStateItem : action.payload.items,
            error : null,
            
        };
    case maintenanceStateActionTypes.GET_MAINTENANCE_STATE_LIST_FAILURE:
        return{
            ...state,
            maintenanceStateItem:[],
            error: action.payload
        };

    default:
        return state;
}
}

export default maintenanceStateReducer;