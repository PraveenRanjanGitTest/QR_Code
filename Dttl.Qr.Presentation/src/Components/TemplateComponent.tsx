import React, { Component } from 'react';
import { addQrTemplate } from "../Services/QrTemplate"
import { useState } from "react";

type TemplateProps = {
    ForeColor: string;
    BackgroundColor: string;
    Height: number;
    Width: number;
    Logo: string;
    CreatedBy: string;
    TemplateName: string;
}

export const TemplateComponent: React.FC<TemplateProps> = () => {
    const [template, setTemplate] = useState({
        ForeColor: "0xFFFFFF",
        BackgroundColor: "0x000000",
        Height: 2,
        Width: 2,
        Logo: '',
        TemplateName: 'title',
        CreatedBy: 'user'
    })

    const fillData = () => {
        addQrTemplate(template
        ).then(function (response) {
            console.log(response);
        })
            .catch(function (error) {
                console.log(error);
            })
    }

    return (
        <div>
            <h1>{template.TemplateName}</h1>
            <h1>{template.ForeColor}</h1>
            <h1>{template.BackgroundColor}</h1>
            <h1>{template.Height}</h1>
            <h1>{template.Width}</h1>
            <h1>{template.Logo}</h1>
            <button onClick={fillData}>Click me</button>

        </div>
    )
}

export default TemplateComponent;