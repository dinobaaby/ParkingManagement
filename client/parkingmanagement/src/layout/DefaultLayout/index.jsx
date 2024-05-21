import React, { useState, useEffect } from "react";
import PropTypes from "prop-types";
import SideBar from "../../components/SideBar/SideBar";
import Header from "./Header";
import Loading from "../../components/Loading/Loading";
import "./DefaultLayout.css";

function DefaultLayout({ children }) {
    const [isMenuOpen, setIsMenuOpen] = useState(false);
    const [loading, setLoading] = useState(true);

    const handleMenuClick = () => {
        setIsMenuOpen(!isMenuOpen);
    };

    useEffect(() => {
        const timer = setTimeout(() => {
            setLoading(false);
        }, 4000);

        return () => clearTimeout(timer);
    }, []);

    return (
        <div className={`wrapper ${!isMenuOpen ? "menu-open" : ""}`}>
            {loading && <Loading />}
            {isMenuOpen && <SideBar handleMenuClick={handleMenuClick} />}
            <div className="container">
                <Header
                    style={!isMenuOpen ? "header-open" : ""}
                    handleMenuClick={handleMenuClick}
                />
                <div className={`content ${isMenuOpen ? "content-open" : ""}`}>
                    {children}
                </div>
            </div>
        </div>
    );
}

DefaultLayout.propTypes = {
    children: PropTypes.node.isRequired,
};

export default DefaultLayout;
