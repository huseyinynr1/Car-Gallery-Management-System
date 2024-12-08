import * as transmissionActionTypes from "./transmissionActionsTypes"

export function getTransmissionTypesSuccess(transmissionData){
    return {type : transmissionActionTypes.GET_TRANSMISSION_TYPES_SUCCESS, payload:transmissionData}
}

export function getTransmissionTypesFailure(error){
    return {type : transmissionActionTypes.GET_TRANSMISSION_TYPES_SUCCESS, payload:error}
}

export function getTransmissionTypesHandler(){
    return function(dispatch){
        const url = "http://localhost:60805/api/Transmissions?PageIndex=0&PageSize=999";
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
           dispatch(getTransmissionTypesSuccess(result));
        })
        .catch(error => {
            dispatch(getTransmissionTypesFailure(error.message));
        })
    }
}