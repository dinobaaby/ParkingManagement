import { FaSquareParking } from "react-icons/fa6";
import "./Logo.css";
import { Link } from "react-router-dom";

export default function Logo() {
  return (
    <div className="logo">
      <Link
        style={{ textDecoration: "none", display: "flex", gap: "20px" }}
        to="/"
      >
        <FaSquareParking size={40} />
        <span className="logo-text">Parking</span>
      </Link>
    </div>
  );
}
