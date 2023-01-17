import './App.css';
import QrCodeDisplayable from './Components/QrCodeDisplayable';
import { QRCodeComponent } from './Components/QRCodeComponent';
import QRCodeDetailsComponent from './Components/QRDetailsComponent';
import { SortableTable } from './Components/SortedTable';
import TemplateComponent from './Components/TemplateComponent';
import URLComponent from './Components/URLComponent';
import { VCardComponent } from './Components/VCardComponent';
import { downloadQrCode } from './Utils/DownLoad';

function App() {
    return (
        <><div className="App">

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