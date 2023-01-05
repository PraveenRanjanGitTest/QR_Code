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
            BackgroundColor: "0x000000",
            Height: 2,
            Width: 2,
            Logo: '',
            TemplateName: 'title',
            CreatedBy: 'user'
        }
    }

    fillData() {

        let axiosConfig = {
            headers: {
                'Content-Type': 'application/json;charset=UTF-8',
                "Access-Control-Allow-Origin": "*",
            }
        };
        var postData = {
            ForeColor: "0xFFFFFF",
            BackgroundColor: "0x000000",
            Height: 2,
            Width: 2,
            Logo: '',
            TemplateName: 'title',
            CreatedBy: 'user'
        };

        axios.post('https://localhost:7268/api/QRTemplate/AddQRTemplate', {
            axiosConfig,
            postData
            
        })
            .then(function (response) {
                console.log(response);
            })
            .catch(function (error) {
                console.log(error);
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