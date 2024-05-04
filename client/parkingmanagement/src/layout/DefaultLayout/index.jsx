import SideBar from "../../components/SideBar/SideBar";
import Header from "./Header";
import PropTypes from "prop-types";
import "./DefaultLayout.css";
import { useState } from "react";

function DefaultLayout({ children }) {
  const [isMenuOpen, setIsMenuOpen] = useState(false);

  const handleMenuClick = () => {
    setIsMenuOpen(!isMenuOpen);
  };

  return (
    <div className={`wrapper ${!isMenuOpen ? "menu-open" : ""}`}>
      {isMenuOpen && <SideBar handleMenuClick={handleMenuClick} />}
      <div className="container">
        <Header
          style={!isMenuOpen ? "header-open" : ""}
          handleMenuClick={handleMenuClick}
        />
        <div className="content">{children}</div>
      </div>
    </div>
  );
}

DefaultLayout.propTypes = {
  children: PropTypes.node.isRequired,
};

export default DefaultLayout;
