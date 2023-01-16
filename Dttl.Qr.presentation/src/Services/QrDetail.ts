import axios from "axios";
import { env } from "../env";
export const getQrDetailList = () => {
    return axios.get(env.apiUrl + "/api/QRDetail/GetQRDetailList")
}

export const getQrDetailListById = () => {
    return axios.get(env.apiUrl + "/api/QRDetail/GetQRDetailListById")
}

export const addQrDetail = (data: any) => {
    return axios.post(env.apiUrl + "/api/QRDetail/AddQRDetails", data)
}

export const updateQrDetail = () => {
    return axios.put(env.apiUrl + "/api/QRDetail/UpdateQReDetails")
}

export const deleteQrDetail = () => {
    return axios.delete(env.apiUrl + "/api/QRDetail/DeleteQRDetails")
}