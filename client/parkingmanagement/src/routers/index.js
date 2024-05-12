import routesConfig from "../configs/router";
import AccessDenied from "../pages/AccessDenied";
import Home from "../pages/Home";
import Login from "../pages/Login";
import SignUp from "../pages/SignUp";
import Users from "../pages/Users/Users";

const publicRoutes = [
    { path: routesConfig.home, component: Home },
    { path: routesConfig.login, component: Login, layout: null },
    { path: routesConfig.singup, component: SignUp, layout: null },
    { path: routesConfig.accessdenied, component: AccessDenied },
    { path: routesConfig.users, component: Users },
];

export { publicRoutes };
