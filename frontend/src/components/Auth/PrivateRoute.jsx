import { useSelector } from "react-redux";
import { useNavigate, Outlet } from "react-router-dom";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";
import CssBaseline from "@mui/material/CssBaseline";
import Layout from "../Layout/Layout";

const defaultTheme = createTheme();

const PrivateRoute = () => {
  const { isAdmin } = useSelector((state) => state.auth);
  const navigate = useNavigate();

  const handleClick = () => {
    navigate("/login");
  };

  if (!isAdmin) {
    return (
      <Box
        height="100vh"
        width="100vw"
        display="flex"
        alignItems="center"
        justifyContent="center"
        flexDirection="column"
      >
        <Typography component="h2" variant="h2">
          Unauthorized :(
        </Typography>
        <Typography component="h4" variant="h4">
          Login with admin privileges to gain access
        </Typography>
        <Button
          variant="contained"
          color="primary"
          onClick={handleClick}
          sx={{ height: "60px", fontSize: "24px", marginTop: "20px" }}
        >
          Login
        </Button>
      </Box>
    );
  }

  return (
    <ThemeProvider theme={defaultTheme}>
      <Box sx={{ display: "flex", height: "100vh", background: "#f4f7ff" }}>
        <CssBaseline />
        <Layout>
          <Outlet />
        </Layout>
      </Box>
    </ThemeProvider>
  );
};
export default PrivateRoute;
