import axios from "axios";

export const getQrCodeList = () => {
    return axios.get("https://localhost:7268/api/QRCode/GetQRCodeList")
}

export const getQrCodeListById = () => {
    return axios.get("https://localhost:7268/api/QRCode/GetQRCodeListById")
}

export const addQrTemplate = (data: any) => {
    return axios.post("https://localhost:7268/api/QRCode/AddQRCodes", data)
}

export const updateQr = () => {
    return axios.put("https://localhost:7268/api/QRCode/UpdateQRCode")
}

export const deleteQrCode = () => {
    return axios.delete("https://localhost:7268/api/QRCode/DeleteQRCodes")
}