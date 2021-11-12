import React, {Component} from 'react';
import { Navbar, Nav } from "react-bootstrap";


export class SiteNavigation extends Component {
    render () {
        return(
            <Navbar bg="light" expand="lg">
              {/* <Navbar.Brand href="#home">React-Bootstrap</Navbar.Brand> */}
              <Navbar.Toggle aria-controls="basic-navbar-nav" />
              <Navbar.Collapse id="basic-navbar-nav">
                <Nav className="me-auto">
                  <Nav.Link href="/">The Projector</Nav.Link>
                  <Nav.Link href="/projector/signin">SIgn In</Nav.Link>
                  <Nav.Link href="/projector/projects">Projects</Nav.Link>
                  {/* <Nav.Link href="/projector/projects/create">Create Project</Nav.Link>
                  <Nav.Link href="/projector/persons/create">Create Person</Nav.Link> */}
                </Nav>
              </Navbar.Collapse>
          </Navbar>
            )
            }
        }
