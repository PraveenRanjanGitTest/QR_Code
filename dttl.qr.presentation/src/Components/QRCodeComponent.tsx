import React, { useState } from 'react';
import { DefaultQRCodeProps } from '../Props/QRCodeProps';
import { addQrCode } from '../Services/Qrcode';

export function QRCodeComponent() {
    const [qrcode, setQRCode] = useState<DefaultQRCodeProps>({
        TemplateId: 1001,
        QRType: "xyz",
        IsDynamic: false,
        CreatedBy: "xyz"
    });

    const [addQRCode, setAddQRCode] = useState(false);

    const handleQRCodeChanges = (event: any) => {
        const { name, value } = event.target;
        setQRCode((prevState: any) => {
            return {
                ...prevState,
                [name]: value,
            };
        });
    };

    const CreateNewQRCode = () => {
        addQrCode(qrcode)
            .then(function (response) {
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    const { TemplateId, QRType, IsDynamic, CreatedBy } = qrcode;
    return (
        <>
            <button onClick={() => { setAddQRCode(true) }} disabled={addQRCode}>Add QRCode</button>
            {
                addQRCode &&
                <div>
                    <div className="form-inputs">
                        <div>
                            <label
                                className="form-label">
                                Template Id:
                            </label>
                            <input type="text" name="TemplateId" onChange={handleQRCodeChanges} value={TemplateId}></input>
                        </div>
                        <div>
                            <label
                                className="form-label">
                                QRType:
                            </label>
                            <input type="text" name="QRType" onChange={handleQRCodeChanges} value={QRType}></input>
                        </div>
                        <div>
                            <label
                                className="form-label">
                                Dynamic:
                            </label>
                            <input type="checkbox" name="IsDynamic" onChange={handleQRCodeChanges} defaultChecked={IsDynamic}></input>
                        </div>
                        <div>
                            <label
                                className="form-label">
                                Creadted By:
                            </label>
                            <input type="text" name="CreadtedBy" onChange={handleQRCodeChanges} value={CreatedBy}></input>
                        </div>

                        <div>
                            <button onClick={CreateNewQRCode}>Submit</button>
                        </div>
                    </div>

                </div>}
        </>

    )
}