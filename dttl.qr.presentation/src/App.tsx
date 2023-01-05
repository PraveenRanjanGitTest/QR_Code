import React from 'react';
import logo from './logo.svg';
import './App.css';
import TemplateComponent from './TemplateComponent'

import axios from 'axios';

function App() {

    axios.get('https://localhost:7268/api/QRTemplate/GetQRTemplateList', {})
        .then(function (response) {
            console.log(response);
        })
        .catch(function (error) {
            console.log(error);
        });

  return (
      <div className="App">

          <TemplateComponent forecolor={'Hello Qr'} bgcolor={''} size={12} profilephoto={''} name={''} />
         
    
    </div>
  );
}

export default App;
