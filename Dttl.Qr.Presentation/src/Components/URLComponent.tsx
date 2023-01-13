import React, { useState } from 'react';
import { DefaultURLProps } from '../Props/Url';
import { addUrlQrCode } from '../Services/Url';

 function URLComponent() {
    const [url, seturl] = useState<DefaultURLProps>({
        URLId: 1001,
        QRCodeId: 111,
        Title: "xyz",
        Url: "xyz/abc"
    });

     const handleURLChanges = (event: any) => {
         const { name, value } = event.target;
         seturl((prevState: any) => {
             return {
                 ...prevState,
                 [name]: value,
             };
         });
     }

        const CreateNewURLQRCode = () => {
            addUrlQrCode(url)
                .then(function (response) {
                    console.log(response.status);
                })
                .catch(function (error) {
                    console.log(error);
                });
        }
            const { URLId, QRCodeId, Title, Url } = url;
            return (
                <div>
                    <div className="form-inputs">
                        <div>
                            <label>
                                URL Id:
                            </label>
                            <input type="text" name="TemplateId" onChange={handleURLChanges} value={URLId}></input>
                        </div>
                        <div>
                            <label>
                                QRCode Id:
                            </label>
                            <input type="text" name="QRType" onChange={handleURLChanges} value={QRCodeId}></input>
                        </div>
                        <div>
                            <label >                             
                                Title:
                            </label>
                            <input type="text" name="IsDynamic" onChange={handleURLChanges} value={Title}></input>
                        </div>
                        <div>
                            <label>
                                Url:
                            </label>
                            <input type="text" name="CreadtedBy" onChange={handleURLChanges} value={Url}></input>
                        </div>

                        <div>
                            <button onClick={CreateNewURLQRCode}>AddURLQRCODE</button>
                        </div>
                    </div>

                </div>
            );
    
    
}
export default URLComponent;