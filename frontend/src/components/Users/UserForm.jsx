import { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import {
  updateUser,
  fetchUser,
  createUser,
} from "../../redux/actions/userActions";
import {
  TextField,
  RadioGroup,
  FormControlLabel,
  Radio,
  Button,
  Grid,
  InputLabel,
} from "@mui/material";
import { useFormik } from "formik";
import * as yup from "yup";

const validationSchema = yup.object({
  username: yup.string().required("Username is required"),
  firstName: yup.string().required("First Name is required"),
  lastName: yup.string().required("Last Name is required"),
  email: yup
    .string()
    .email("Invalid email address")
    .required("Email is required"),
  country: yup.string().required("Country is required"),
  gender: yup.string().required("Gender is required"),
  role: yup.string().required("Role is required"),
  password: yup.string(),
});

const UserForm = ({ userId, handleClose }) => {
  const dispatch = useDispatch();
  if (!userId) {
    validationSchema.password = yup
      .string()
      .required("Password is required")
      .min(8, "Password must be at least 8 characters");
  }
  useEffect(() => {
    if (userId) {
      dispatch(fetchUser(userId));
    }
  }, [dispatch, userId]);

  const userData = useSelector((state) =>
    userId ? state.user.userData : null
  );

  const formik = useFormik({
    initialValues: {
      username: userData?.userName ?? "",
      firstName: userData?.firstName ?? "",
      lastName: userData?.lastName ?? "",
      email: userData?.email ?? "",
      country: userData?.country ?? "",
      gender: userData?.gender ?? "",
      role: userData?.role ?? "",
      password: "",
    },
    validationSchema: validationSchema,
    onSubmit: (user) => {
      if (userId) {
        dispatch(updateUser({userId, user}));
        handleClose();
      } else {
        dispatch(createUser(user));
        handleClose();
      }
    },
    enableReinitialize: true
  });

  return (
    <form onSubmit={formik.handleSubmit}>
      <Grid container spacing={2} sx={{ paddingTop: "5px" }}>
        <Grid item xs={12}>
          <TextField
            label="Username"
            name="username"
            fullWidth
            value={formik.values.username}
            onChange={formik.handleChange}
            error={formik.touched.username && Boolean(formik.errors.username)}
            helperText={formik.touched.username && formik.errors.username}
          />
        </Grid>
        <Grid item xs={6}>
          <TextField
            label="First Name"
            name="firstName"
            fullWidth
            value={formik.values.firstName}
            onChange={formik.handleChange}
            error={formik.touched.firstName && Boolean(formik.errors.firstName)}
            helperText={formik.touched.firstName && formik.errors.firstName}
          />
        </Grid>
        <Grid item xs={6}>
          <TextField
            label="Last Name"
            name="lastName"
            fullWidth
            value={formik.values.lastName}
            onChange={formik.handleChange}
            error={formik.touched.lastName && Boolean(formik.errors.lastName)}
            helperText={formik.touched.lastName && formik.errors.lastName}
          />
        </Grid>
      </Grid>
      <TextField
        label="Email"
        name="email"
        type="email"
        fullWidth
        margin="normal"
        value={formik.values.email}
        onChange={formik.handleChange}
        error={formik.touched.email && Boolean(formik.errors.email)}
        helperText={formik.touched.email && formik.errors.email}
      />
      <Grid container spacing={2}>
        <Grid item xs={6}>
          <TextField
            label="Country"
            name="country"
            fullWidth
            value={formik.values.country}
            onChange={formik.handleChange}
            error={formik.touched.country && Boolean(formik.errors.country)}
            helperText={formik.touched.country && formik.errors.country}
          />
        </Grid>
        <Grid item xs={3}>
          <InputLabel id="gender">Gender</InputLabel>
          <RadioGroup
            style={{ height: "100px" }}
            aria-label="gender"
            name="gender"
            value={formik.values.gender}
            row
            onChange={formik.handleChange}
            error={formik.touched.gender && Boolean(formik.errors.gender)}
          >
            <FormControlLabel value="Male" control={<Radio />} label="Male" />
            <FormControlLabel
              value="Female"
              control={<Radio />}
              label="Female"
            />
          </RadioGroup>
        </Grid>
        <Grid item xs={3}>
          <InputLabel id="role">Role</InputLabel>
          <RadioGroup
            style={{ height: "100px" }}
            aria-label="role"
            name="role"
            value={formik.values.role}
            row
            onChange={formik.handleChange}
            error={formik.touched.role && Boolean(formik.errors.role)}
          >
            <FormControlLabel value="Admin" control={<Radio />} label="Admin" />
            <FormControlLabel value="User" control={<Radio />} label="User" />
          </RadioGroup>
        </Grid>
      </Grid>

      <Grid container spacing={2}>
        <Grid item xs={12}>
          <TextField
            label="Password"
            name="password"
            type="password"
            fullWidth
            value={formik.values.password}
            onChange={formik.handleChange}
            error={formik.touched.password && Boolean(formik.errors.password)}
            helperText={formik.touched.password && formik.errors.password}
          />
        </Grid>
      </Grid>

      <Button
        variant="contained"
        color="primary"
        type="submit"
        disabled={!formik.isValid}
        sx={{ marginTop: 2 }}
      >
        {userId ? "Update" : "Add"}
      </Button>
    </form>
  );
};

export default UserForm;
