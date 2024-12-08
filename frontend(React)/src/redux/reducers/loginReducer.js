import * as loginActionTypes from '../actions/loginActionTypes'
import initialState from './initialState'; 


 function loginReducer(state = initialState.loginData, action)
{
    switch (action.type) {
        case loginActionTypes.HANDLE_LOGIN_SUCCESS:
            return {
                ...state,
                loading: false,
                user:action.payload,
                error:null,
                isRedirecting:true,
            };

        case loginActionTypes.RESET_REDIRECTING:
        return {
            ...state,
            isRedirecting:false,
        }    

        case loginActionTypes.HANDLE_LOGIN_FAILURE:
            return{
                ...state,
                loading:false,
                error:action.payload,
                isRedirecting:false
            };

        case loginActionTypes.HANDLE_LOGIN_REQUEST:
            return{
                ...state,
                loading:true,
                error:null,
                isRedirecting:false
            }
        case loginActionTypes.HANDLE_LOGOUT:
            return{
                ...state,
                user:null
            }    
    
        default:
            return state;
    }
}

export default loginReducer;