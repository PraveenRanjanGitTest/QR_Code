import axios from "axios";
import { env } from "../env";

export const getQrCodeList = () => {
    return axios.get(env.apiUrl + "/api/QRCode/GetQRCodeList")
}

export const getQrCodeListById = () => {
    return axios.get(env.apiUrl + "/api/QRCode/GetQRCodeListById")
}

export const addQrTemplate = (data: any) => {
    return axios.post(env.apiUrl + "/api/QRCode/AddQRCodes", data)
}

export const updateQr = () => {
    return axios.put(env.apiUrl + "/api/QRCode/UpdateQRCode")
}

export const deleteQrCode = () => {
    return axios.delete(env.apiUrl + "/api/QRCode/DeleteQRCodes")
}