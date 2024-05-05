import "./MenuItem.css";
import PropTypes from "prop-types";
import { Link } from "react-router-dom";

export default function MenuItem({ icon, title, onClick, href, isChoose }) {
  return (
    <Link
      to={href}
      className={`menu-item ${isChoose ? "menu-item-active" : ""}`}
      onClick={onClick}
    >
      {icon}
      <span className="menu-item-title">{title}</span>
    </Link>
  );
}

MenuItem.propTypes = {
  icon: PropTypes.element.isRequired,
  title: PropTypes.string.isRequired,
  onClick: PropTypes.func,
  href: PropTypes.string,
  isChoose: PropTypes.bool,
};
