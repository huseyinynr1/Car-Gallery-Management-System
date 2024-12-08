import initialState from "./initialState"
import * as maintenanceTypeActionTypes from "../actions/maintenanceTypeActionTypes"
function maintenanceTypeReducer ( state = initialState.maintenanceTypeData, action){
    switch (action.type) {
        case maintenanceTypeActionTypes.GET_MAINTENANCE_TYPE_LIST_SUCCESS :
            return {
                ...state,
                maintenanceTypeItem: action.payload.items,
                error : null,
            }
        case maintenanceTypeActionTypes.GET_MAINTENANCE_TYPE_LIST_FAILURE:
            return {
                ...state,
                maintenanceTypeItem : [],
                error : action.payload
            }
    
        default:
            return state ;
    }
}
export default maintenanceTypeReducer ; 