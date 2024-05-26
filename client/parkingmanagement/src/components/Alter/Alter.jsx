import React from "react";
import Snackbar from "@mui/material/Snackbar";
import Alert from "@mui/material/Alert";
import PropTypes from "prop-types";
export default function Alter({ isOpen, title, status }) {
    return (
        <div>
            <Snackbar open={isOpen} autoHideDuration={3000}>
                <Alert
                    severity={status ? "success" : "error"}
                    variant="filled"
                    sx={{ width: "100%" }}
                >
                    {title}
                </Alert>
            </Snackbar>
        </div>
    );
}

Alter.propTypes = {
    isOpen: PropTypes.bool.isRequired,
    title: PropTypes.string.isRequired,
    status: PropTypes.bool.isRequired,
};
