import customAxios from "../axiosConfig";
import { handleError } from "../helpers/errorHandler";

const url = "account";

export const loginApi = async (username, password) => {
  try {
    const { data } = await customAxios.post(`${url}/login`, {
      username,
      password,
    });
    return data;
  } catch (error) {
    handleError(error);
    return error
  }
};
