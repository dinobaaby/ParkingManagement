import {
  Facebook,
  Google,
  Visibility,
  VisibilityOff,
} from "@mui/icons-material";
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
} from "@mui/material";
import { useState } from "react";
import { Link } from "react-router-dom";
function Login() {
  const [showPassword, setShowPassword] = useState(false);

  const handleClickShowPassword = () => {
    setShowPassword(!showPassword);
  };

  const handleMouseDownPassword = (event) => {
    event.preventDefault();
  };
  return (
    <Grid container spacing={2} sx={{ height: "100vh" }}>
      <Grid
        item
        xs={7}
        sx={{
          backgroundImage:
            "url('https://hoanghamobile.com/tin-tuc/wp-content/uploads/2023/08/hinh-nen-dien-thoai-anime-2.jpg')",
          backgroundRepeat: "no-repeat",
          backgroundSize: "cover",
        }}
      ></Grid>
      <Grid
        item
        xs
        sx={{
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
          justifyContent: "center",
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
            <FormControl sx={{ m: 1, width: "70%" }} variant="outlined">
              <InputLabel htmlFor="outlined-adornment-password">
                Password
              </InputLabel>
              <OutlinedInput
                id="outlined-adornment-password"
                type={showPassword ? "text" : "password"}
                endAdornment={
                  <InputAdornment position="end">
                    <IconButton
                      aria-label="toggle password visibility"
                      onClick={handleClickShowPassword}
                      onMouseDown={handleMouseDownPassword}
                      edge="end"
                    >
                      {showPassword ? <VisibilityOff /> : <Visibility />}
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
            >
              LOGIN
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
          <p style={{ margin: "0 10px", fontFamily: "cursive", color: "gray" }}>
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
}

export default Login;
