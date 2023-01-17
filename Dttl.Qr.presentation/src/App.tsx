import './App.css';
import { QRCodeComponent } from './Components/QRCodeComponent';
import QRCodeDetailsComponent from './Components/QRDetailsComponent';
import SortableTable from './Components/SortedTable';
import TemplateComponent from './Components/TemplateComponent';
import URLComponent from './Components/URLComponent';
import { VCardComponent } from './Components/VCardComponent';
import { downloadQrCode } from './Utils/DownLoad';


function App() {
    return (
        <><div className="App">
            <div>
                <svg id="testDownload" width="100" height="100">
                    <circle cx="50" cy="50" r="40" stroke="green" stroke-width="4" fill="yellow" />
                </svg>
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
            </div>
            <br />
            <div>
                <TemplateComponent />
            </div>
            <div>
                <QRCodeComponent />
            </div>
            <div>
                <VCardComponent />
            </div>
            <div>
                <URLComponent />
            </div>
            <div>
                <QRCodeDetailsComponent />
            </div>
        </div>
        </>

    );
}

export default App;