import * as  brandActionTypes from '../actions/brandActionTypes'
import initialState from "./initialState"

function brandReducer(state = initialState.brandData, action) {
    switch (action.type) {
        case brandActionTypes.GET_BRAND_LIST_SUCCESS:
            return {
                ...state,
                brands: action.payload.items, // 'items' içinde olduğunu varsayıyoruz
                error: null,
            };

        case brandActionTypes.GET_BRAND_LIST_FAILURE:
            return {
                ...state,
                brands: [],
                error: action.payload.message,
            };
            case brandActionTypes.GET_CARS_COUNT_BY_BRAND_NAME_SUCCESS:
                console.log("Reducer'a gelen payload: ", action.payload); // Veriyi kontrol et
                return {
                    ...state,
                    carsCountByBrandName: {
                        ...state.carsCountByBrandName,
                        [action.payload.brandName]: action.payload.count, // Güncelleme işlemi
                    },
                    error: null,
                };
        case brandActionTypes.GET_CARS_COUNT_BY_BRAND_NAME_FAILURE:
            return{
                ...state,
                carsCountByBrandName:{
                    ...state.carsCountByBrandName,
                    [action.payload.brandName]:0,
                },
                error: action.payload.message,
            }    
        default:
            return state;
    }
}

export default brandReducer;