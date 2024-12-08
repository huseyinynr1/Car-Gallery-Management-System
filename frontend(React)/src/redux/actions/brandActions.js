import * as brandActionTypes from './brandActionTypes'
import { apiHelper } from '../helper/apiHelper'

export const getBrandListSuccess = (data) => ({
    type: brandActionTypes.GET_BRAND_LIST_SUCCESS,
    payload: data,
});


export function getBrandListFailure(error){
    return {type:brandActionTypes.GET_BRAND_LIST_FAILURE, payload:error}
}

export function getCarsCountByBrandNameSuccess(brandName){
    return {type:brandActionTypes.GET_CARS_COUNT_BY_BRAND_NAME_SUCCESS, payload:brandName}
}

export function getCarsCountByBrandNameFailure(error){
    return {type:brandActionTypes.GET_CARS_COUNT_BY_BRAND_NAME_FAILURE, payload:error}
}



export const getBrandList = () => {
    return async (dispatch) => {
        const url = "http://localhost:60805/api/Brands?PageIndex=0&PageSize=99";
        const method = "GET";
        try {
            const data = await apiHelper({ url, method }); // Obje olarak gönderiyoruz
            dispatch(getBrandListSuccess(data));
        } catch (error) {
            dispatch(getBrandListFailure(error.message));
        }
    };
};

export const handleGetCarsCountByBrandName = (brandName) => {
    return async(dispatch) => {
        const url = `http://localhost:60805/api/Cars/GetCarsCountByBrandName/${brandName}`;
        try
        {
            const data = await apiHelper(url,"GET");
            dispatch(getCarsCountByBrandNameSuccess(data));
        }
        catch(error){
            dispatch(getBrandListFailure(error.message));
            throw error;
        }
        
    }
}
