import "./Glass.css";
import PropTypes from "prop-types";

export default function Glass({ icon, title, description }) {
    return (
        <div className="glass-item">
            <img src={icon} alt={title} className="glass-item-img" />
            <div className="glass-item-content">
                <span className="glass-content-title">{title}</span>
                <span>{description}</span>
            </div>
        </div>
    );
}

Glass.propTypes = {
    icon: PropTypes.string.isRequired,
    title: PropTypes.string.isRequired,
    description: PropTypes.string.isRequired,
};
