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

    const handleTemplateLogoUpload = (event: any) => {
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
    const handleTemplateChanges = (event: any) => {
        const { name, value } = event.target;
        setTemplate((prevState: any) => {
            return {
                ...prevState,
                [name]: value,
            };
        });
    };

    const CreateNewTemplate = () => {
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

            <input type="text" name="TemplateName" onChange={handleTemplateChanges} value={TemplateName}></input>
            <input type="text" name="CreatedBy" onChange={handleTemplateChanges} value={CreatedBy}></input>
            <input type="color" name="ForeColor" onChange={handleTemplateChanges} value={ForeColor}></input>
            <input type="color" name="BackgroundColor" onChange={handleTemplateChanges} value={BackgroundColor}></input>
            <input type="text" name="Height" onChange={handleTemplateChanges} value={Height}></input>
            <input type="text" name="Width" onChange={handleTemplateChanges} value={Width}></input>
            <input type="file" accept="image/*" name="Logo" onChange={handleTemplateLogoUpload} value=""></input>

            <img src={template.Logo} />

            <button onClick={CreateNewTemplate}>Click me</button>

        </div>
    )
}

export default TemplateComponent;