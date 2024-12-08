import initialState from "./initialState";
import * as maintenanceActionTypes from "../actions/maintenanceActionTypes";
const maintenanceReducer = (state = initialState.maintenanceData, action) => {
  switch (action.type) {
    case maintenanceActionTypes.CREATE_MAINTENANCE_RECORD_SUCCESS:
      return {
        ...state,
        maintenanceRecords: action.payload,
        error: null,
      };
    case maintenanceActionTypes.CREATE_MAINTENANCE_RECORD_FAILURE:
      return {
        ...state,
        maintenanceRecords: [],
        error: action.payload,
      };

    case maintenanceActionTypes.CREATE_MAINTENANCE_PLANNING_RECORD_SUCCESS:
      return {
        ...state,
        maintenancePlanningRecords: action.payload,
        error: null,
      };
    case maintenanceActionTypes.CREATE_MAINTENANCE_PLANNING_RECORD_FAILURE:
      return {
        ...state,
        maintenancePlanningRecords: [],
        error: action.payload,
      };

    case maintenanceActionTypes.GET_CAR_BY_RECORD_ID_AND_CHASSISNO_SUCCESS:
      console.log("Reducerdaki selected car", action.payload);
      return {
        ...state,
        selectedUpdateCar: action.payload,
        error: null,
      };
    case maintenanceActionTypes.GET_CAR_BY_RECORD_ID_AND_CHASSISNO_FAILURE:
      return {
        ...state,
        selectedUpdateCar: null,
        error: action.payload,
      };

    case maintenanceActionTypes.GET_PAST_MAINTENANCE_RECORD_LIST_SUCCESS:
      return {
        ...state,
        pastMaintenanceRecordList: action.payload.items,
        error: null,
      };

    case maintenanceActionTypes.GET_PAST_MAINTENANCE_RECORD_LIST_FAILURE:
      return {
        ...state,
        pastMaintenanceRecordList: null,
        error: action.payload,
      };

    case maintenanceActionTypes.GET_ACTIVE_MAINTENANCE_RECORD_LIST_SUCCESS:
      return {
        ...state,
        activeMaintenanceRecordList: action.payload.items,
        error: null,
      };

    case maintenanceActionTypes.GET_ACTIVE_MAINTENANCE_RECORD_LIST_FAILURE:
      return {
        ...state,
        activeMaintenanceRecordList: null,
        error: action.payload,
      };

    case maintenanceActionTypes.GET_PENDING_MAINTENANCE_RECORD_LIST_SUCCESS:
      return {
        ...state,
        pendingMaintenanceRecordList: action.payload.items,
        error: null,
      };

    case maintenanceActionTypes.GET_PENDING_MAINTENANCE_RECORD_LIST_FAILURE:
      return {
        ...state,
        pendingMaintenanceRecordList: null,
        error: action.payload,
      };

    case maintenanceActionTypes.GET_MONTHLY_MAINTENANCE_INCIDENCE_COUNT_SUCCESS:
      return {
        ...state,
        getMonthlyMaintenanceIncidenceData: action.payload.items,
        error: null,
      };

    case maintenanceActionTypes.GET_MONTHLY_MAINTENANCE_INCIDENCE_COUNT_FAILURE:
      return {
        ...state,
        getMonthlyMaintenanceIncidenceData: null,
        error: action.payload,
      };

    case maintenanceActionTypes.GET_YEARLY_MAINTENANCE_INCIDENCE_COUNT_SUCCESS:
      return {
        ...state,
        getYearlyMaintenanceIncidenceData: action.payload.items,
        error: null,
      };

    case maintenanceActionTypes.GET_YEARLY_MAINTENANCE_INCIDENCE_COUNT_FAILURE:
      return {
        ...state,
        getYearlyMaintenanceIncidenceData: null,
        error: action.payload,
      };

    case maintenanceActionTypes.GET_YEARLY_TOTAL_COST_SUCCESS:
      return {
        ...state,
        getYearlyMaintenanceTotalCostData: action.payload.items,
        error: null,
      };

    case maintenanceActionTypes.GET_YEARLY_TOTAL_COST_FAILURE:
      return {
        ...state,
        getYearlyMaintenanceTotalCostData: null,
        error: action.payload,
      };

    case maintenanceActionTypes.GET_MOTNHLY_TOTAL_COST_SUCCESS:
      return {
        ...state,
        getMonthlyMaintenanceTotalCostData: action.payload.items,
        error: null,
      };

    case maintenanceActionTypes.GET_MONTHLY_TOTAL_COST_FAILURE:
      return {
        ...state,
        getMonthlyMaintenanceTotalCostData: null,
        error: action.payload,
      };

    case maintenanceActionTypes.GET_COST_BY_BRAND_SUCCESS:
      return {
        ...state,
        getCostByBrandData: action.payload.items,
        error: null,
      };

    case maintenanceActionTypes.GET_COST_BY_BRAND_FAILURE:
      return {
        ...state,
        getCostByBrandData: null,
        error: action.payload,
      };

    case maintenanceActionTypes.GET_COST_BY_TYPE_SUCCESS:
      return {
        ...state,
        getCostByTypedData: action.payload.items,
        error: null,
      };

    case maintenanceActionTypes.GET_COST_BY_TYPE_FAILURE:
      return {
        ...state,
        getCostByTypedData: null,
        error: action.payload,
      };

      case maintenanceActionTypes.GET_COST_BY_VEHICLE_TYPE_SUCCESS:
      return {
        ...state,
        getCostByVehicleTypedData: action.payload.items,
        error: null,
      };

    case maintenanceActionTypes.GET_COST_BY_VEHICLE_TYPE_FAILURE:
      return {
        ...state,
        getCostByVehicleTypedData: null,
        error: action.payload,
      };


    default:
      return state;
  }
};

export default maintenanceReducer;
