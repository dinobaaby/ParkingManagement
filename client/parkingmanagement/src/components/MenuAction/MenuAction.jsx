// src/components/RoleActionMenu.js
import React from "react";
import { Menu, MenuItem, IconButton } from "@mui/material";
import MoreVertIcon from "@mui/icons-material/MoreVert";
import PropTypes from "prop-types";
export default function MenuAction({ onEdit, onDelete }) {
    const [anchorEl, setAnchorEl] = React.useState(null);

    const handleClick = (event) => {
        setAnchorEl(event.currentTarget);
    };

    const handleClose = () => {
        setAnchorEl(null);
    };

    return (
        <div>
            <IconButton onClick={handleClick}>
                <MoreVertIcon />
            </IconButton>
            <Menu
                anchorEl={anchorEl}
                open={Boolean(anchorEl)}
                onClose={handleClose}
            >
                <MenuItem onClick={onEdit}>Edit</MenuItem>
                <MenuItem onClick={onDelete}>Delete</MenuItem>
            </Menu>
        </div>
    );
}

MenuAction.propTypes = {
    onEdit: PropTypes.func,
    onDelete: PropTypes.func,
};
