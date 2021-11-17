import React, { Component } from 'react';
import { Table } from 'react-bootstrap';

export class ProjectUnassignment extends Component {
    constructor(props) {
        super(props);
        this.state = { personList: [] }
    }

    componentDidMount() {
        this.refreshList();
    }

    refreshList() {
        fetch('http://localhost:26311/projector/persons/getmembersintheproject/6')
            .then(response => response.json())
            .then(data => {
                this.setState(
                    {
                        personList: data.result
                    })
            });
    }

    render() {

        const { personList } = this.state;

        return (
            <div className="mt-5 d-flex justify-content-right">
                <Table responsive="sm" >
                    <thead>
                        <tr>
                            <th>First Name</th>
                            <th>Last Name</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {personList.map(person =>
                            <tr key={person.id}>
                                <td>{person.firstName} </td>
                                <td>{person.lastName} </td>
                                <td>Delete</td>
                            </tr>
                        )}
                    </tbody>
                </Table>
            </div>
        );
    }
}