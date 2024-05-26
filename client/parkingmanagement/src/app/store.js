import { configureStore } from "@reduxjs/toolkit";
import roleReducer from "../features/role/roleReducer";
import authReducer from "../features/auth/authReducer";
export const store = configureStore({
    reducer: {
        role: roleReducer,
        auth: authReducer,
    },
});
