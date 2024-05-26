import { IoMdHome } from "react-icons/io";
import routesConfig from "../../configs/router";
import { AirplaneTicket, People, RollerShades } from "@mui/icons-material";

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
        title: "Roles",
        icon: <RollerShades size={25} />,
        href: routesConfig.roles,
    },
    {
        title: "Tickets",
        icon: <AirplaneTicket size={25} />,
        href: routesConfig.ticket,
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
