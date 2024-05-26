import {
    AUTH_LOGIN_REQUEST,
    AUTH_LOGIN_SUCCESS,
    AUTH_LOGIN_FAILURE,
    AUTH_SIGNUP_REQUEST,
    AUTH_SIGNUP_SUCCESS,
    AUTH_SIGNUP_FAILURE,
} from "./authType";

const INITIAL_STATE = {
    isLoading: false,
    isError: false,
    isAuth: false,
    user: {},
};

const authReducer = (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case AUTH_LOGIN_REQUEST:
            console.log(`AUTH_LOGIN_REQUEST`, action);
            return {
                ...state,
                isLoading: true,
                isError: false,
            };
        case AUTH_LOGIN_SUCCESS:
            console.log(`AUTH_LOGIN_SUCCESS`, action);
            return {
                ...state,
                user: action.payload,
                isLoading: false,
                isError: false,
                isAuth: true,
            };
        case AUTH_LOGIN_FAILURE:
            console.log(`AUTH_LOGIN_FAILURE`, action);
            return {
                ...state,
                user: action.payload,
                isLoading: false,
                isError: true,
                isAuth: false,
            };
        default:
            return state;
    }
};

export default authReducer;
