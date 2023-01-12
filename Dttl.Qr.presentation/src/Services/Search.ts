import axios from "axios";
import { env } from "../env";
export const getSearchByFilter = () => {
    return axios.get(env.apiUrl + "/api/Search/GetSearchByFilter")
}