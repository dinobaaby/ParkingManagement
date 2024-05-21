// src/components/Loading.js
import React from "react";
import CircularProgress from "@mui/material/CircularProgress";
import Box from "@mui/material/Box";
import "./Loading.css";
const Loading = () => {
    return (
        <Box className="loading-overlay">
            <CircularProgress />
        </Box>
    );
};

export default Loading;
