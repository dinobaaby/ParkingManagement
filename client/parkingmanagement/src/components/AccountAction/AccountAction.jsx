import { IoMdNotifications } from "react-icons/io";
import "./AccountAction.css";

export default function AccountAction() {
  return (
    <div className="account-action">
      <div className="action-item-language"></div>
      <div className="action-item-notification">
        <div className="notification-icon">
          <IoMdNotifications />
        </div>
      </div>
      <div className="account-image"></div>
    </div>
  );
}
