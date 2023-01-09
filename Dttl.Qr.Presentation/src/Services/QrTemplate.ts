import axios from "axios";

export const getQrTemplateList = () => {
    axios.get("https://localhost:7268/api/QRTemplate/GetQRTemplateList")
}

export const getQrTemplateListById = () => {
    axios.get("https://localhost:7268/api/QRTemplate/GetQRTemplateListById")
}

export const addQrTemplate = () => {
    axios.post("https://localhost:7268/api/QRTemplate/AddQRTemplate")
}

export const updateQrTemplate = () => {
    axios.put("https://localhost:7268/api/QRTemplate/UpdateQRTemplate")
}

export const deleteQrTemplate = () => {
    axios.delete("https://localhost:7268/api/QRTemplate/DeleteQRTemplate")
}