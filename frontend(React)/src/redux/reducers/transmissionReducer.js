import * as transmissionActionsTypes from "../actions/transmissionActionsTypes"
import initialState from "./initialState"
function transmissionReducer(state = initialState.transmissionData, action) {
    switch (action.type) {
        case transmissionActionsTypes.GET_TRANSMISSION_TYPES_SUCCESS:
            return {
                ...state,
                transmissions: action.payload.items, // 'items' doğru mu?
                error: null,
            };
        case transmissionActionsTypes.GET_TRANSMISSION_TYPES_FAILURE:
            return {
                ...state,
                transmissions: [],
                error: action.payload,
            };
        default:
            return state;
    }
}
export default transmissionReducer;