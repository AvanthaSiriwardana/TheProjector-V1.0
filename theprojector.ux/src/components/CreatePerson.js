import React, {Component} from 'react';
import { Form, Button } from "react-bootstrap";
import { Link } from 'react-router-dom';

export class CreatePerson extends Component {
    constructor(props) {
        super(props);
        this.state = {
            lastname: "",
            firstname: "",
            username: "",
            password: "",
          };
    }

    validateForm() {
        return (this.state.lastname.length > 2 && this.state.lastname.length < 50) &&
               (this.state.firstname.length > 2 && this.state.firstname.length < 50) &&
               (this.state.username.length > 5 && this.state.firstname.length < 200) &&
               (this.state.password.length > 7 && this.state.firstname.length < 11)
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

        fetch('http://localhost:26311/projector/persons/create', {
method:'POST',
headers: {
'Accept':'application/json',
'Content-Type': 'application/json'
},
body:JSON.stringify({
    LastName:event.target.lastname.value,
    FirstName:event.target.firstname.value, 
    UserName:event.target.username.value, 
    Password: event.target.password.value.trim()
})
})
.then(response=> response.json())
.then((result) => 
{
    if(result.responseCode === '1002_01')
    {
        alert('Person with email address: ' + this.state.username + ' has been created successfully');
    }
    else
    {
        alert('Error in creating person ' +  this.state.username);
    }
    
},
(error)=>{
alert('Failed....')
}
)
}
    render() { 
        return ( 
            <div className="formtext">
                <h3>Create Person</h3>
        <Form onSubmit={this.handleSubmit}>
          <Form.Group controlId="lastname" bsSize="small">
            <Form.Control
              autoFocus
              type="text" 
              placeholder="Last Name" 
              required 
              value={this.state.lastname}
              onChange={this.handleChange}
            />
          </Form.Group>
          <Form.Group controlId="firstname" bsSize="small">
            <Form.Control
              value={this.state.firstname}
              onChange={this.handleChange}
              type="text" 
              placeholder="First Name" 
              required
            />
          </Form.Group>
          <Form.Group controlId="username" bsSize="small">
            <Form.Control
              value={this.state.username}
              onChange={this.handleChange}
              type="email" 
              placeholder="User Name [email]" 
              required
            />
          </Form.Group>
          <Form.Group controlId="password" bsSize="small">
            <Form.Control
              value={this.state.password}
              onChange={this.handleChange}
              type="password" 
              placeholder="Password" 
              required
            />
          </Form.Group>
          <Button variant="primary"
            block
            bsSize="small"
            disabled={!this.validateForm()}
            type="submit"
          >Save</Button>

          
        <div>
                <ul>
                    <li><Link to="/projector/projects">Go Back</Link></li>
                </ul>
            </div>
        </Form>
      </div>

         );
    }
}