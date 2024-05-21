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

const INITIAL_STATE = {
    roles: [],
    roleObj: {},
    isLoading: false,
    isError: false,
    isCreating: false,
    isUpdated: false,
    isDeleted: false,
    isDetailing: false,
};

const roleReducer = (state = INITIAL_STATE, action) => {
    switch (action.type) {
        case FETCH_ROLE_REQUEST:
            console.log(`FETCH_ROLE_REQUEST`, action);
            return {
                ...state,
                isLoading: true,
                isError: false,
            };
        case FETCH_ROLE_SUCCESS:
            console.log(`FETCH_ROLE_SUCCESS`, action);
            return {
                ...state,
                roles: action.payload,
                isLoading: false,
                isError: false,
            };
        case FETCH_ROLE_FAILURE:
            console.log(`FETCH_ROLE_FAILURE`, action);
            return {
                ...state,
                isLoading: false,
                isError: true,
            };
        case CREATE_ROLE_REQUEST:
            console.log(`CREATE_ROLE_REQUEST`, action);
            return {
                ...state,
                isCreating: true,
                isError: false,
            };
        case CREATE_ROLE_SUCCESS:
            console.log(`CREATE_ROLE_SUCCESS`, action);
            return {
                ...state,
                isCreating: false,
                isError: false,
            };
        case CREATE_ROLE_FAILURE:
            console.log(`CREATE_ROLE_FAILURE`, action);
            return {
                ...state,
                isCreating: false,
                isError: true,
            };
        case FETCH_ROLE_BY_ID_REQUEST:
            console.log(`FETCH_ROLE_BY_ID_REQUEST`, action);
            return {
                ...state,
                isDetailing: true,
                isError: false,
            };
        case FETCH_ROLE_BY_ID_SUCCESS:
            console.log(`FETCH_ROLE_BY_ID_SUCCESS`, action);
            return {
                ...state,
                roleObj: action.payload,
                isDetailing: false,
                isError: false,
            };
        case FETCH_ROLE_BY_ID_FAILURE:
            console.log(`FETCH_ROLE_BY_ID_FAILURE`, action);
            return {
                ...state,
                isDetailing: false,
                isError: true,
            };
        default:
            return state;
    }
};

export default roleReducer;
