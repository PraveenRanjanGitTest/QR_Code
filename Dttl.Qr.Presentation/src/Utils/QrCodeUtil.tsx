import React from 'react';
import QRCode from "qrcode.react";

export function QrCodeUtil() {
  return (
      <div >
          <QRCode id = "qrcode"
              style={{ border: "1px solid black" }}
              value={'sample'}
              renderAs={'svg'}
              size={256}
              bgColor={"ffffff"}
              fgColor={"#ffff00"}
              level={'L'}
              includeMargin={true}
          />
      </div>
  )
}

export default QrCodeUtil;