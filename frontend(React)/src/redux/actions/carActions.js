import apiHelper from "../helper/apiHelper";
import * as carActionTypes from "./carActionTypes";

export function getTotalCarCountSuccess(carData){
  return { type: carActionTypes.GET_TOTAL_CAR_COUNT_SUCCESS, data:carData}
}

export function getCarByChassisNoSuccess(selectedCar){
  return { type: carActionTypes.GET_CAR_BY_CHASSIS_NO_SUCCESS, payload : selectedCar}
}

export function getCarByChassisNoFailure(selectedCar){
  return { type: carActionTypes.GET_CAR_BY_CHASSIS_NO_FAILURE, payload : selectedCar}
}

export const handleAddCar = (carData) => {
    return async (dispatch) => {
        try {
            const response = await fetch("http://localhost:60805/api/Cars", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(carData),
            });

            const data = await response.json();
            
            dispatch({
                type: carActionTypes.ADD_CAR,
                payload: data,
            });

            return data; // Eklenen araba verisini döndür
        } catch (error) {
            dispatch({
                type: carActionTypes.ADD_CAR_FAILURE,
                payload: error,
            });
            throw error;
        }
    };
};

export const handleGetTotalCarCount = () => {
    return async (dispatch) => {
      try {
        const response = await fetch("http://localhost:60805/api/Cars/TotalCount", {
          method: "GET",
          headers: {
            "Content-Type": "application/json",
          },
        });
  
        const data = await response.json();
        console.log("Total Car Count API Response: ", data); // Konsola API yanıtını yazdır
  
        dispatch({
          type: carActionTypes.GET_TOTAL_CAR_COUNT_SUCCESS,
          payload: data.totalCarNumber,  // totalCarNumber'ı payload olarak kullanıyoruz
        });
        return data;
      } catch (error) {
        dispatch({
          type: carActionTypes.GET_TOTAL_CAR_COUNT_FAILURE,
          payload: error,
        });
      }
    };
  };
  

  export const handleUpdateCar = ( updatedCar) => {
    return async (dispatch) => {
      try {
        const response = await fetch("http://localhost:60805/api/Cars", {
          method:"PUT",
          headers:{
            "Content-Type" : "application/json",
          },
          body: JSON.stringify(updatedCar),
        });
        const data = await response.json();
        dispatch({
          type: carActionTypes.UPDATE_CAR_SUCCESS,
          payload: data
        })
        return data;
      } catch (error) {
        dispatch({
          type:carActionTypes.UPDATE_CAR_FAILURE,
          payload: error
        });
        throw error;
      }
    }
  }

  export const handleGetCarList = () => {
    return async(dispatch) => {
      try {
        const response = await fetch("http://localhost:60805/api/Cars/ListCar?PageIndex=0&PageSize=999",{
          method:"GET",
          headers:{
            "Content-Type" :"application/json"
          },
        });
        const data = await response.json();
        console.log("Api: ", data);
        dispatch({
          type : carActionTypes.GET_CAR_LIST_SUCCESS,
          payload:data
        })
        return data;
        } catch (error) {
        dispatch({
          type:carActionTypes.GET_CAR_LIST_FAILURE,
          payload: error
        });
        throw error;
      }
    }
  }


  export function handleSelectedCarQuantity(brandName, modelName, transmissionType, fuelType, year) {
    return async (dispatch) => {
      try {
        const response = await fetch(`http://localhost:60805/api/Cars/GetCarStockQuantity/${brandName}/${modelName}/${transmissionType}/${fuelType}/${year}`, {
          method: "GET",
          headers: {
            "Content-Type": "application/json",
          },
        });
  
        if (!response.ok) {
          throw new Error("API request failed");
        }
  
        const data = await response.json();
        console.log("Api: ", data);
  
        dispatch({
          type: carActionTypes.GET_SELECTED_CAR_QUANTITY_SUCCESS,
          payload: data,
        });
        
        return data;
  
      } catch (error) {
        dispatch({
          type: carActionTypes.GET_SELECTED_CAR_QUANTITY_FAILURE,
          payload: error.message, 
        });
        throw error;
      }
    };
  }
  
  export function handleGetSelectedCarMaintenanceNumber (brandName, modelName, transmissionType, fuelType, year, status) {
    return async (dispatch) => {
      try {
        const response = await fetch(`http://localhost:60805/api/Cars/GetNumberOfCarInMaintenance/${brandName}/${modelName}/${transmissionType}/${fuelType}/${year}/${status}`, {
          method : "GET",
          headers : {
            "Content-Type" : "application/json",
          }
        });

        const data = await response.json();
        console.log("Apiden gelen bakımdaki araba sayısı verisi: ", data);

        dispatch({
          type: carActionTypes.GET_SELECTED_CAR_MAINTENANCE_NUMBER_SUCCESS,
          payload : data
        })
        return data;
      } catch (error) {
        dispatch({
          type : carActionTypes.GET_SELECTED_CAR_MAINTENANCE_NUMBER_FAILURE,
          payload: error.message
        })
        throw error;
      }
    };
  }


  export function handleGetNumberCarOfSoldInSelectedCar(brandName, modelName, transmissionType, fuelType, year, status) {
    return async (dispatch) => {
      try {
        const response = await fetch(`http://localhost:60805/api/Cars/GetNumberCarOfSoldInSelectedCar/${brandName}/${modelName}/${transmissionType}/${fuelType}/${year}/${status}`, {
          method : "GET",
          headers : {
            "Content-Type" : "application/json",
          }
        });

        const data = await response.json();
        console.log("Apiden gelen satılmış araba sayısı verisi: ", data);

        dispatch({
          type: carActionTypes.GET_NUMBER_CAR_OF_SOLD_IN_SELECTED_CAR_SUCCESS,
          payload : data
        })
        return data;
      } catch (error) {
        dispatch({
          type : carActionTypes.GET_NUMBER_CAR_OF_SOLD_IN_SELECTED_CAR_FAILURE,
          payload: error.message
        })
        throw error;
      }
    };
  }

  export const handleGetTotalCarInStorage = () => {
    return async(dispatch) => {
      try {
        const response = await fetch("http://localhost:60805/api/Cars/GetCarStatusInStorage/Depoda",{
          method:"GET",
          headers:{
            "Content": "application/json"
          }
        });

        const data = await response.json();
        dispatch({
          type: carActionTypes.GET_TOTAL_CAR_ON_STORAGE_SUCCESS,
          payload:data
        })
        return data;
      } catch (error) {
        dispatch({
          type: carActionTypes.GET_TOTAL_CAR_ON_STORAGE_FAILURE,
          payload: error.message
        })
        throw error;
      }
      
    }
  }

  export const handleGetSaleReserveCount = () => {
    return async(dispatch) => {
      try {
        const response = await fetch("http://localhost:60805/api/Cars/GetCarStatusInStorage/Rezervede",{
          method:"GET",
          headers:{
            "Content": "application/json"
          }
        });

        const data = await response.json();
        dispatch({
          type: carActionTypes.GET_SALE_RESERVE_COUNT_SUCCESS,
          payload:data
        })
        return data;
      } catch (error) {
        dispatch({
          type: carActionTypes.GET_SALE_RESERVE_COUNT_FAILURE,
          payload: error.message
        })
        throw error;
      }
      
    }
  }
  export const  handleGetCarByChassisNo = (brand,model,chassisNo) => {
    return async (dispatch) =>{
      const url = `http://localhost:60805/api/Cars/GetCarByChassisNo/${brand}/${model}/${chassisNo}`;
      const method = "GET";
      try {
        const data = await apiHelper({url, method});
        dispatch(getCarByChassisNoSuccess(data));
      } catch (error) {
        dispatch(getCarByChassisNoFailure(error.message));
        throw error;
      }
    }
   }