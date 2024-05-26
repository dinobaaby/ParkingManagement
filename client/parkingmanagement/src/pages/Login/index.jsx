import React, { useState, useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
    Box,
    Button,
    FormControl,
    Grid,
    IconButton,
    InputAdornment,
    InputLabel,
    OutlinedInput,
    TextField,
    Checkbox,
    CircularProgress,
} from "@mui/material";
import { Link, useNavigate } from "react-router-dom";
import {
    Visibility,
    VisibilityOff,
    Facebook,
    Google,
} from "@mui/icons-material";
import { authLogin } from "../../features/auth/authAction";

const Login = () => {
    const [showPassword, setShowPassword] = useState(false);
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const dispatch = useDispatch();
    const userData = useSelector((state) => state.auth.user);
    const isLoading = useSelector((state) => state.auth.isLoading);
    const isError = useSelector((state) => state.auth.isError);
    const navigate = useNavigate();

    const handleClickShowPassword = () => setShowPassword(!showPassword);
    const handleMouseDownPassword = (event) => event.preventDefault();

    const handleLogin = () => {
        dispatch(authLogin({ email, password }));
    };

    useEffect(() => {
        if (userData && userData.token) {
            localStorage.setItem("token", userData.token);
            navigate("/");
        } else if (isError) {
            alert(`Error: ${userData.message}`);
        }
    }, [userData, isError, navigate]);

    return (
        <Grid
            container
            justifyContent={"center"}
            alignContent={"center"}
            spacing={2}
            sx={{ height: "100vh", backgroundColor: "#DAF2FF" }}
        >
            <Grid
                item
                minWidth={"450px"}
                width={"min-content"}
                height={"min-content"}
                padding={"30px 0px"}
                sx={{
                    display: "flex",
                    flexDirection: "column",
                    alignItems: "center",
                    justifyContent: "center",
                    backgroundColor: "white",
                    borderRadius: "10px",
                    boxShadow: 1,
                }}
            >
                <Box
                    component="form"
                    sx={{
                        display: "flex",
                        flexDirection: "column",
                        alignItems: "center",
                        justifyContent: "center",
                        width: "80%",
                        height: "min-content",
                    }}
                >
                    <Box
                        component="h1"
                        sx={{
                            p: 2,
                            color: "grey",
                            fontSize: "25px",
                            fontFamily: "cursive",
                        }}
                    >
                        Login to continue
                    </Box>
                    <Box
                        sx={{
                            width: "100%",
                            display: "flex",
                            alignItems: "center",
                            justifyContent: "center",
                        }}
                        mb={2}
                    >
                        <TextField
                            id="email"
                            onChange={(e) => setEmail(e.target.value)}
                            label="Email"
                            variant="outlined"
                            sx={{ width: "70%" }}
                        />
                    </Box>
                    <Box
                        sx={{
                            width: "100%",
                            display: "flex",
                            alignItems: "center",
                            justifyContent: "center",
                        }}
                        mb={2}
                    >
                        <FormControl
                            sx={{ m: 1, width: "70%" }}
                            variant="outlined"
                        >
                            <InputLabel htmlFor="outlined-adornment-password">
                                Password
                            </InputLabel>
                            <OutlinedInput
                                id="outlined-adornment-password"
                                onChange={(e) => setPassword(e.target.value)}
                                type={showPassword ? "text" : "password"}
                                endAdornment={
                                    <InputAdornment position="end">
                                        <IconButton
                                            aria-label="toggle password visibility"
                                            onClick={handleClickShowPassword}
                                            onMouseDown={
                                                handleMouseDownPassword
                                            }
                                            edge="end"
                                        >
                                            {showPassword ? (
                                                <VisibilityOff />
                                            ) : (
                                                <Visibility />
                                            )}
                                        </IconButton>
                                    </InputAdornment>
                                }
                                label="Password"
                            />
                        </FormControl>
                    </Box>
                    <Box
                        sx={{
                            width: "70%",
                            display: "flex",
                            alignItems: "center",
                            justifyContent: "space-between",
                        }}
                    >
                        <Checkbox defaultChecked style={{ padding: 0 }} />
                        <Link
                            style={{
                                textDecoration: "none",
                                color: "grey",
                                fontFamily: "cursive",
                            }}
                            to="/forgot-password"
                        >
                            <p>Forgot Password?</p>
                        </Link>
                    </Box>
                    <Box
                        sx={{
                            width: "100%",
                            display: "flex",
                            alignItems: "center",
                            justifyContent: "center",
                        }}
                        mb={2}
                    >
                        <Button
                            style={{ width: "70%", height: "50px" }}
                            variant="contained"
                            color="success"
                            onClick={handleLogin}
                        >
                            {isLoading ? <CircularProgress /> : "Login"}
                        </Button>
                    </Box>
                </Box>

                <Box
                    mt={2}
                    sx={{
                        display: "flex",
                        justifyContent: "center",
                        alignItems: "center",
                        width: "100%",
                    }}
                >
                    <Box width="18%" height="1px" bgcolor={"gray"}></Box>
                    <p
                        style={{
                            margin: "0 10px",
                            fontFamily: "cursive",
                            color: "gray",
                        }}
                    >
                        {" "}
                        Or login with
                    </p>
                    <Box width="18%" height="1px" bgcolor={"gray"}></Box>
                </Box>
                <Box>
                    <Button
                        style={{
                            width: "50px",
                            height: "60px",
                            marginTop: "20px",
                            borderRadius: "50%",
                        }}
                        variant="contained"
                        color="primary"
                    >
                        <Facebook />
                    </Button>
                    <Button
                        style={{
                            width: "50px",
                            height: "60px",
                            marginTop: "20px",
                            borderRadius: "50%",
                            backgroundColor: "#f44336",
                            marginLeft: "10px",
                        }}
                        variant="contained"
                    >
                        <Google />
                    </Button>
                </Box>
            </Grid>
        </Grid>
    );
};

export default Login;
