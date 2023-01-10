import React from 'react';
import { useState } from "react";

import { addQrTemplate, getQrTemplateList } from "../Services/QrTemplate"
import { DefaultTemplateProps, TemplateList } from "../Props/TemplateProps";

export const TemplateComponent: React.FC = () => {
    

    const [template, setTemplate] = useState<DefaultTemplateProps>({
        ForeColor: "0xFFFFFF",
        BackgroundColor: "0x000000",
        Height: 2,
        Width: 2,
        Logo: '',
        TemplateName: 'My New Template',
        CreatedBy: 'Kanini User',
        
    })

    const handleUpload = (event: any)=>
    {
        if (event.target.files) {

        
        if (event.target.files[0]) {
            let reader = new FileReader();
            reader.readAsDataURL(event.target.files[0]);
            reader.onload = (e) => {
                setTemplate((prevState: any) => {
                    return {
                        ...prevState,
                        [event.target.name]: e.target?.result,
                    };
                });
            }
            }
        }
    }
    const handleChange = (event: any) => {
        const { name, value } = event.target;
        setTemplate((prevState: any) => {
            return {
                ...prevState,
                [name]: value,
            };
        });

       
    };

    const fillData = () => {
        addQrTemplate(template
        ).then(function (response) {
            console.log(response);
        })
            .catch(function (error) {
                console.log(error);
            })
    }
    const { TemplateName, CreatedBy, ForeColor, BackgroundColor, Height, Width, Logo } = template;
    return (
        <div>

            <input type="text" name="TemplateName" onChange={handleChange} value={TemplateName}></input>
            <input type="text" name="CreatedBy" onChange={handleChange} value={CreatedBy}></input>
            <input type="color" name="ForeColor" onChange={handleChange} value={ForeColor}></input>
            <input type="color" name="BackgroundColor" onChange={handleChange} value={BackgroundColor}></input>
            <input type="text" name="Height" onChange={handleChange} value={Height}></input>
            <input type="text" name="Width" onChange={handleChange} value={Width}></input>
            <input type="file" accept="image/*" name="Logo" onChange={handleUpload} value=""></input>

            <h1>{template.Logo}</h1>

            <button onClick={fillData}>Click me</button>

        </div>
    )
}

export default TemplateComponent;