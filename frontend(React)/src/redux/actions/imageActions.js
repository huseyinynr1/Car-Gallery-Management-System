import * as imageActionTypes from "./imageActionTypes"

export function uploadImagesSuccess(formData) {
  return { type: imageActionTypes.UPLOAD_IMAGES_SUCCESS, payload: formData };
}

export function uploadImagesFailure(error) {
  return { type: imageActionTypes.UPLOAD_IMAGES_FAILURE, payload: error };
}

export const uploadImages = (formData) => {
  return async (dispatch) =>{
    try {
      const response = await fetch ("http://localhost:60805/api/Images",{
        method:"POST",
        body : formData,
      });

      const data = await response.json();

      dispatch({
        type:imageActionTypes.UPLOAD_IMAGES_SUCCESS,
        payload:data,
      });

      return data;

    } catch (error) {
      dispatch({
        type:imageActionTypes.UPLOAD_IMAGES_FAILURE,
        payload:error
      });
      throw error;
    }
  }
} 