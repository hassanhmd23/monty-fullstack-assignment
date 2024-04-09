import { Typography, Paper, Box, Grid } from "@mui/material";
import { useParams } from "react-router-dom";
import { useSelector } from "react-redux";
import Loader from "../common/Loader";

const UserPage = () => {
  const { id } = useParams();
  const user = useSelector((state) =>
    state.user.users.find((user) => user.id === id)
  );
  const loading = useSelector((state) => state.user.loading);

  if (loading) {
    return <Loader />;
  }

  if (!user) {
    return (
      <Typography variant="h4">
        There&apos;s no such User with that ID!
      </Typography>
    );
  }

  return (
    <Box p={2}>
      <Paper
        elevation={3}
        sx={{
          width: "50%",
          marginLeft: "auto",
          marginRight: "auto",
          padding: "60px",
        }}
      >
        <Typography
          variant="h6"
          gutterBottom
          sx={{ marginBottom: 2, padding: "0px" }}
        >
          User Details
        </Typography>
        <Grid container spacing={2}>
          <Grid item xs={12} sm={6}>
            <Typography variant="subtitle1">
              <strong>Name:</strong> {user.firstName} {user.lastName}
            </Typography>
          </Grid>
          <Grid item xs={12} sm={6}>
            <Typography variant="subtitle1">
              <strong>Username:</strong> {user.userName}
            </Typography>
          </Grid>
          <Grid item xs={12} sm={6}>
            <Typography variant="subtitle1">
              <strong>Email:</strong> {user.email}
            </Typography>
          </Grid>
          <Grid item xs={12} sm={6}>
            <Typography variant="subtitle1">
              <strong>Gender:</strong> {user.gender}
            </Typography>
          </Grid>
          <Grid item xs={12} sm={6}>
            <Typography variant="subtitle1">
              <strong>Country:</strong> {user.country}
            </Typography>
          </Grid>
          <Grid item xs={12} sm={6}>
            <Typography variant="subtitle1">
              <strong>Role:</strong> {user.role}
            </Typography>
          </Grid>
        </Grid>
      </Paper>
    </Box>
  );
};

export default UserPage;
