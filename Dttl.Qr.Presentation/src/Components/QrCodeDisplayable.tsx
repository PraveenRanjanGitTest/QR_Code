import QRCode from "qrcode.react";
import { QRCodeDisplayableProps } from '../Props/QRCodeDisplayableProps';

export function QrCodeDisplayable(displayProps: QRCodeDisplayableProps) {
    return (
        <div >
            <QRCode id={displayProps.DivId}
                style={{ border: "1px solid black" }}
                value={displayProps.TargetUrl}
                renderAs={'svg'}
                size={displayProps.Height}
                bgColor={displayProps.BackgroundColor}
                fgColor={displayProps.ForeColor}
                level={displayProps.level}
                includeMargin={displayProps.marginRequired}
                imageSettings={{
                    src: displayProps.Logo,
                    height: displayProps.Height * 10 / 100,
                    width: displayProps.Width * 10 / 100,
                    excavate: true,
                }}
            />
        </div>
    )
}

export default QrCodeDisplayable;