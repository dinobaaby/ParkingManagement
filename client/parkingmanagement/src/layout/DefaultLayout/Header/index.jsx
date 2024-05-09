import PropTypes from "prop-types";
import { IoMdMenu } from "react-icons/io";
import "./Header.css";
import AccountAction from "../../../components/AccountAction/AccountAction";
import { Close, Search } from "@mui/icons-material";
import { useState } from "react";

function Header({ handleMenuClick, style }) {
    const [isSearchOpen, setIsSearchOpen] = useState(false);

    const handleOpenSearch = () => {
        setIsSearchOpen(true);
    };
    const handleCloseSearch = () => {
        if (isSearchOpen) {
            setIsSearchOpen(false);
            return;
        }
        return;
    };
    const handleBlur = () => {
        setIsSearchOpen(false);
    };
    return (
        <>
            {isSearchOpen ? (
                <>
                    <div
                        className={`search-container`}
                        onBlur={handleBlur}
                        tabIndex="0"
                    >
                        <div className="search-container-input">
                            <Search />
                            <input placeholder="Search..." />
                        </div>
                        <button className="search-container-btn">Search</button>
                        {isSearchOpen && (
                            <button
                                onClick={handleCloseSearch}
                                className="search-close-btn"
                            >
                                <Close style={{ width: "20px" }} />
                            </button>
                        )}
                    </div>
                    <header className={`header ${style}`}>
                        <div className="header-left-action">
                            <button
                                onClick={handleMenuClick}
                                className="header-menu"
                            >
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
                        <button
                            onClick={handleMenuClick}
                            className="header-menu"
                        >
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
            )}
        </>
    );
}

Header.propTypes = {
    handleMenuClick: PropTypes.func.isRequired,
    style: PropTypes.string,
};

export default Header;
