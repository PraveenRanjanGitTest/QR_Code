import React, { useState } from 'react';
import { DefaultVCardProps } from '../Props/VCardProps';
//import { addVcard } from '../Services/Vcard';
import { yupResolver } from '@hookform/resolvers/yup';
import { useForm, SubmitHandler } from "react-hook-form"
import * as yup from 'yup'
import { addVcard } from '../Services/Vcard';
import { func } from 'prop-types';



export function VCardComponent() {
    const DefaultVCardProps: DefaultVCardProps[] = [];

    const [VCard, setVCard] = useState(false);


    const phoneRegExp = /^\+(9[976]\d|8[987530]\d|6[987]\d|5[90]\d|42\d|3[875]\d|2[98654321]\d|9[8543210]|8[6421]|6[6543210]|5[87654321]|4[987654310]|3[9643210]|2[70]|7|1)\W*\d\W*\d\W*\d\W*\d\W*\d\W*\d\W*\d\W*\d\W*(\d{1,2})$/;
    const ValidationSchema = yup.object().shape({
        QRCodeId: yup.string()
            .required("QRCodeId is required"),
        Title: yup.string()
            .required("Title is required"),
        EmployeeCode: yup.string()
            .required("EmployeeCode is required"),
        FirstName: yup.string()
            .min(3, "minimum 3 letters is Required")
            .max(15, "maximum 15 letters is Required")
            .required("First Name is Required *")
            .matches(/^[a-zA-Z]+$/, "Please Dont Include Numbers"),
        LastName: yup.string()
            .min(3, "minimum 3 letters is Required")
            .max(15, "maximum 15 letters is Required")
            .matches(/^[a-zA-Z]+$/, "Please Dont Include Numbers")
            .required("Last Name is Required *"),
        UploadImage: yup.string()
            .required("UploadImage is required"),
        Designation: yup.string()
            .required("Designation is required"),
        MobileNo: yup.string()
            .required("Phone number is required")
            .typeError("That doesn't look like a phone number")
            .matches(phoneRegExp, 'Phone number is not valid'),
        EmailId: yup.string()
            .email("EmailId is invalid")
            .required("EmailId is required")
            .matches(/^[A-Z0-9._%+-]+@[A-Za-z]+\.[A-Z]{2,4}$/i, "Invalid Email Id"),
        CompanyName: yup.string()
            .min(3, "minimum 3 letters is Required")
            .max(15, "maximum 9 letters is Required"),
        Website: yup.string(),
        PersonalLinks: yup.string()
            .required("PersonalLinks is Required")
    })


    const [filebase64, setFileBase64] = useState<string>("")
    const onSubmit: SubmitHandler<DefaultVCardProps> = event => {
        event.UploadImage = filebase64
        addVcard(event).then(function (response) { }).catch(function (error) { console.log(error); })
    };

    const { register, handleSubmit, formState: { errors } } = useForm<DefaultVCardProps>(
        { resolver: yupResolver(ValidationSchema) }

    );
    function convertFile(files: FileList | null) {
        if (files) {
            const fileRef = files[0] || ""
            const fileType: string = fileRef.type || ""
            const reader = new FileReader()
            reader.readAsBinaryString(fileRef)
            reader.onload = (ev: any) => {
                // convert it to base64
                setFileBase64(`data:${fileType};base64,${btoa(ev.target.result)}`)
            }
        }
    }
    return (
        <div>
            <button onClick={() => { setVCard(true) }} disabled={VCard}>VCard View </button>
            {
                VCard&&
           
            <form onSubmit={handleSubmit(onSubmit)} className='form'>
                <div>
                    <label>
                        QRCode Id
                        <small style={{ color: "red" }}>*</small>
                    </label>
                    <input
                        placeholder="Enter your QRCode Id"  {...register("QRCodeId")} />
                    {errors?.QRCodeId && <small style={{ color: "red" }}>{errors.QRCodeId.message}</small>}
                </div>
                <div>
                    <label>
                        Title
                        <small style={{ color: "red" }}>*</small>
                    </label>
                    <input
                        placeholder="Enter your Title"  {...register("Title")} />
                    {errors?.Title && <small style={{ color: "red" }}>{errors.Title.message}</small>}
                </div>
                <div>
                    <label>
                        Employee Code
                        <small style={{ color: "red" }}>*</small>
                    </label>
                    <input
                        placeholder="Enter your Employee Code"  {...register("EmployeeCode")} />
                    {errors?.EmployeeCode && <small style={{ color: "red" }}>{errors.EmployeeCode.message}</small>}
                </div>
                <div>
                    <label>
                        First Name
                        <small style={{ color: "red" }}>*</small>
                    </label>
                    <input
                        placeholder="Enter your First Name"  {...register("FirstName")} />
                    {errors?.FirstName && <small style={{ color: "red" }}>{errors.FirstName.message}</small>}
                </div>
                <div>
                    <label>
                        Last Name
                        <small style={{ color: "red" }}>*</small>
                    </label>
                    <input
                        placeholder="Enter your Last Name"
                        {...register("LastName")}
                    />
                    {errors.LastName && (
                        <small style={{ color: "red" }}>{errors.LastName.message}</small>
                    )}
                </div>
                <div>
                    <label>
                        Upload Image </label>
                    <input type="file" title="profile" {...register("UploadImage", { onChange: (e) => convertFile(e.target.files) })} />
                    {filebase64 &&
                        <>
                            {(filebase64.indexOf("image/") > -1) &&
                                <img style={{ borderRadius: "100px", width: "100px", height: '100px', display: "ms-flexbox", margin: "25px 50px 5px 200px" }} src={filebase64} alt="profile" width={300} />
                            }
                        </>
                    }
                </div>
                <div>
                    <label>
                        Designation
                        <small style={{ color: "red" }}>*</small>
                    </label>
                    <input
                        placeholder="Enter your Designation"
                        {...register("Designation")}
                    />
                    {errors.Designation && (
                        <small style={{ color: "red" }}>{errors.Designation.message}</small>
                    )}
                </div>
                <div >
                    <label>
                        Mobile Number
                        <small style={{ color: "red" }}>*</small>
                    </label>
                    <input
                        placeholder="Enter your Mobile Number"
                        {...register("MobileNo")}
                    />
                    {errors.MobileNo && (
                        <small style={{ color: "red" }}>{errors.MobileNo.message}</small>
                    )}
                </div>
                <div>
                    <label>
                        Email Id
                        <small style={{ color: "red" }}>*</small>
                    </label>
                    <input
                        placeholder="Enter your EmailId"
                        {...register("EmailId")}
                    />
                    {errors.EmailId && (
                        <small style={{ color: "red" }}>{errors.EmailId.message}</small>
                    )}
                </div>
                <div>
                    <label>
                        Company Name
                    </label>
                    <input
                        {...register("CompanyName")}
                        placeholder="Enter your company"
                    />
                    {errors.CompanyName && (
                        <small style={{ color: "red" }}>{errors.CompanyName.message}</small>
                    )}
                </div>
                <div>
                    <label>Website </label>
                    <input
                        placeholder="Enter your Website"
                        {...register("Website")}
                    />
                    {errors.Website?.message && (
                        < small style={{ color: "red" }}>
                            {errors.Website.message}
                        </small>
                    )}
                </div >
                <div>
                    <label>Personal Link </label>
                    <input
                        placeholder="Enter your Personal Links"
                        {...register("PersonalLinks")}
                    />
                    {errors.PersonalLinks?.message && (
                        <small style={{ color: "red" }}>
                            {errors.PersonalLinks.message}
                        </small>
                    )}
                </div >
                <div>
                    <input type="submit"></input>  </div>
                </form>
            }
        </div>

    )
}