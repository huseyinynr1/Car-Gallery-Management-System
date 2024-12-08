import apiHelper from "../helper/apiHelper";
import * as maintenanceRecordsActionTypes from "./maintenanceActionTypes";

export function createMaintenanceRecordSuccess(data) {
  return {
    type: maintenanceRecordsActionTypes.CREATE_MAINTENANCE_RECORD_SUCCESS,
    payload: data,
  };
}

export function createMaintenanceRecordFailure(error) {
  return {
    type: maintenanceRecordsActionTypes.CREATE_MAINTENANCE_RECORD_FAILURE,
    payload: error,
  };
}

export const createMaintenanceRecord = (newRecord) => {
  return async (dispatch) => {
    const url = "http://localhost:60805/api/MaintenanceRecords";
    const method = "POST";
    const body = newRecord;
    try {
      const data = await apiHelper({ url, method, body });
      dispatch(createMaintenanceRecordSuccess(data));
    } catch (error) {
      dispatch(createMaintenanceRecordFailure(error.message));
    }
  };
};


export function createMaintenancePlanningRecordSuccess(data) {
  return {
    type: maintenanceRecordsActionTypes.CREATE_MAINTENANCE_PLANNING_RECORD_SUCCESS,
    payload: data,
  };
}

export function createMaintenancePlanningRecordFailure(error) {
  return {
    type: maintenanceRecordsActionTypes.CREATE_MAINTENANCE_PLANNING_RECORD_FAILURE,
    payload: error,
  };
}


export const createMaintenancePlanningRecord = (newRecord) => {
  return async (dispatch) => {
    const url = "http://localhost:60805/api/MaintenancePlanningRecords";
    const method = "POST";
    const body = newRecord;
    try {
      const data = await apiHelper({ url, method, body });
      dispatch(createMaintenanceRecordSuccess(data));
    } catch (error) {
      dispatch(createMaintenanceRecordFailure(error.message));
    }
  };
};



export function updateMaintenanceRecordSuccess(data) {
  return {
    type: maintenanceRecordsActionTypes.UPDATE_MAINTENANCE_RECORD_SUCCESS,
    payload: data,
  };
}

export function updateMaintenanceRecordFailure(error) {
  return {
    type: maintenanceRecordsActionTypes.UPDATE_MAINTENANCE_RECORD_FAILURE,
    payload: error,
  };
}

export const updateMaintenanceRecord = (newUpdateRecord) => {
  return async (dispatch) => {
    const url = "http://localhost:60805/api/MaintenanceRecords";
    const method = "PUT";
    const body = newUpdateRecord;
    try {
      const updatedMaintenanceRecord = await apiHelper({ url, method, body });
      dispatch(updateMaintenanceRecordSuccess(updatedMaintenanceRecord));
    } catch (error) {}
  };
};



export function getCarByRecordIdAndChassisNoSuccess(selectedUpdateCar) {
  return {
    type: maintenanceRecordsActionTypes.GET_CAR_BY_RECORD_ID_AND_CHASSISNO_SUCCESS,
    payload: selectedUpdateCar,
  };
}

export function getCarByRecordIdAndChassisNoFailure(error) {
  return {
    type: maintenanceRecordsActionTypes.GET_CAR_BY_RECORD_ID_AND_CHASSISNO_FAILURE,
    payload: error,
  };
}

export const getCarByRecordIdAndChassisNo = (id, chassisNo) => {
  return async (dispatch) => {
    const url = `http://localhost:60805/api/MaintenanceRecords/${id}/${chassisNo}`;
    const method = "GET";
    try {
      const data = await apiHelper({ url, method });
      console.log("Güncellenecek araba", data);
      dispatch(getCarByRecordIdAndChassisNoSuccess(data));
    } catch (error) {
      dispatch(getCarByRecordIdAndChassisNoFailure(error.message));
    }
  };
};




export function getPastMaintenanceRecordListSuccess(
  getPastMaintenanceRecordList
) {
  return {
    type: maintenanceRecordsActionTypes.GET_PAST_MAINTENANCE_RECORD_LIST_SUCCESS,
    payload: getPastMaintenanceRecordList,
  };
}
export function getPastMaintenanceRecordListFailure(error) {
  return {
    type: maintenanceRecordsActionTypes.GET_PAST_MAINTENANCE_RECORD_LIST_FAILURE,
    payload: error,
  };
}


