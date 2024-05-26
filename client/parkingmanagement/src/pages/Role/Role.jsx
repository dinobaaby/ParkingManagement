import { DataGrid } from "@mui/x-data-grid";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { fetchAllRoles } from "../../features/role/roleAction.js";
import { Button, CircularProgress, Grid } from "@mui/material";
import DeleteRoleAction from "../../components/Role/DeleteRoleAction.jsx";
import CreateRole from "../../components/Role/CreateRole.jsx";
import Alter from "../../components/Alter/Alter.jsx";

export default function Role() {
    const columns = [
        { field: "id", headerName: "STT", width: 90 },
        { field: "Name", headerName: "Name", width: 230 },
        { field: "TotalUser", headerName: "Total User", width: 230 },
        {
            field: "Action",
            headerName: "Action",
            width: 230,
            renderCell(params) {
                return (
                    <>
                        <DeleteRoleAction roleData={params.row} />
                    </>
                );
            },
        },
    ];

    const dispatch = useDispatch();
    const listRole = useSelector((state) => state.role.roles);
    const roleData = listRole
        ? listRole.map((item, index) => {
              return {
                  id: index + 1,
                  Name: item.roleName,
                  TotalUser: item.totalUser,
              };
          })
        : [];
    const isCreated = useSelector((state) => state.role.isCreating);
    console.log({ isCreated });
    const isLoading = useSelector((state) => state.role.isLoading);

    const handleEdit = (role) => {
        console.log("Edit role:", role);
        // Implement edit logic here
    };

    const handleDelete = (role) => {
        console.log("Delete role:", role);
        // Implement delete logic here
    };
    useEffect(() => {
        dispatch(fetchAllRoles());
    }, []);

    return (
        <div
            style={{
                height: "calc(100vh - 100px)",
                width: "100%",
                padding: "20px",
            }}
        >
            <Grid
                container
                spacing={2}
                style={{ justifyContent: "space-between" }}
                mb={3}
                height={"min-content"}
            >
                <CreateRole />
            </Grid>
            {isLoading === true ? (
                <CircularProgress />
            ) : (
                <div style={{ height: 400, width: "100%" }}>
                    <DataGrid
                        rows={roleData}
                        columns={columns}
                        initialState={{
                            pagination: {
                                paginationModel: { page: 0, pageSize: 5 },
                            },
                        }}
                        pageSizeOptions={[5, 10]}
                        checkboxSelection
                        style={{ backgroundColor: "white" }}
                    />
                </div>
            )}
            {isCreated && (
                <Alter
                    isOpen={true}
                    title="Create role success"
                    status={true}
                />
            )}
        </div>
    );
}
