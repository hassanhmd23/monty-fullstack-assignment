import { useSelector } from "react-redux";
import { NavLink, Outlet } from "react-router-dom";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import Box from "@mui/material/Box";
import CssBaseline from "@mui/material/CssBaseline";
import Layout from "../Layout/Layout";

const defaultTheme = createTheme();

const PrivateRoute = () => {
  const { isAdmin } = useSelector((state) => state.auth);

  if (!isAdmin) {
    return (
      <div className="unauthorized">
        <h1>Unauthorized :(</h1>
        <span>
          <NavLink to="/login">Login</NavLink> with admin privileges to gain
          access
        </span>
      </div>
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