export const getPastMaintenanceRecordList = (pastMaintenanceRecordData) => {
  return async (dispatch) => {
    const url =
      "http://localhost:60805/api/MaintenanceRecords/past-maintenance";
    const method = "POST";
    const body = pastMaintenanceRecordData;
    try {
      const data = await apiHelper({ url, method, body });
      console.log("Apiden gelen geçmiş bakım kayıtları",data);
      dispatch(getPastMaintenanceRecordListSuccess(data));
    } catch (error) {
      dispatch(getPastMaintenanceRecordListFailure(error.message));
    }
  };
};

export function getActiveMaintenanceRecordListSuccess(
  getActiveMaintenanceRecordList
) {
  return {
    type: maintenanceRecordsActionTypes.GET_ACTIVE_MAINTENANCE_RECORD_LIST_SUCCESS,
    payload: getActiveMaintenanceRecordList,
  };
}
export function getActiveMaintenanceRecordListFailure(error) {
  return {
    type: maintenanceRecordsActionTypes.GET_ACTIVE_MAINTENANCE_RECORD_LIST_FAILURE,
    payload: error,
  };
}


export const getactiveMaintenanceRecord = (activeMaintenanceRecordData) => {
  return async (dispatch) => {
    const url =
      "http://localhost:60805/api/MaintenanceRecords/active-maintenance";
    const method = "POST";
    const body = activeMaintenanceRecordData;
    try {
      const data = await apiHelper({ url, method, body });
      dispatch(getActiveMaintenanceRecordListSuccess(data));
    } catch (error) {
      dispatch(getActiveMaintenanceRecordListFailure(error.message));
    }
  };
};



export function getPendingMaintenanceRecordListSuccess(
  getPendingMaintenanceRecordList
) {
  return {
    type: maintenanceRecordsActionTypes.GET_PENDING_MAINTENANCE_RECORD_LIST_SUCCESS,
    payload: getPendingMaintenanceRecordList,
  };
}
export function getPendingMaintenanceRecordListFailure(error) {
  return {
    type: maintenanceRecordsActionTypes.GET_PENDING_MAINTENANCE_RECORD_LIST_FAILURE,
    payload: error,
  };
}

export const getPendingMaintenanceRecord = (pendingMaintenanceRecordData) => {
  return async (dispatch) => {
    const url =
      "http://localhost:60805/api/MaintenancePlanningRecords/pending-maintenance";
    const method = "POST";
    const body = pendingMaintenanceRecordData;
    try {
      const data = await apiHelper({ url, method, body });
      dispatch(getPendingMaintenanceRecordListSuccess(data));
    } catch (error) {
      dispatch(getPendingMaintenanceRecordListFailure(error.message));
    }
  };
};



export function getMonthlyMaintenanceIncidenceCountSuccess(
  getMonthlyMaintenanceIncidenceData
) {
  return {
    type: maintenanceRecordsActionTypes.GET_MONTHLY_MAINTENANCE_INCIDENCE_COUNT_SUCCESS,
    payload: getMonthlyMaintenanceIncidenceData,
  };
}
export function getMonthlyMaintenanceIncidenceCountFailure(error) {
  return {
    type: maintenanceRecordsActionTypes.GET_MONTHLY_MAINTENANCE_INCIDENCE_COUNT_FAILURE,
    payload: error,
  };
}

export const getMonthlyMaintenanceIncidenceCount = () => {
  return async (dispatch) => {
    const url =
      "http://localhost:60805/api/MaintenanceRecords/get-count-by-month";
    const method = "GET";
    try {
      const data = await apiHelper({ url, method });
      dispatch(getMonthlyMaintenanceIncidenceCountSuccess(data));
    } catch (error) {
      dispatch(getMonthlyMaintenanceIncidenceCountFailure(error.message));
    }
  };
};


export function getYearlyMaintenanceIncidenceCountSuccess(
  getMonthlyMaintenanceIncidenceData
) {
  return {
    type: maintenanceRecordsActionTypes.GET_YEARLY_MAINTENANCE_INCIDENCE_COUNT_SUCCESS,
    payload: getMonthlyMaintenanceIncidenceData,
  };
}
export function getYearlyMaintenanceIncidenceCountFailure(error) {
  return {
    type: maintenanceRecordsActionTypes.GET_YEARLY_MAINTENANCE_INCIDENCE_COUNT_SUCCESS,
    payload: error,
  };
}

export const getYearlyMaintenanceIncidenceCount = () => {
  return async (dispatch) => {
    const url =
      `http://localhost:60805/api/MaintenanceRecords/get-count-by-year?NumberOfYear=8`;
    const method = "GET";
    try {
      const data = await apiHelper({ url, method });

      dispatch(getYearlyMaintenanceIncidenceCountSuccess(data));
    } catch (error) {
      dispatch(getYearlyMaintenanceIncidenceCountFailure(error.message));
    }
  };
};



