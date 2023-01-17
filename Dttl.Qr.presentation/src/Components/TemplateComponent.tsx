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
        TemplatePreview: '',
        TemplateName: 'My New Template',
        CreatedBy: 'Kanini User',
    })

    const [addTemplate, setAddTemplate] = useState(false);
    const [filebase64, setFileBase64] = useState<string>("")


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
    const handleTemplateChanges = (even:any) => {
        const { name, value } = even.target;
        setTemplate((prevState: any) => {
            return {
                ...prevState,
                [name]: value,
            };
        });
    };

    const CreateNewTemplate = (event:any) => {
        event.Logo = filebase64
        addQrTemplate(template
        ).then(function (response) {
        })
            .catch(function (error) {
                console.log(error);
            })
    }
    const { TemplateName, CreatedBy, ForeColor, BackgroundColor, Height, Width, Logo, TemplatePreview } = template;
    return (
        <>

            <button onClick={() => { setAddTemplate(true) }} disabled={addTemplate}> Add Templates</button>
            {
                addTemplate &&
                <div>
                    <form >

                    <input type="text" name="TemplateName" onChange={handleTemplateChanges} value={TemplateName}></input>
                    <input type="text" name="CreatedBy" onChange={handleTemplateChanges} value={CreatedBy}></input>
                    <input type="color" name="ForeColor" onChange={handleTemplateChanges} value={ForeColor}></input>
                    <input type="color" name="BackgroundColor" onChange={handleTemplateChanges} value={BackgroundColor}></input>
                    <input type="text" name="Height" onChange={handleTemplateChanges} value={Height}></input>
                    <input type="text" name="Width" onChange={handleTemplateChanges} value={Width}></input>
                    <input type="file" accept="image/*" name="Logo" onChange={handleTemplateLogoUpload} value=""></input>
                            <img style={{ margin: "25px 25px 5px 50px" }} src={template.Logo} width={200} />
                            <br></br>
                    <input type="file" accept="image/*" name="TemplatePreview" onChange={handleTemplateLogoUpload} value=""></input>
                                <img style={{ margin: "25px 25px 5px 50px" }} src={template.TemplatePreview} width={200} />
                            <button type='submit' onClick={CreateNewTemplate} >Submit</button>
                        </form>
                </div>}

        </>
    )
}
export default TemplateComponent;

