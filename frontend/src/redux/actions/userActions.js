import { createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";
import {
  createUserAPI,
  fetchAllUsersAPI,
  updateUserAPI,
  deleteUserAPI,
  fetchUserAPI,
} from "../../services/userService";

export const fetchUsers = createAsyncThunk(
  "user/fetchAll",
  async (_, { rejectWithValue }) => {
    const data = await fetchAllUsersAPI();
    if (axios.isAxiosError(data)) {
      if (data.response && data.response.data.message) {
        return rejectWithValue(data.response.data.message);
      } else {
        return rejectWithValue(data.message);
      }
    } else {
      return data;
    }
  }
);

export const createUser = createAsyncThunk(
  "user/create",
  async (user, { rejectWithValue }) => {
    const data = await createUserAPI(user);
    if (axios.isAxiosError(data)) {
      if (data.response && data.response.data.message) {
        return rejectWithValue(data.response.data.message);
      } else {
        return rejectWithValue(data.message);
      }
    } else {
      return data;
    }
  }
);

export const updateUser = createAsyncThunk(
  "user/update",
  async ({ userId, user }, { rejectWithValue }) => {
    const data = await updateUserAPI(userId, user);
    if (axios.isAxiosError(data)) {
      if (data.response && data.response.data.message) {
        return rejectWithValue(data.response.data.message);
      } else {
        return rejectWithValue(data.message);
      }
    } else {
      return data;
    }
  }
);

export const deleteUser = createAsyncThunk(
  "user/delete",
  async (userId, { rejectWithValue }) => {
    const data = await deleteUserAPI(userId);
    if (axios.isAxiosError(data)) {
      if (data.response && data.response.data.message) {
        return rejectWithValue(data.response.data.message);
      } else {
        return rejectWithValue(data.message);
      }
    } else {
      return userId;
    }
  }
);

export const fetchUser = createAsyncThunk(
  "user/fetchUser",
  async (userId, { rejectWithValue }) => {
    const data = await fetchUserAPI(userId);
    if (axios.isAxiosError(data)) {
      if (data.response && data.response.data.message) {
        return rejectWithValue(data.response.data.message);
      } else {
        return rejectWithValue(data.message);
      }
    } else {
      return data;
    }
  }
);