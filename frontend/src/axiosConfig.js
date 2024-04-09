import axios from "axios";

const customAxios = axios.create({
  baseURL: "http://localhost:5246/api/",
});

customAxios.interceptors.request.use((config) => {
  const token = localStorage.getItem("userToken");
  if (token) {
    config.headers["Authorization"] = `Bearer ${token}`;
  }
  return config;
});

export default customAxios;
