import PropTypes from "prop-types";
import { IoMdMenu } from "react-icons/io";
import "./Header.css";

function Header({ handleMenuClick, style }) {
  return (
    <header className={`header ${style}`}>
      <button onClick={handleMenuClick} className="header-menu">
        <IoMdMenu />
      </button>
      <div className="header-left">
        <div className="header-left-search"></div>
      </div>
    </header>
  );
}

Header.propTypes = {
  handleMenuClick: PropTypes.func.isRequired,
  style: PropTypes.string,
};

export default Header;
