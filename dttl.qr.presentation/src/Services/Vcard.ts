import axios from "axios";
import { env } from "../env";
export const getVcardList = () => {
    return axios.get(env.apiUrl + "/api/VCard/GetVCardList")
}

export const getVcardListById = () => {
    return axios.get(env.apiUrl + "/api/VCard/GetVCardById")
}

export const addVcard = (data: any) => {
    return axios.post(env.apiUrl + "/api/VCard/AddVCard", data)
}

export const updateVcard = () => {
    return axios.put(env.apiUrl + "/api/VCard/UpdateVCard")
}

export const deleteVcard = () => {
    return axios.delete(env.apiUrl + "/api/VCard/DeleteVCard")
}