import React from 'react';

import './App.css';
import SortableTable from './Components/SortedTable';
import TemplateComponent from './Components/TemplateComponent';
import  URLComponent  from './Components/URLComponent';
import { VCardComponent } from './Components/VCardComponent';
import { downloadQrCode } from './Utils/DownLoad';
import QrCodeUtil from './Utils/QrCodeUtil';


function App() {
    return (
        <><div className="App">
            <div>
                <QrCodeUtil />
                <button onClick=
                    {
                        () => {
                            downloadQrCode("qrcode", "svg");
                            downloadQrCode("qrcode", "png");
                            downloadQrCode("qrcode", "jpeg");
                            downloadQrCode("qrcode", "pdf");
                        }
                    }>Download</button>
               
            </div>
            <br />
           
            <br />
            <div>
                <SortableTable data={[]} />
                <TemplateComponent/>
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