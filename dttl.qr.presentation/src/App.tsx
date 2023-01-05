import React from 'react';

import './App.css';
import TemplateComponent from './Components/TemplateComponent'



function App() {
   

  return (
      <div className="App">

          <TemplateComponent CreatedBy={'user'}  Width={12} ForeColor={'0XFFFFFF'} BackgroundColor={'0XFFFFFF'} Height={12} Logo={''} TemplateName={'Hello Qr'} ></TemplateComponent>
         
    
    </div>
  );
}

export default App;
