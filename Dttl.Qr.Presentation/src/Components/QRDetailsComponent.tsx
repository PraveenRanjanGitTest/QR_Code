import React, { useState } from 'react';
import { DefaultQRCodeDetailsDefaultProps } from '../Props/QRDeatailsProps';
import { addQrDetail } from '../Services/QrDetail';

function QRCodeDetailsComponent() {
    const [QRDetails, setDetails] = useState<DefaultQRCodeDetailsDefaultProps>({
        QRCodeId: 111,
        QRName: "xyz",
        QRImage: ""
    });

    const handleQRDetailsChanges = (event: any) => {
        const { name, value } = event.target;
        setDetails((prevState: any) => {
            return {
                ...prevState,
                [name]: value,
            };
        });
    }
    const [AddQRCodeDetails, setAddQRDetails] = useState(false);

    const handleQRImage = (event: any) => {
        if (event.target.files) {
            if (event.target.files[0]) {
                let reader = new FileReader();
                reader.readAsDataURL(event.target.files[0]);
                reader.onload = (e) => {
                    setDetails((prevState: any) => {
                        return {
                            ...prevState,
                            [event.target.name]: e.target?.result,
                        };
                    });
                }
            }
        }
    }

    const CreateNewQRCodeDetails = () => {
        addQrDetail(QRDetails)
            .then(function (response) {
            })
            .catch(function (error) {
                console.log(error);
            });
    }
    const { QRCodeId, QRName, QRImage } = QRDetails;
    return (
        <>
            <button onClick={() => { setAddQRDetails(true) }} disabled={AddQRCodeDetails}>QRCodeDetails</button>
            {
                AddQRCodeDetails &&
                <div>
                    <div>
                        <label>
                            QRCode Id:
                        </label>
                        <input type="text" name="QRCodeId" onChange={handleQRDetailsChanges} value={QRCodeId}></input>
                    </div>
                    <div>
                        <label >
                            QRName:
                        </label>
                        <input type="text" name="QRName" onChange={handleQRDetailsChanges} value={QRName}></input>
                    </div>
                    <div>
                        <label>
                            QRImage:
                        </label>
                        <input type="file" name="QRImage" accept="image/*" onChange={handleQRImage} value="" ></input>

                        <img style={{ margin: "25px 50px 5px 200px" }} src={QRImage} alt="" width={300} />

                    </div>

                    <div>
                        <button onClick={CreateNewQRCodeDetails}>Submit</button>
                    </div>
                </div>}

        </>
    );
}
export default QRCodeDetailsComponent;