import routesConfig from "../configs/router";
import AccessDenied from "../pages/AccessDenied";
import Home from "../pages/Home";
import Login from "../pages/Login";
import Role from "../pages/Role/Role";
import SignUp from "../pages/SignUp";
import Ticket from "../pages/Ticket/Ticket";
import Users from "../pages/Users/Users";

const publicRoutes = [
    { path: routesConfig.home, component: Home },
    { path: routesConfig.login, component: Login, layout: null },
    { path: routesConfig.singup, component: SignUp, layout: null },
    { path: routesConfig.accessdenied, component: AccessDenied },
    { path: routesConfig.users, component: Users },
    { path: routesConfig.roles, component: Role },
    { path: routesConfig.ticket, component: Ticket },
];

export { publicRoutes };
