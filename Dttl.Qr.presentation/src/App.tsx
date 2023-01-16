import React from 'react';

import './App.css';
import QrCodeDisplayable from './Components/QrCodeDisplayable';
import { SortableTable } from './Components/SortedTable';
import TemplateComponent from './Components/TemplateComponent';
import URLComponent from './Components/URLComponent';
import { VCardComponent } from './Components/VCardComponent';
import { downloadQrCode } from './Utils/DownLoad';
import "./Internationalisation/i18n"

function App() {
    return (
        <><div className="App">
            <div>
                <QrCodeDisplayable
                    TargetUrl={'www.google.com'}
                    RenderType={'svg'} level={'L'} marginRequired={false}
                    DivId={'qrcode'} ForeColor={'#ffff00'} BackgroundColor={'ffffff'} Height={256} Width={256}
                    Logo={''} CreatedBy={''} TemplateName={''} TemplateId={''} CreatedDate={new Date()} ModifiedBy={''} ModifiedDate={new Date()} IsActive={false} IsApproved={false} />

                <button onClick=
                    {
                        () => {
                            downloadQrCode("testDownload", "svg");
                            downloadQrCode("testDownload", "png");
                            downloadQrCode("testDownload", "jpeg");
                            downloadQrCode("testDownload", "pdf");
                        }
                    }>Download</button>
            </div>
            <br />
            <div>
                <SortableTable data={[]} />
                <TemplateComponent />
            </div>
            <br />
            <div>
                <VCardComponent />
            </div>
            <br />
            <br />
            <div>
                <URLComponent />
            </div>
            <br />
        </div>
        </>

    );
}

export default App;