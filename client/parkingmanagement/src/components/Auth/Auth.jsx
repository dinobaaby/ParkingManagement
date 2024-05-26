import { useSelector } from "react-redux";
import "./Auth.css";
import { useState } from "react";
export default function Auth() {
    const [onShowAuthMenu, setOnShowAuthMenu] = useState(false);

    const user = useSelector((state) => state.auth.user);

    const handleShowAuthMenu = () => {
        setOnShowAuthMenu((menu) => !menu);
    };
    return (
        <div className="account-action-auth">
            <img
                onClick={handleShowAuthMenu}
                className="auth-image"
                src="https://cdn-icons-png.flaticon.com/512/149/149071.png"
                alt="user"
            />

            {onShowAuthMenu && (
                <div
                    className="auth-list-action"
                    // style={{
                    //     display: `${onShowNotification ? "block" : "none"}`,
                    // }}
                >
                    <ul className="menu-auth-action">
                        <div>
                            <span>Jaydon Frankie</span>
                            <span>
                                {user.userData
                                    ? user.userData.email
                                    : "admin@gmail.com"}
                            </span>
                        </div>
                        <li>Home</li>
                        <li>Profile</li>
                        <li>Settings</li>
                        <li>Logout</li>
                    </ul>
                </div>
            )}
        </div>
    );
}
