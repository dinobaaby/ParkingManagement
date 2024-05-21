import { configureStore } from "@reduxjs/toolkit";
import roleReducer from "../features/role/roleReducer";

export const store = configureStore({
    reducer: {
        role: roleReducer,
    },
});
