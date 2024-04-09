import customAxios from "../axiosConfig";
import { handleError } from "../helpers/errorHandler";

const url = "user";

export const fetchAllUsersAPI = async () => {
  try {
    const { data } = await customAxios.get(`${url}`);
    return data;
  } catch (error) {
    handleError(error);
    return error;
  }
};

export const fetchUserAPI = async (userId) => {
  try {
    const { data } = await customAxios.get(`${url}/${userId}`);
    return data;
  } catch (error) {
    handleError(error);
    return error;
  }
};

export const createUserAPI = async (user) => {
  try {
    const { data } = await customAxios.post(`${url}`, user);
    return data;
  } catch (error) {
    handleError(error);
    return error;
  }
};

export const updateUserAPI = async (userId, user) => {
  try {
    console.log(user);
    console.log(userId);
    const { data } = await customAxios.put(`${url}/${userId}`, user);
    return data;
  } catch (error) {
    handleError(error);
    return error;
  }
};

export const deleteUserAPI = async (userId) => {
  try {
    const { data } = await customAxios.delete(`${url}/${userId}`);
    console.log(data);
    return data;
  } catch (error) {
    handleError(error);
    return error;
  }
};
