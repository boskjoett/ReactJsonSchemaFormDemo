import React, { Component } from "react";

import Form from "react-jsonschema-form";

const log = (type) => console.log.bind(console, type);

export class FormDemo extends Component {
    static displayName = FormDemo.name;

    constructor(props) {
        super(props);

        this.state = {
            jsonSchemaData: null,
            uiSchemaData: null,
            loading: true
        };

        this.handleSubmit = this.handleSubmit.bind(this);
    }

    componentDidMount() {
        this.populateFormData();
    }

    handleSubmit({ formData }) {
        console.log(formData);
    }

    render() {
        if (this.state.loading) {
            return (<p><em>Loading...</em></p>);
        }
        else {
            return (
                <Form schema={this.state.jsonSchemaData} uiSchema={this.state.uiSchemaData} onSubmit={this.handleSubmit} onChange={log("changed")} onError={log("errors")} />
            );
        }
    }

    async populateFormData() {
        const response = await fetch('api/reactjsonschema?name=bundle1');
        const data = await response.json();

        console.log("API data: " + data);

        this.setState({
            jsonSchemaData: JSON.parse(data.jsonSchema),
            uiSchemaData: JSON.parse(data.uiSchema),
            loading: false
        });
    }
}
