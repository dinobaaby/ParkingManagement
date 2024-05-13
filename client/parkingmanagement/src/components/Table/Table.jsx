import PropTypes from "prop-types";
import "./Table.css";
export default function Table({ header, children }) {
    return (
        <table className="table">
            <thead>
                <tr>
                    <th>
                        <input type="checkbox" />
                    </th>
                    {header.map((item, index) => (
                        <th key={index}>{item}</th>
                    ))}
                </tr>
            </thead>
            <tbody>{children}</tbody>
        </table>
    );
}

Table.propTypes = {
    header: PropTypes.array,
    children: PropTypes.element,
};
