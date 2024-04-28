import SideBar from "../../components/SideBar/SideBar";
import Header from "./Header";
import PropTypes from "prop-types";
import "./DefaultLayout.css";
function DefaultLayout({ children }) {
  return (
    <div className="wrapper">
      <SideBar />
      <div className="container">
        <Header />
        <div className="content">{children}</div>
      </div>
    </div>
  );
}

DefaultLayout.propTypes = {
  children: PropTypes.node.isRequired,
};
export default DefaultLayout;
