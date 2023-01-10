import React from 'react';

import './App.css';
import TemplateComponent from './Components/TemplateComponent'
import VCardComponent from './Components/VCardComponent';

function App() {
    return (
        <><div className="App">

            <TemplateComponent />

        </div>
            <div>

                <VCardComponent />

            </div></>
    );
}

export default App;