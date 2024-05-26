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
    FETCH_ROLE_BY_ID_SUCCESS,
    FETCH_ROLE_BY_ID_FAILURE,
    FETCH_ROLE_BY_ID_REQUEST,
} from "./roleType.js";
const url = "http://localhost:5102/api/role/";
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

export const createRoleRequest = () => {
    return {
        type: CREATE_ROLE_REQUEST,
    };
};
export const createRoleSuccess = (data) => {
    return {
        type: CREATE_ROLE_SUCCESS,
        payload: data,
    };
};

export const createRoleFailure = () => {
    return {
        type: CREATE_ROLE_FAILURE,
    };
};

export const createNewRole = ({ roleName }) => {
    return async (dispatch, getState) => {
        dispatch(createRoleRequest());
        try {
            let res = await axios.post(
                `http://localhost:5102/api/role?name=${roleName.toUpperCase()}`
            );

            if (res && res.data.isSuccess === true) {
                dispatch(createRoleSuccess(res.data));
                dispatch(fetchAllRoles());
            }
        } catch (error) {
            console.log(error);
            dispatch(createRoleFailure());
        }
    };
};

export const getRoleByIdRequest = () => {
    return {
        type: FETCH_ROLE_BY_ID_REQUEST,
    };
};
export const getRoleByIdSuccess = (data) => {
    return {
        type: FETCH_ROLE_BY_ID_SUCCESS,
        payload: data,
    };
};

export const getRoleByIdFailure = () => {
    return {
        type: FETCH_ROLE_BY_ID_FAILURE,
    };
};

export const fetchRoleById = (id) => {
    return async (dispatch, getState) => {
        dispatch(getRoleByIdRequest());
        try {
            const res = await axios.get(`${url}${id}`);
            const data = res && res.data.result ? res.data.result : {};
            dispatch(getRoleByIdSuccess(data));
        } catch (error) {
            console.log(error);
            dispatch(getRoleByIdFailure());
        }
    };
};

export const deleteRoleByName = ({ name }) => {
    return async (dispatch, getState) => {
        try {
            const res = await axios.delete(`${url}${name}`);
            const data = res && res.data.result ? res.data.resutl : {};
            dispatch(deleteRoleSuccess(data));
            dispatch(fetchAllRoles());
        } catch (err) {
            console.log(`delete role error: ${err}`);
            dispatch(deleteRoleFailure());
        }
    };
};

export const deleteRoleRequest = () => {
    return {
        type: DELETE_ROLE_REQUEST,
    };
};

export const deleteRoleSuccess = (data) => {
    return {
        type: DELETE_ROLE_SUCCESS,
        payload: data,
    };
};
export const deleteRoleFailure = () => {
    return {
        type: DELETE_ROLE_FAILURE,
    };
};
