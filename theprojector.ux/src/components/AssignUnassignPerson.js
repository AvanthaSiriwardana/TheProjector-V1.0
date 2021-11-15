import React, { Component } from 'react';
import { Form, Button } from "react-bootstrap";
import { Link } from 'react-router-dom';

export class AssignUnassignPerson extends Component {
    constructor(props) {
        super(props);
        this.state = {
            projectId: 0,
            personId: 0
        };
    }

    // Set State
    handleChange = event => {
        this.setState({
            [event.target.id]: event.target.value
        });
    }

    // Assigns a person to a Project
    assignToProject = event => {

    };

    // Unassigns a person from a Project
    UnAssignToProject = event => {

    };

    // Handles the assign and unassign event
    handleSubmit = event => {
        event.preventDefault();

        fetch('http://localhost:26311/projector/projects/create', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                Code: event.target.code.value,
                Name: event.target.name.value,
                Budget: event.target.budget.value,
                Remarks: event.target.remarks.value
            })
        })
            .then(response => response.json())
            .then((result) => {
                if (result.responseCode === '1001_01') {
                    alert('Project : ' + this.state.name + ' has been created successfully');
                }
                else {
                    alert('Error in creating project ' + this.state.name);
                }

            },
                (error) => {
                    alert('Failed....')
                }
            )
    }


    render() {
        return (
            <div className="formtext">
                <h3>Project Assignments - HardCodedProjectName</h3>

                {/* <Dropdown>
                    <Dropdown.Toggle variant="success" id="dropdown-basic">
                        New Member
                    </Dropdown.Toggle>

                    <Dropdown.Menu>
                        <Dropdown.Item href="#/action-1">Action</Dropdown.Item>
                        <Dropdown.Item href="#/action-2">Another action</Dropdown.Item>
                        <Dropdown.Item href="#/action-3">Something else</Dropdown.Item>
                    </Dropdown.Menu>
                </Dropdown> */}

                <div>
                    <ul>
                        <li><Link to="/projector/projects">Go Back</Link></li>
                    </ul>
                </div>

            </div>

        );
    }
}

