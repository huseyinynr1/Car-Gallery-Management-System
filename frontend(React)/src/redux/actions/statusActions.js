import * as statusActionsTypes from './statusActionsTypes'

export function getStatusListSuccess(statusData) {
    return {type: statusActionsTypes.GET_STATUS_LIST_SUCCESS, payload:statusData};
}

export function getStatusListFailure(error) {
    return{type:statusActionsTypes.GET_STATUS_LIST_FAILURE,payload:error};
}

export function handleGetStatusList(){
    return function(dispatch){
        const url = "http://localhost:60805/api/CarStatus?PageIndex=0&PageSize=999";
        return fetch(url, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
            },
        })
        .then(response => {
            if (!response.ok) {
                return response.json().then(error => {
                    throw new Error(error);
                });
            }
            return response.json();
        })
        .then(result => {
            dispatch(getStatusListSuccess(result));
        })
        .catch(error => {
            dispatch(getStatusListFailure(error.message));
        });
    };
}
