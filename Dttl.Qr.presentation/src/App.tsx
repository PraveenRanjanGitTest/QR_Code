import './App.css';
import QrCodeDisplayable from './Components/QrCodeDisplayable';
import QRCodeDetailsComponent from './Components/QRDetailsComponent';
import { SortableTable } from './Components/SortedTable';
import TemplateComponent from './Components/TemplateComponent';
import URLComponent from './Components/URLComponent';
import { VCardComponent } from './Components/VCardComponent';

function App() {
    return (
        <><div className="App">

            <div>
                <SortableTable data={[]} />

            </div>
            <br />
            <div>
                <TemplateComponent />
            </div>
            <br />
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