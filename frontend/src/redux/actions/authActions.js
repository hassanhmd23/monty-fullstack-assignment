import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";
import { loginApi } from "../../services/authService";

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

export const userLogout = createAsyncThunk("auth/logout", async () => {
  localStorage.clear();
  return true;
});
