import React, { Component } from 'react';
import { Navbar, Nav } from "react-bootstrap";


export class SiteNavigation extends Component {
  render() {
    return (
      <Navbar bg="light" expand="lg">
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link href="/">The Projector</Nav.Link>
            <Nav.Link href="/projector/signin">SIgn In</Nav.Link>
            <Nav.Link href="/projector/projects">Projects</Nav.Link>
            <Nav.Link href="/projector/projects/assignments">Assign Person</Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Navbar>
    )
  }
}
