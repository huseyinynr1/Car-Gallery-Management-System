import * as modelActionTypes from '../actions/modelActionTypes'
import initialState from './initialState'

 function modelReducer(state= initialState.modelData, action){
    switch (action.type) {
        case modelActionTypes.GET_MODEL_LIST_SUCCESS:
            return{
                models: action.payload.items,
                error:null,
            };
        
        case modelActionTypes.GET_MODEL_LIST_FAILURE:
            return{
                models:[],
                error : action.payload
            }

            case modelActionTypes.GET_MODEL_BY_BRAND_LIST_SUCCESS:
            return{
                modelByBrand: action.payload.items,
                error:null,
            };
        
        case modelActionTypes.GET_MODEL_BY_BRAND_LIST_FAILURE:
            return{
                modelByBrand:[],
                error : action.payload
            }
        default:
            return state;
    }
 }
export default modelReducer;