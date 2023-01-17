import React from 'react';
import { useState } from "react";

import { addQrTemplate, getQrTemplateList } from "../Services/QrTemplate"
import { DefaultTemplateProps, TemplateList } from "../Props/TemplateProps";
import QrCodeDisplayable from './QrCodeDisplayable';
import { downloadQrCode, downloadQrCodecAsBase64 } from '../Utils/DownLoad';
let qrcodeTempId = "qrcodeidfortemplate";

export const TemplateComponent: React.FC = () => {
    const [template, setTemplate] = useState<DefaultTemplateProps>({
        ForeColor: "0xFFFFFF",
        BackgroundColor: '#c29999',
        Height: 256,
        Width: 256,
        Logo: '',
        TemplateName: 'My New Template',
        CreatedBy: 'Kanini User',
        TemplatePreview: ''
    })

    const handleTemplateChanges = (event: any) => {
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
            else {
                setTemplate((prevState: any) => {
                    return {
                        ...prevState,
                        [event.target.name]: event.target.value,
                    };
                });
            }
        }
        else {
            setTemplate((prevState: any) => {
                return {
                    ...prevState,
                    [event.target.name]: event.target.value,
                };
            });
        }
    }

    const CreateNewTemplate = () => {
        template.TemplatePreview = downloadQrCodecAsBase64(qrcodeTempId);
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
        <>
            <QrCodeDisplayable
                TargetUrl={'www.deloitte.com'}
                RenderType={'svg'} level={'H'} marginRequired={false}
                DivId={qrcodeTempId} ForeColor={ForeColor} BackgroundColor={BackgroundColor} Height={Height} Width={Width}
                Logo={template.Logo} CreatedBy={CreatedBy} TemplateName={TemplateName} TemplateId={''} CreatedDate={new Date()} ModifiedBy={''} ModifiedDate={new Date()} IsActive={false} IsApproved={false} TemplatePreview={''} />
            <br />
            <button onClick=
                {
                    () => {
                        downloadQrCode(qrcodeTempId, "svg");
                        downloadQrCode(qrcodeTempId, "png");
                        downloadQrCode(qrcodeTempId, "jpeg");
                        downloadQrCode(qrcodeTempId, "pdf");
                    }
                }>Download</button>
            <br />

            {
                <div>

                    <input type="text" name="TemplateName" onChange={handleTemplateChanges} value={TemplateName}></input>
                    <input type="text" name="CreatedBy" onChange={handleTemplateChanges} value={CreatedBy}></input>
                    <input type="color" name="ForeColor" onChange={handleTemplateChanges} value={ForeColor}></input>
                    <input type="color" name="BackgroundColor" onChange={handleTemplateChanges} value={BackgroundColor}></input>
                    <input type="text" name="Height" onChange={handleTemplateChanges} value={Height}></input>
                    <input type="text" name="Width" onChange={handleTemplateChanges} value={Width}></input>
                    <input type="file" accept="image/*" name="Logo" onChange={handleTemplateChanges}></input>

                    <button onClick={CreateNewTemplate}>Create Template</button>

                </div>
            }

        </>
    )
}
export default TemplateComponent;