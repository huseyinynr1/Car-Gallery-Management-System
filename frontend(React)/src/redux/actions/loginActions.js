import apiHelper from '../helper/apiHelper';
import * as loginActionTypes from './loginActionTypes';

// Başarılı oturum açma durumunda
export function handleLoginSuccess(data) {
    const token = data.accessToken.token; // Sadece token kısmını alın
    localStorage.setItem("accessToken", token); // Sadece token'ı kaydedin
    return { type: loginActionTypes.HANDLE_LOGIN_SUCCESS, payload: data };
}
// Oturum başarısız olduğunda
export function handleLoginFailure(error) {
    return { type: loginActionTypes.HANDLE_LOGIN_FAILURE, payload: error };
}

export function resetRedirecting() {
    return { type: loginActionTypes.RESET_REDIRECTING };
}

export function handleLogout() {
    localStorage.removeItem("accessToken");
    return { type: loginActionTypes.HANDLE_LOGOUT };
}

// Login işlemi
export const handleLogin = (email, password) => {
    return async (dispatch) => {
        const url = "http://localhost:60805/api/Auth/Login";
        const method = "POST";
        
        try {
            const data = await apiHelper({
                url,
                method,
                body: email,password,  // Gövde verisini ekliyoruz
            });
            
            dispatch(handleLoginSuccess(data));
        } catch (error) {
            console.error("Login Hatası:", error);
            dispatch(handleLoginFailure(error.message));
            throw error;
        }
    };
};
