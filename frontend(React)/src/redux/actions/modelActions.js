import apiHelper from "../helper/apiHelper";
import * as modelActionTypes from "./modelActionTypes"

export function getModelListSuccess(data){
    return {type : modelActionTypes.GET_MODEL_LIST_SUCCESS, payload:data}
}

export function getModelListFailure(error){
    return{type : modelActionTypes.GET_MODEL_LIST_FAILURE,payload:error}
}

export const getModelListHandler = () => {
   return async(dispatch) =>{
    const url = "http://localhost:60805/api/Models?PageIndex=0&PageSize=999";
    const method = "GET";
    
    try {
        const data = await apiHelper({url, method});
        dispatch(getModelListSuccess(data));
    } catch (error) {
        dispatch(getModelListFailure(error));
        throw error;
    }
   }
}


export function getModelByBrandListSuccess(modelData){
    return {type : modelActionTypes.GET_MODEL_BY_BRAND_LIST_SUCCESS, payload:modelData}
}

export function getModelByBrandListFailure(error){
    return{type : modelActionTypes.GET_MODEL_BY_BRAND_LIST_FAILURE,payload:error}
}

export const getModelByBrandListHandler = (selectedBrand) => {
    return async(dispatch) =>{
     const url = `http://localhost:60805/api/Models/getModelByBrand?brandName=${selectedBrand}`;
     const method = "GET";
     
     try {
         const data = await apiHelper({url, method});
         dispatch(getModelByBrandListSuccess(data));
     } catch (error) {
         dispatch(getModelByBrandListFailure(error));
         throw error;
     }
    }
 }