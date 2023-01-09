import React from 'react';
import { useState } from "react";

import { addQrTemplate, getQrTemplateList } from "../Services/QrTemplate"
import { DefaultTemplateProps, TemplateList } from "../Props/TemplateProps";

export const TemplateComponent: React.FC = () => {
    React.useEffect
        (
            () => {
                getQrTemplateList().then(function (response) {
                    console.log(response);
                })
                    .catch(function (error) {
                        console.log(error);
                    })
            })

    const [template] = useState<DefaultTemplateProps>({
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