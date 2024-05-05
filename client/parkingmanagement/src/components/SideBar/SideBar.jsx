import Logo from "../Logo/Logo";
import Menu from "../Menu/Menu";
import "./SideBar.css";

function SideBar() {
  return (
    <aside className="sidebar">
      <Logo />
      <Menu />
    </aside>
  );
}

export default SideBar;
