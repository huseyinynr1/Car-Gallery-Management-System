import * as fuelActionTypes from "./fuelActionTypes"

export function getFuelTypesSuccess(fuelData){
    return {type : fuelActionTypes.GET_FUEL_TYPE_SUCCESS, payload:fuelData}
}

export function getFuelTypesFailure(error){
    return {type : fuelActionTypes.GET_FUEL_TYPE_FAILURE, payload:error}
}

export function getFuelTypesHandler(){
    return function(dispatch){
        const url = "http://localhost:60805/api/Fuels?PageIndex=0&PageSize=999";
        const token = localStorage.getItem('token'); 
        return fetch(url, {
            method:"GET",
            headers:{
                "Content-Type":"application/json",
                "Authorization": `Bearer ${token}`, // Token'ı ekleyin
            },
        })
        .then(response => {
            if(!response.ok){
                return response.json().then(error=>{
                    throw new Error(error);
                })
            }
            return response.json();
        })
        .then(result =>{
            console.log("API'den gelen veri: ",result);
           dispatch(getFuelTypesSuccess(result));
        })
        .catch(error => {
            dispatch(getFuelTypesFailure(error.message));
        })
    }
}