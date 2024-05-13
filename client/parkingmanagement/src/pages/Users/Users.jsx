import Table from "../../components/Table/Table";
import UserRow from "../../components/UserRow/UserRow";
import "./Users.css";

export default function Users() {
    const user = {
        name: "John Doe",
        email: "hoasfaosf@gmail.com",
        phoneNumber: "123456789",
        cardId: "123456789",
    };
    return (
        <div className="users-page">
            <div className="users-page-header">
                <h1>Users</h1>
                <button className="create-new-user-btn">+ New User </button>
            </div>
            <div className="users-data">
                <Table
                    header={[
                        "Name",
                        "Email",
                        "Phone Number",
                        "Card ID",
                        "Action",
                    ]}
                >
                    <UserRow user={user} />
                    <UserRow user={user} />
                    <UserRow user={user} />
                    <UserRow user={user} />
                    <UserRow user={user} />
                </Table>
            </div>
        </div>
    );
}
