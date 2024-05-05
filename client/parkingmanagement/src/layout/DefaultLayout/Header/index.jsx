import PropTypes from "prop-types";
import { IoMdMenu } from "react-icons/io";
import "./Header.css";
import AccountAction from "../../../components/AccountAction/AccountAction";

function Header({ handleMenuClick, style }) {
  return (
    <header className={`header ${style}`}>
      <button onClick={handleMenuClick} className="header-menu">
        <IoMdMenu />
      </button>
      <div className="header-account-actions">
        <AccountAction />
      </div>
    </header>
  );
}

Header.propTypes = {
  handleMenuClick: PropTypes.func.isRequired,
  style: PropTypes.string,
};

export default Header;
