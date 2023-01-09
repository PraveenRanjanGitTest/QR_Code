import React, { Component } from 'react';
import axios from 'axios';

type TemplateProps = {
    ForeColor: string;
    BackgroundColor: string;
    Height: number;
    Width: number;
    Logo: string;
    CreatedBy: string;
    TemplateName: string;
}

class TemplateComponent extends React.Component<TemplateProps> {
    constructor(props: TemplateProps) {
        super(props);
        this.state = {
            ForeColor: "0xFFFFFF",
            BackgroundColor: "white",
            Height: 2,
            Width: 2,
            Logo: '',
            TemplateName: 'title',
            CreatedBy: 'user'
        }
    }

    fillData() {

        const templatedata = {
            templateName: 'Senthil API Check',
            height: '4.5',
            width: '8.5',
            foreColor: '#0000FF',
            backgroundColor: '#00FFFF',
            logo: 'test',
            createdBy: 'Praveen Ranjan'
        }
        const url = "https://localhost:7268/api/QRTemplate/AddQRTemplate"
        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(templatedata)
        })
            .then(response => {
                console.log("response", response)
                if (response.status == 201) {
                    alert('Data Save Successfully..')
                }
            })
    }
    render() {
        return (
            <div>
                <h1>{this.props.TemplateName}</h1>
                <h1>{this.props.ForeColor}</h1>
                <h1>{this.props.BackgroundColor}</h1>
                <h1>{this.props.Height}</h1>
                <h1>{this.props.Width}</h1>
                <h1>{this.props.Logo}</h1>
                <button onClick={this.fillData}>Click me</button>

            </div>
        );
    }
}

export default TemplateComponent;