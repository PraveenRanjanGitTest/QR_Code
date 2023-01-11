
import './App.css';
import { QRCodeComponent } from './Components/QRCodeComponent';
import TemplateComponent from './Components/TemplateComponent'
import {VCardComponent} from './Components/VCardComponent';

function App() {
    return (
        <><><div className="App">

            <TemplateComponent />

        </div>
            <div>

                <VCardComponent></VCardComponent>

            </div></><div className="App">

                <QRCodeComponent />

            </div></>

    );
}

export default App;