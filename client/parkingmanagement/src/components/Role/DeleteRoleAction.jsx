import { Box, Button, Modal, Typography } from "@mui/material";
import React, { useState } from "react";
import { IoIosWarning } from "react-icons/io";
const style = {
    position: "absolute",
    top: "30%",
    left: "50%",
    transform: "translate(-40%, -50%)",
    width: 400,
    height: 200,
    bgcolor: "background.paper",
    boxShadow: 24,
    p: 4,
};

export default function DeleteRoleAction() {
    const [open, setOpen] = React.useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);

    return (
        <>
            <Button
                size="small"
                variant="contained"
                color="error"
                style={{ marginRight: "10px" }}
                onClick={handleOpen}
            >
                Delete
            </Button>
            <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
            >
                <Box sx={style}>
                    <Typography
                        id="modal-modal-title"
                        variant="h6"
                        component="h2"
                    >
                        Do you want to delete this role?
                    </Typography>
                    <center>
                        <IoIosWarning size={100} color="red" />
                    </center>
                    <Box
                        width={"100%"}
                        display={"flex"}
                        justifyContent={"space-between"}
                    >
                        <Button variant="contained" color="error">
                            Yes
                        </Button>
                        <Button
                            variant="contained"
                            color="success"
                            onClick={handleClose}
                        >
                            No
                        </Button>
                    </Box>
                </Box>
            </Modal>
        </>
    );
}
