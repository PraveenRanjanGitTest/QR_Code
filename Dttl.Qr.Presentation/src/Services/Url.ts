import axios from "axios";

export const getUrlQrCodeList = () => {
    return axios.get("https://localhost:7268/api/URL/GetURLQRCodeList")
}

export const getUrlQrCodeListById = () => {
    return axios.get("https://localhost:7268/api/URL/GetURLQRCodeListById")
}

export const addUrlQrCode = () => {
    return axios.post("https://localhost:7268/api/URL/AddURLQRCode")
}

export const updateUrlQrCode = () => {
    return axios.put("https://localhost:7268/api/URL/UpdateURLQRCode")
}

export const deleteUrlQrCode = () => {
    return axios.delete("https://localhost:7268/api/URL/DeleteURLQRCode")
}