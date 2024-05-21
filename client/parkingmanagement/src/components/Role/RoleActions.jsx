import { Card } from "@mui/material";
import React from "react";
import DeleteRoleAction from "./DeleteRoleAction";
import EditRoleAction from "./EditRoleAction";

export default function RoleActions() {
    return (
        <>
            <DeleteRoleAction />
            <EditRoleAction />
        </>
    );
}
