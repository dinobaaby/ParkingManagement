import PropTypes from "prop-types";
import { CiMenuKebab } from "react-icons/ci";
import "./UserRow.css";
import { useState } from "react";
export default function UserRow({ user }) {
    const [onShowUserAction, setOnShowUserAction] = useState(false);

    const handleShowUserAction = () => {
        setOnShowUserAction((menu) => !menu);
    };
    return (
        <tr>
            <td>
                <input type="checkbox" />
            </td>
            <td>{user.name}</td>
            <td>{user.email}</td>
            <td>{user.phoneNumber}</td>
            <td>{user.cardId}</td>
            <td className="user-item-action">
                <CiMenuKebab onClick={handleShowUserAction} color="black" />
                {onShowUserAction && (
                    <div className="user-action-list">
                        <button>Edit</button>
                        <button>Delete</button>
                    </div>
                )}
            </td>
        </tr>
    );
}

UserRow.propTypes = {
    user: PropTypes.object,
};