export function getYearlyMaintenanceTotalCostSuccess(
  getYearlyMaintenanceTotalCostData
) {
  return {
    type: maintenanceRecordsActionTypes.GET_YEARLY_TOTAL_COST_SUCCESS,
    payload: getYearlyMaintenanceTotalCostData,
  };
}
export function getYearlyMaintenanceTotalCostFailure(error) {
  return {
    type: maintenanceRecordsActionTypes.GET_YEARLY_TOTAL_COST_FAILURE,
    payload: error,
  };
}

export const getYearlyMaintenanceTotalCost = () => {
  return async (dispatch) => {
    const url =
      `http://localhost:60805/api/MaintenanceRecords/get-yearly-total-and-average-cost?NumberOfYear=10`;
    const method = "GET";
    try {
      const data = await apiHelper({ url, method });

      dispatch(getYearlyMaintenanceTotalCostSuccess(data));
    } catch (error) {
      dispatch(getYearlyMaintenanceTotalCostFailure(error.message));
    }
  };
};



export function getMonthlyMaintenanceTotalCostSuccess(
  getMonthlyMaintenanceTotalCostData
) {
  return {
    type: maintenanceRecordsActionTypes.GET_MOTNHLY_TOTAL_COST_SUCCESS,
    payload: getMonthlyMaintenanceTotalCostData,
  };
}
export function getMonthlyMaintenanceTotalCostFailure(error) {
  return {
    type: maintenanceRecordsActionTypes.GET_MONTHLY_TOTAL_COST_FAILURE,
    payload: error,
  };
}

export const getMonthlyMaintenanceTotalCost = () => {
  return async (dispatch) => {
    const url =
      `http://localhost:60805/api/MaintenanceRecords/get-monthly-total-and-average-cost`;
    const method = "GET";
    try {
      const data = await apiHelper({ url, method });
      dispatch(getMonthlyMaintenanceTotalCostSuccess(data));
    } catch (error) {
      dispatch(getMonthlyMaintenanceTotalCostFailure(error.message));
    }
  };
};



export function getCostByBrandSuccess(
  getCostByBrandData
) {
  return {
    type: maintenanceRecordsActionTypes.GET_COST_BY_BRAND_SUCCESS,
    payload: getCostByBrandData,
  };
}
export function getCostByBrandFailure(error) {
  return {
    type: maintenanceRecordsActionTypes.GET_COST_BY_BRAND_FAILURE,
    payload: error,
  };
}

export const getCostByBrand = (year, month) => {
  return async (dispatch) => {
    const url =
      `http://localhost:60805/api/MaintenanceRecords/get-cost-by-brand?Year=${year}&Month=${month}`;
    const method = "GET";
    try {
      const data = await apiHelper({ url, method });
      dispatch(getCostByBrandSuccess(data));
    } catch (error) {
      dispatch(getCostByBrandFailure(error.message));
    }
  };
};



export function getCostByTypeSuccess(
  getCostByTypedData
) {
  return {
    type: maintenanceRecordsActionTypes.GET_COST_BY_TYPE_SUCCESS,
    payload: getCostByTypedData,
  };
}
export function getCostByTypeFailure(error) {
  return {
    type: maintenanceRecordsActionTypes.GET_COST_BY_TYPE_FAILURE,
    payload: error,
  };
}

export const getCostByType = () => {
  return async (dispatch) => {
    const url ="http://localhost:60805/api/MaintenanceRecords/get-cost-by-maintenanceType";
    const method = "GET";
    try {
      const data = await apiHelper({ url, method });
      dispatch(getCostByTypeSuccess(data));
    } catch (error) {
      dispatch(getCostByTypeFailure(error.message));
    }
  };
};


export function getCostByVehicleTypeSuccess(
  getCostByVehicleTypedData
) {
  return {
    type: maintenanceRecordsActionTypes.GET_COST_BY_VEHICLE_TYPE_SUCCESS,
    payload: getCostByVehicleTypedData,
  };
}
export function getCostByVehicleTypeFailure(error) {
  return {
    type: maintenanceRecordsActionTypes.GET_COST_BY_VEHICLE_TYPE_FAILURE,
    payload: error,
  };
}

export const getCostByVehicleType = () => {
  return async (dispatch) => {
    const url ="http://localhost:60805/api/MaintenanceRecords/get-cost-by-vehicleType";
    const method = "GET";
    try {
      const data = await apiHelper({ url, method });
      dispatch(getCostByVehicleTypeSuccess(data));
    } catch (error) {
      dispatch(getCostByVehicleTypeFailure(error.message));
    }
  };
};