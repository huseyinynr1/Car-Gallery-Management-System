import * as fuelActionTypes from "../actions/fuelActionTypes"
import initialState from "./initialState"
function fuelReducer(state = initialState.fuelData, action) {
    switch (action.type) {
        case fuelActionTypes.GET_FUEL_TYPE_SUCCESS:
            return {
                ...state,
                fuels: action.payload.items, // 'items' doğru mu?
                error: null,
            };
        case fuelActionTypes.GET_FUEL_TYPE_FAILURE:
            return {
                ...state,
                fuels: [],
                error: action.payload,
            };
        default:
            return state;
    }
}
export default fuelReducer;