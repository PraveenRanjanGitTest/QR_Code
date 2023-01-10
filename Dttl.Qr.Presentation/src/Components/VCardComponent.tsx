import React, { useState } from 'react';
import { DefaultVCardProps } from '../Props/VCardProps';
import { addVcard } from '../Services/Vcard';

export function VCardComponent() {
    const [VCard, setVCard] = useState<DefaultVCardProps>({
        Title: "Test",
        EmployeeCode: "E123",
        FirstName: "ABC",
        LastName: "XYZ",
        UploadImage: "",
        Designation: "A",
        MobileNumber: "1232",
        EmailId: "abc@gmail.com",
        CompanyName: "Kanini",
        Website: "Kanini.com",
        PersonalLinks: "abc",
    });

    const FillVCard = (event: any) => {
        const { name, value } = event.target;
        setVCard((prevState: any) => {
            return {
                ...prevState,
                [name]: value,
            };
        });
    };
    const fillData = () => {
        addVcard(VCard
        ).then(function (response) {
            console.log(response);
        })
            .catch(function (error) {
                console.log(error);
            })
    }
    const { Title, EmployeeCode, FirstName, LastName, UploadImage, Designation, MobileNumber, EmailId, CompanyName, Website, PersonalLinks } = VCard;
    return (
        <div>

            <input type="text" name="Title" placeholder="ABC" onChange={FillVCard} value={Title}></input>
            <input type="text" name="EmployeeCode" onChange={FillVCard} value={EmployeeCode}></input>
            <input type="text" name="FirstName" onChange={FillVCard} value={FirstName}></input>
            <input type="text" name="LastName" onChange={FillVCard} value={LastName}></input>
            <input type="file" name="UploadImage" onChange={FillVCard} value={UploadImage}></input>
            <input type="text" name="Designation" onChange={FillVCard} value={Designation}></input>
            <input type="text" name="MobileNumber" onChange={FillVCard} value={MobileNumber}></input>
            <input type="text" name="EmailId" onChange={FillVCard} value={EmailId}></input>
            <input type="text" name="CompanyName" onChange={FillVCard} value={CompanyName}></input>
            <input type="text" name="Website" onChange={FillVCard} value={Website}></input>
            <input type="text" name="PersonalLinks" onChange={FillVCard} value={PersonalLinks}></input>

            <button onClick={fillData}>ADD VCard</button>

        </div>
    )
}

export default VCardComponent;