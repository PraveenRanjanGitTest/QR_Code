import axios from "axios";

export const getVcardList = () => {
    return axios.get("https://localhost:7268/api/VCard/GetVCardList")
}

export const getVcardListById = () => {
    return axios.get("https://localhost:7268/api/VCard/GetVCardById")
}

export const addVcard = () => {
    return axios.post("https://localhost:7268/api/VCard/AddVCard")
}

export const updateVcard = () => {
    return axios.put("https://localhost:7268/api/VCard/UpdateVCard")
}

export const deleteVcard = () => {
    return axios.delete("https://localhost:7268/api/VCard/DeleteVCard")
}