import axios from "axios";

export const getQrDetailList = () => {
    return axios.get("https://localhost:7268/api/QRDetail/GetQRDetailList")
}

export const getQrDetailListById = () => {
    return axios.get("https://localhost:7268/api/QRDetail/GetQRDetailListById")
}

export const addQrDetail = () => {
    return axios.post("https://localhost:7268/api/QRDetail/AddQRDetails")
}

export const updateQrDetail = () => {
    return axios.put("https://localhost:7268/api/QRDetail/UpdateQReDetails")
}

export const deleteQrDetail = () => {
    return axios.delete("https://localhost:7268/api/QRDetail/DeleteQRDetails")
}