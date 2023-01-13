import axios from "axios";
import { env } from "../env";
export const getUrlQrCodeList = () => {
    return axios.get(env.apiUrl + "/api/URL/GetURLQRCodeList")
}

export const getUrlQrCodeListById = () => {
    return axios.get(env.apiUrl + "/api/URL/GetURLQRCodeListById")
}

export const addUrlQrCode = (data: any) => {
    return axios.post(env.apiUrl + "/api/URL/AddURLQRCode", data)
}

export const updateUrlQrCode = () => {
    return axios.put(env.apiUrl + "/api/URL/UpdateURLQRCode")
}

export const deleteUrlQrCode = () => {
    return axios.delete(env.apiUrl + "/api/URL/DeleteURLQRCode")
}