// import { SET_CURRENT_USER } from "../actions/authActions";

// const initialState = {
//   isAuthenticated: false,
//   isAdmin: false,
//   user: {},
// };
// const authReducer = (state = initialState, action) => {
//   switch (action.type) {
//     case SET_CURRENT_USER:
//       return {
//         ...state,
//         isAuthenticated: action.payload !== null,
//         isAdmin: action.payload.role === "Admin",
//         user: action.payload,
//       };
//     default:
//       return state;
//   }
// };

// export default authReducer;
import { jwtDecode } from "jwt-decode";
import { createSlice } from "@reduxjs/toolkit";
import { userLogin } from "../actions/authActions";

const userToken = localStorage.getItem("userToken")
  ? localStorage.getItem("userToken")
  : null;

const decodedToken = userToken? jwtDecode(userToken) : null;

const initialState = {
  loading: false,
  isAdmin: decodedToken? decodedToken.role === "Admin" : false,
  userToken,
  error: null,
  success: false,
};

const authSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(userLogin.pending, (state) => {
        state.loading = true;
        state.error = null;
        state.success = false;
      })
      .addCase(userLogin.fulfilled, (state, action) => {
        state.loading = false;
        state.isAdmin = jwtDecode(action.payload.token).role === "Admin";
        state.userToken = action.payload.token;
        state.success = true;
      })
      .addCase(userLogin.rejected, (state, action) => {
        state.loading = false;
        state.error = action.payload;
        state.success = false;
        state.userToken = null;
        state.isAdmin = false;
        localStorage.clear();
      });
  },
});

export default authSlice.reducer;
