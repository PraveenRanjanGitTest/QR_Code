import React from 'react';

import './App.css';
import TemplateComponent from './Components/TemplateComponent'
import VCardComponent from './Components/VCardComponent';
import { downloadQrCode } from './Utils/CanvasUtils';

function App() {
    return (
        <><div className="App">
            <svg id="testDownload" width="100" height="100">
                <circle cx="50" cy="50" r="40" stroke="green" stroke-width="4" fill="yellow" />
            </svg>

        </div>
            <div>
                <TemplateComponent />
                <VCardComponent />

            </div>
            <button onClick={() => {
                downloadQrCode("testDownload", "svg"); // png, jpeg and svg
            }
            }>Download</button>

        </>

    );
}

export default App;