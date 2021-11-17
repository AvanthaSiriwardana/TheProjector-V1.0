import React, { Component } from 'react';
import { Form, Button } from "react-bootstrap";
import { Link } from 'react-router-dom';

export class CreateProject extends Component {
  constructor(props) {
    super(props);
    this.state = {
      code: "",
      name: "",
      budget: "",
      remarks: "",
    };
  }

  validateForm() {
    return this.state.code.length > 0 && this.state.name.length > 0
      && this.state.remarks.length > 0 && this.state.budget > 0;
  }

  // Set State
  handleChange = event => {
    this.setState({
      [event.target.id]: event.target.value
    });
  }

  // Handles Create Project Event
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
        <h3>Create Project</h3>
        <Form onSubmit={this.handleSubmit}>
          <Form.Group controlId="code" bsSize="small">
            <Form.Control
              autoFocus
              type="text"
              placeholder="Code"
              required
              value={this.state.code}
              onChange={this.handleChange}
            />
          </Form.Group>
          <Form.Group controlId="name" bsSize="small">
            <Form.Control
              value={this.state.name}
              onChange={this.handleChange}
              type="text"
              placeholder="Name"
              required
            />
          </Form.Group>
          <Form.Group controlId="budget" bsSize="small">
            <Form.Control
              value={this.state.budget}
              onChange={this.handleChange}
              type="text"
              placeholder="Budget"
              required
            />
          </Form.Group>
          <Form.Group controlId="remarks" bsSize="small">
            <Form.Control
              value={this.state.remarks}
              onChange={this.handleChange}
              type="text"
              placeholder="Remarks"
              required
            />
          </Form.Group>
          <Button variant="primary" type="submit" size="sm"
            disabled={!this.validateForm()}
          >Save</Button>
        </Form>

        <br /><br />

        <div>
          <Link to="/projector/projects" >Go Back</Link>

        </div>

      </div>

    );
  }
}