import axios from "axios";

const customAxios = axios.create({
  baseURL: "http://localhost:5246/api/",
});

export default customAxios;
