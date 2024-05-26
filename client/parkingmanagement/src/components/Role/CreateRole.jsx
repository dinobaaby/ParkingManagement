import React, { useState } from "react";
import TextField from "@mui/material/TextField";
import { useDispatch, useSelector } from "react-redux";
import { Button, Grid } from "@mui/material";

import { FaPlus } from "react-icons/fa6";
import { createNewRole } from "../../features/role/roleAction";
export default function CreateRole() {
    const [roleName, setRoleName] = useState("");
    const dispatch = useDispatch();

    const handleCreateRole = () => {
        dispatch(createNewRole({ roleName }));
        setRoleName("");
    };
    return (
        <>
            <Grid item xs={10}>
                <TextField
                    id="outlined-multiline-flexible"
                    label="Role Name"
                    multiline
                    maxRows={4}
                    size="large"
                    style={{ width: "100%" }}
                    value={roleName.toUpperCase()}
                    onChange={(e) => setRoleName(e.target.value.toUpperCase())}
                />
            </Grid>
            <Grid item xs={2}>
                <Button
                    style={{ height: "56px", width: "100%" }}
                    variant="contained"
                    color="success"
                    startIcon={<FaPlus />}
                    size="large"
                    onClick={() => handleCreateRole()}
                >
                    Create
                </Button>
            </Grid>
        </>
    );
}
