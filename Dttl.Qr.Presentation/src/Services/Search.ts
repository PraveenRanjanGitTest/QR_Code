import axios from "axios";

export const getSearchByFilter = () => {
    return axios.get("https://localhost:7268/api/Search/GetSearchByFilter")
}