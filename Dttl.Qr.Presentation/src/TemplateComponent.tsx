import React from 'react';

type TemplateProps = {
    forecolor: string;
    bgcolor: string;
    size: number;
    profilephoto: string;
    name: string;
}

function TemplateComponent(template: TemplateProps) {

    return (
        <>
            <h1>Welcome {template.forecolor}</h1>
            <h1>Welcome {template.size}</h1>
        </>
    );

}

export default TemplateComponent;


