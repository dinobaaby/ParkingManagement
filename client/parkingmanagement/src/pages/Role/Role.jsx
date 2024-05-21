import { DataGrid } from "@mui/x-data-grid";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
const columns = [
    { field: "id", headerName: "STT", width: 90 },
    { field: "Name", headerName: "Name", width: 230 },
    { field: "TotalUser", headerName: "Total User", width: 230 },
];
import { fetchAllRoles } from "../../features/role/roleAction.js";

export default function Role() {
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
    );
}
