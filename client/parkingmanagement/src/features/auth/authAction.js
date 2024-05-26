import axios from "axios";
import {
    AUTH_LOGIN_REQUEST,
    AUTH_LOGIN_SUCCESS,
    AUTH_LOGIN_FAILURE,
    AUTH_SIGNUP_REQUEST,
    AUTH_SIGNUP_SUCCESS,
    AUTH_SIGNUP_FAILURE,
    AUTH_LOGOUT,
} from "./authType";

const url = "http://localhost:5102/api/auth/";

export const authLoginRequest = () => ({
    type: AUTH_LOGIN_REQUEST,
});

export const authLoginSuccess = (data) => ({
    type: AUTH_LOGIN_SUCCESS,
    payload: data,
});

export const authLoginFailure = (error) => ({
    type: AUTH_LOGIN_FAILURE,
    payload: error,
});

export const authLogin = ({ email, password }) => {
    return async (dispatch) => {
        dispatch(authLoginRequest());
        try {
            const res = await axios.post(`${url}Login`, { email, password });
            console.log(`res`, res);
            if (res.status === 400) {
                authLoginFailure(res.data.result || {});
            }
            const data = res.data.result || {};
            if (data.token) {
                dispatch(authLoginSuccess(data));
                localStorage.setItem("token", data.token);
            } else {
                dispatch(authLoginFailure("Invalid login response"));
            }
        } catch (error) {
            dispatch(authLoginFailure(error.message));
            localStorage.removeItem("token");
        }
    };
};

export const authLogout = () => {
    localStorage.removeItem("token");
    return { type: AUTH_LOGOUT }; // Assuming you have an AUTH_LOGOUT action type
};
