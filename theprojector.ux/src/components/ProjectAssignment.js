import React, { Component } from 'react';
import { Form, Button, Row, Col } from "react-bootstrap";

import { ProjectUnassignment } from './ProjectUnassignment';

export class ProjectAssignment extends Component {
    constructor(props) {
        super(props);
        this.state = { personList: [] }
    }

    componentDidMount() {
        this.refreshList();
    }

    refreshList() { 
        this.setState({
            personList: [{ "personid": 1, "personname": "Avantha" },
            { "personid": 2, "personname": "Jeseca" },
            { "personid": 2, "personname": "Miarah" }]
        })
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

    }


    render() {
        const { personList } = this.state;

        return (
            <div className="formtext">

                <h4>Project Assignments - HardCodedProjectName</h4>

                <Form onSubmit={this.handleSubmit}>
                    <Row>
                        <Col>
                            <Form.Label>New Member</Form.Label>
                            <Form.Control as="select">
                                {personList.map(person =>
                                    <option key={person.personid}>{person.personname}</option>
                                )}
                            </Form.Control>
                        </Col>
                    </Row>
                    <Row>
                    <Col>
                            {/* <Button variant="primary" type="submit" size="lg">Save</Button> */}
                            <div className="d-grid gap-2">
  <Button variant="primary" size="sm" type="submit" >
  Save
  </Button>
</div>
                        </Col>
                    </Row>
                </Form>

                <br /><br />

                <ProjectUnassignment />

                
            </div >
        );
    }
}

