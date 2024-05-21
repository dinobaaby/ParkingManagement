import axios from "axios";

import {
    FETCH_ROLE_REQUEST,
    FETCH_ROLE_SUCCESS,
    FETCH_ROLE_FAILURE,
    CREATE_ROLE_REQUEST,
    CREATE_ROLE_SUCCESS,
    CREATE_ROLE_FAILURE,
    UPDATE_ROLE_REQUEST,
    UPDATE_ROLE_SUCCESS,
    UPDATE_ROLE_FAILURE,
    DELETE_ROLE_REQUEST,
    DELETE_ROLE_SUCCESS,
    DELETE_ROLE_FAILURE,
} from "./roleType.js";

export const fetchAllRoles = () => {
    return async (dispatch, getState) => {
        dispatch(fetchRolesRequest());
        try {
            const res = await axios.get(
                "http://localhost:5102/api/role/GetRoleWithUser"
            );
            const data = res && res.data.result ? res.data.result : [];
            dispatch(fetchRolesSuccess(data));
        } catch (error) {
            console.log(error);
            dispatch(fetchRolesFailure());
        }
    };
};

export const fetchRolesRequest = () => {
    return {
        type: FETCH_ROLE_REQUEST,
    };
};

export const fetchRolesSuccess = (roles) => {
    return {
        type: FETCH_ROLE_SUCCESS,
        payload: roles,
    };
};

export const fetchRolesFailure = () => {
    return {
        type: FETCH_ROLE_FAILURE,
    };
};
