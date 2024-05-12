import { IoMdHome } from "react-icons/io";
import routesConfig from "../../configs/router";
import { People } from "@mui/icons-material";

const MenuConfig = [
    {
        title: "Dashboards",
        icon: <IoMdHome size={25} />,
        href: routesConfig.home,
    },
    {
        title: "Users",
        icon: <People size={25} />,
        href: routesConfig.users,
    },
    {
        title: "Access Denied",
        icon: <IoMdHome size={25} />,
        href: routesConfig.accessdenied,
    },
    {
        title: "Dashboards",
        icon: <IoMdHome size={25} />,
        href: routesConfig.home,
    },
    {
        title: "Dashboards",
        icon: <IoMdHome size={25} />,
        href: routesConfig.home,
    },
    {
        title: "Dashboards",
        icon: <IoMdHome size={25} />,
        href: routesConfig.home,
    },
    {
        title: "Login",
        icon: <IoMdHome size={25} />,
        href: routesConfig.login,
    },
];

export default MenuConfig;
