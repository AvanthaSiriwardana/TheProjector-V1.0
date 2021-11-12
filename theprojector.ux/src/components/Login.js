import React, {Component} from 'react';
import { Form, Button } from "react-bootstrap";

export class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            username: "",
            password: "",
          };
    }

    validateForm() {
        return (this.state.username.length > 5 && this.state.username.length < 200) &&
               (this.state.password.length > 7 && this.state.password.length < 11)
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

        fetch('http://localhost:26311/projector/SignIn', {
method:'POST',
headers: {
'Accept':'application/json',
'Content-Type': 'application/json'
},
body:JSON.stringify({
    UserName:event.target.username.value, 
    Password: event.target.password.value
})
})
.then(response=> response.json())
.then((result) => 
{
    if(result.responseCode === '1005_01')
    {
        alert('You are loggedin succesfully ' + this.state.username);
        //history.push("/");

    }
    else
    {
        alert('Error in Login ' +  this.state.username);
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
              >Login</Button>
            </Form>
          </div>

         );
    }
}