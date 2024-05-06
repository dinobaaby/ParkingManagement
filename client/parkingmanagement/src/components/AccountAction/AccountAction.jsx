import { IoMdNotifications } from "react-icons/io";
import "./AccountAction.css";
import vn_flag from "../../assets/images/fgvn.svg.webp";
import { useState } from "react";

export default function AccountAction() {
  const [onShowNotification, setOnShowNotification] = useState(false);

  const handleShowNotification = () => {
    setOnShowNotification(!onShowNotification);
  };
  return (
    <div className="account-action">
      <div className="action-item-language">
        <ul className="drop-menu-language">
          <li className="flag-item">
            <img src={vn_flag} width={40} alt="vn_flag" />
          </li>
        </ul>
      </div>
      <div className="action-item-notification">
        <div className="notification-icon">
          <IoMdNotifications onClick={handleShowNotification} size={25} />
        </div>
        <span>0</span>
        <div
          className="notification-list"
          style={{ display: `${onShowNotification ? "block" : "none"}` }}
        >
          <ul>
            <li></li>
            <li></li>
            <li></li>
            <li></li>
          </ul>
        </div>
      </div>
      <div className="account-image"></div>
    </div>
  );
}
