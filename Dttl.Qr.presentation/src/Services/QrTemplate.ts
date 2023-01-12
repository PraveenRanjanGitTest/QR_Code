import axios from "axios";
import { env } from "../env";

export const getQrTemplateList = () => {
    return axios.get(env.apiUrl + "/api/QRTemplate/GetQRTemplateList")
}

export const getQrTemplateListById = () => {
    axios.get(env.apiUrl + "/api/QRTemplate/GetQRTemplateListById")
}

export const addQrTemplate = (data: any) => {
    return axios.post(env.apiUrl + "/api/QRTemplate/AddQRTemplate", data)
}

export const updateQrTemplate = (data: any) => {
    axios.put(env.apiUrl + "/api/QRTemplate/UpdateQRTemplate", data)
}

export const deleteQrTemplate = () => {
    axios.delete(env.apiUrl + "/api/QRTemplate/DeleteQRTemplate")
}