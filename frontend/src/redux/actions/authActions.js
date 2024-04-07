import { loginApi } from "../../services/authService";
// export const SET_CURRENT_USER = "SET_CURRENT_USER";

// export const setCurrentUser = (decodedToken) => {
//   return {
//     type: SET_CURRENT_USER,
//     payload: decodedToken,
//   };
// };

// export const login = (values) => {
//   return async (dispatch) => {
//     // Make request to backend to login user
//     const data = await loginApi(values.username, values.password)
//     // Decode token to get user data
//     const decodedToken = jwtDecode(token);
//     // Set token to local storage
//     localStorage.setItem("userToken", token);
//     // Set current user
//     dispatch(setCurrentUser(decodedToken));
//   };
// };

// export const logout = () => {
//   return (dispatch) => {
//     // Remove token from local storage
//     localStorage.removeItem("userToken");
//     // Set current user to null
//     dispatch(setCurrentUser(null));
//   };
// };
import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

export const userLogin = createAsyncThunk(
  "auth/login",
  async ({ username, password }, { rejectWithValue }) => {
    const data = await loginApi(username, password);
    if (axios.isAxiosError(data)) {
      if (data.response && data.response.data.message) {
        return rejectWithValue(data.response.data.message);
      } else {
        return rejectWithValue(data.message);
      }
    } else {
      localStorage.setItem("userToken", data.token);
      return data;
    }
  }
);
