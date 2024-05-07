import PropTypes from "prop-types";
import { IoMdMenu } from "react-icons/io";
import "./Header.css";
import AccountAction from "../../../components/AccountAction/AccountAction";
import { Search } from "@mui/icons-material";
import { useState } from "react";

function Header({ handleMenuClick, style }) {
  const [isSearchOpen, setIsSearchOpen] = useState(false);

  const handleOpenSearch = () => {
    setIsSearchOpen(true);
  };
  return (
    <>
      {isSearchOpen ? (
        <>
          <div className={`search-container`}>
            <div className="search-container-input">
              <Search />
              <input placeholder="Search..." />
            </div>
            <button>Search</button>
          </div>
          <header className={`header ${style}`}>
            <div className="header-left-action">
              <button onClick={handleMenuClick} className="header-menu">
                <IoMdMenu />
              </button>
              <button
                onClick={handleOpenSearch}
                className="header-search-button"
              >
                <Search />
              </button>
            </div>
            <div className="header-account-actions">
              <AccountAction />
            </div>
          </header>
        </>
      ) : (
        <header className={`header ${style}`}>
          <div className="header-left-action">
            <button onClick={handleMenuClick} className="header-menu">
              <IoMdMenu />
            </button>
            <button onClick={handleOpenSearch} className="header-search-button">
              <Search />
            </button>
          </div>
          <div className="header-account-actions">
            <AccountAction />
          </div>
        </header>
      )}
    </>
  );
}

Header.propTypes = {
  handleMenuClick: PropTypes.func.isRequired,
  style: PropTypes.string,
};

export default Header;
