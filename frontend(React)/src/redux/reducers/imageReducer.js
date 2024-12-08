import * as imageActionTypes from "../actions/imageActionTypes"
import initialState from "./initialState";

function imageReducer(state = initialState.formData, action){
    switch (action.type) {
        case imageActionTypes.UPLOAD_IMAGES_SUCCESS:
            return{
                ...state,
                images:action.payload.items,
                error:null,
            };
        case imageActionTypes.UPLOAD_IMAGES_FAILURE:
            return{
                ...state,
                images:[],
                error:action.payload,
            };   
    
        default:
            return state;
    }
}

export default imageReducer;