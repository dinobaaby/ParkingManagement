import MenuConfig from "./Menu.Config";
import MenuItem from "./MenuItem/MenuItem";
import "./Menu.css";
import { useState } from "react";
export default function Menu() {
  const [menuActive, setMenuActive] = useState(0);

  const handleClickMenu = (index) => {
    setMenuActive(index);
  };
  return (
    <div className="sidebar-menus">
      {MenuConfig.map((menu, index) => {
        return (
          <MenuItem
            key={index}
            icon={menu.icon}
            title={menu.title}
            href={menu.href}
            isChoose={index === menuActive ? true : false}
            onClick={() => handleClickMenu(index)}
          />
        );
      })}
    </div>
  );
}
