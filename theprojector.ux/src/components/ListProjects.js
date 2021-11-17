import React, { Component } from 'react';
import { Table } from 'react-bootstrap';
import { Link } from 'react-router-dom';

export class ListProjects extends Component {
    constructor(props) {
        super(props);
        this.state = { projectList: [] }
    }

    componentDidMount() {
        this.refreshList();
    }

    refreshList() {
        fetch('http://localhost:26311/projector/projects')
            .then(response => response.json())
            .then(data => {
                this.setState({ projectList: data.result })
            });
    }

    render() {

        const { projectList } = this.state;

        return (
            <div className="mt-5 d-flex justify-content-right">
                <Table responsive="sm" >
                    <thead>
                        <tr>
                            <th>Project Name</th>
                            <th>Budget</th>
                            <th>Tasks</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {projectList.map(project =>
                            <tr key={project.id}>
                                <td>{project.name} </td>
                                <td>{project.budget} </td>
                            </tr>
                        )}
                    </tbody>
                </Table>

                <div>
                    <p>Other Tasks</p>
                    <Link to="/projector/projects/create">Create Project</Link>
                    <br />
                    <Link to="/projector/persons/create">Create Person</Link>
                </div>
            </div>
        );
    }
}