import axios from "axios";

export const getQrTemplateList = () => {
    axios.get("https://localhost:7268/api/QRTemplate/GetQRTemplateList")
}

export const getQrTemplateListById = () => {
    axios.get("https://localhost:7268/api/QRTemplate/GetQRTemplateListById")
}

export const addQrTemplate = (data: any) => {
    return axios.post("https://localhost:7268/api/QRTemplate/AddQRTemplate", data)
}

export const updateQrTemplate = (data: any) => {
    axios.put("https://localhost:7268/api/QRTemplate/UpdateQRTemplate", data)
}

export const deleteQrTemplate = () => {
    axios.delete("https://localhost:7268/api/QRTemplate/DeleteQRTemplate")
}