import QRCode from "qrcode.react";
import { boolean } from "yup/lib/locale";
import { QRCodeDisplayableProps } from '../Props/QRCodeDisplayableProps';

export function QrCodeDisplayable(displayProps: QRCodeDisplayableProps) {

    let iconAvailble = displayProps.Logo != ''; 
    return (
        <div >
            <QRCode id={displayProps.DivId}
                style={{ border: "2pt solid black" }}
                value={displayProps.TargetUrl}
                renderAs={'svg'}
                size={displayProps.Height}
                bgColor={displayProps.BackgroundColor}
                fgColor={displayProps.ForeColor}
                level={displayProps.level}
                includeMargin={displayProps.marginRequired}
                
                imageSettings={{
                    src: iconAvailble ? displayProps.Logo : undefined,
                    height: iconAvailble? displayProps.Height * 20 / 100 : 0,
                    width: iconAvailble ? displayProps.Width * 20 / 100: 0,
                    excavate: true,
                }}
            />
        </div>
    )
}

export default QrCodeDisplayable;