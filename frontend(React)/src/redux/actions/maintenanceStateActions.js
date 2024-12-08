import apiHelper from "../helper/apiHelper";
import * as maintenanceStateActionTypes from "./maintenanceStateActionTypes"

export function handleGetMaintenanceStateListSuccess(data)
 {
    return{type: maintenanceStateActionTypes.GET_MAINTENANCE_STATE_LIST_SUCCESS, payload: data}
 }

 export function handleGetMaintenanceStateListFailure(error)
 {
    return{type: maintenanceStateActionTypes.GET_MAINTENANCE_STATE_LIST_SUCCESS, payload: error}
 }

// Bakım Durum Listesini API'den alma
export const handleGetMaintenanceStateList = () => {
    return async(dispatch) => {
        const url = "http://localhost:60805/api/MaintenanceStates?PageIndex=0&PageSize=999";
        const method = "GET";
        try {
                const data = await apiHelper({url, method});
                dispatch(handleGetMaintenanceStateListSuccess(data));
            }
         catch (error) {
           dispatch(handleGetMaintenanceStateListFailure(error.message));
            }
        }
    };