import apiHelper from "../helper/apiHelper";
import * as maintenanceTypeActionTypes from "./maintenanceTypeActionTypes";

export function handleGetMaintenanceTypeListSuccess(data){
    return{type: maintenanceTypeActionTypes.GET_MAINTENANCE_TYPE_LIST_SUCCESS, payload:data}
}

export function handleGetMaintenanceTypeListFailure(error){
    return{type: maintenanceTypeActionTypes.GET_MAINTENANCE_TYPE_LIST_FAILURE, payload:error}
}
// Bakım tipi listesini API' den alma.
export const handleGetMaintenanceTypeList = () => {
      return async(dispatch) =>{
        const url = "http://localhost:60805/api/MaintenanceTypes?PageIndex=0&PageSize=999";
        const method = "GET";
        try {
            const data = await apiHelper({url, method});
            dispatch(handleGetMaintenanceTypeListSuccess(data));
        } catch (error) {
            dispatch(handleGetMaintenanceTypeListFailure(error.message));
        }
      }
}