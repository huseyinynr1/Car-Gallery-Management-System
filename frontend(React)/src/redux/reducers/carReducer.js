import * as carActionTypes from "../actions/carActionTypes";
import initialState from "./initialState";

function carReducer(state = initialState.carData, action) {
  switch (action.type) {
    case carActionTypes.GET_CAR_LIST_SUCCESS:
      return {
        ...state,
        getList: action.payload.items,
        error: null,
      };

    case carActionTypes.GET_CAR_LIST_FAILURE:
      return {
        ...state,
        getList: {},
        error: action.payload,
      };
    case carActionTypes.ADD_CAR:
      return {
        ...state,
        data: action.payload,
        error: null,
      };

    case carActionTypes.ADD_CAR_FAILURE:
      return {
        ...state,
        data: null,
        error: action.payload,
      };

    case carActionTypes.GET_TOTAL_CAR_COUNT_SUCCESS:
      return {
        ...state,
        totalCount: action.payload, // Burada totalCount güncelleniyor olmalı
        error: null,
      };
    case carActionTypes.GET_TOTAL_CAR_COUNT_FAILURE:
      return {
        ...state,
        totalCount: 0, // Hata durumunda 0'a set edelim
        error: action.payload,
      };

    case carActionTypes.UPDATE_CAR_SUCCESS:
      return {
        ...state,
        updatedCar: action.payload,
        error: null,
      };

    case carActionTypes.UPDATE_CAR_FAILURE:
      return {
        ...state,
        updatedCar: null,
        error: action.payload,
      };

    case carActionTypes.GET_SELECTED_CAR_QUANTITY_SUCCESS:
      return {
        ...state,
        selectedCarQuantity: action.payload,
        error: null,
      };
    case carActionTypes.GET_SELECTED_CAR_QUANTITY_FAILURE:
      return {
        ...state,
        selectedCarQuantity: 0,
        error: action.payload,
      };
    case carActionTypes.GET_SELECTED_CAR_MAINTENANCE_NUMBER_SUCCESS:
      return {
        ...state,
        selectedCarMaintenanceNumber: action.payload,
        error: null,
      };

    case carActionTypes.GET_SELECTED_CAR_MAINTENANCE_NUMBER_FAILURE:
      return {
        ...state,
        selectedCarMaintenanceNumber: 0,
        error: action.payload,
      };
    case carActionTypes.GET_NUMBER_CAR_OF_SOLD_IN_SELECTED_CAR_SUCCESS:
      return {
        ...state,
        numberOfSoldInSelectedCar: action.payload,
        error: null,
      };

    case carActionTypes.GET_NUMBER_CAR_OF_SOLD_IN_SELECTED_CAR_FAILURE:
      return {
        ...state,
        numberOfSoldInSelectedCar: 0,
        error: action.payload,
      };
    case carActionTypes.GET_TOTAL_CAR_ON_STORAGE_SUCCESS:
      return {
        ...state,
        totalCarInStorage: action.payload,
        error: null,
      };
    case carActionTypes.GET_TOTAL_CAR_ON_STORAGE_FAILURE:
      return {
        ...state,
        totalCarInStorage: 0,
        error: action.payload,
      };
      case carActionTypes.GET_SALE_RESERVE_COUNT_SUCCESS:
      return {
        ...state,
        reserveCarCount: action.payload,
        error: null,
      };
    case carActionTypes.GET_SALE_RESERVE_COUNT_FAILURE:
      return {
        ...state,
        reserveCarCount: 0,
        error: action.payload,
      };

    case carActionTypes.GET_CAR_BY_CHASSIS_NO_SUCCESS:
      return{
        ...state,
        maintenanceCarData : action.payload,
        error:null
      }
      
    case carActionTypes.GET_CAR_BY_CHASSIS_NO_FAILURE:
      return{
        ...state,
        maintenanceCarData : null,
        error : action.payload
      }  
    default:
      return state;
  }
}

export default carReducer;
