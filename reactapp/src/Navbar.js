import React from 'react';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { Link as RouterLink } from 'react-router-dom';

const AppNavbar = () => {

  return (
    <>
      <Navbar bg="dark" variant="dark" expand="lg">
        <Container>
          <Navbar.Brand as={RouterLink} to="/home">BarberHouse</Navbar.Brand>
          <Navbar.Toggle aria-controls="responsive-navbar-nav" />
          <Navbar.Collapse id="responsive-navbar-nav">
            <Nav className="me-auto yellow-links">
              <Nav.Link as={RouterLink} to="/home">Home</Nav.Link>
            </Nav>
            <Nav className="ms-auto yellow-links">
              <Nav.Link as={RouterLink} to="/book">Book</Nav.Link>
              <Nav.Link as={RouterLink} to="/visits">Visits</Nav.Link>
              <NavDropdown title="ADMIN PANEL" id="collasible-nav-dropdown">
                <NavDropdown.Item as={RouterLink} to="/account">Visits</NavDropdown.Item>
                <NavDropdown.Item as={RouterLink} to="/account">Users</NavDropdown.Item>
                <NavDropdown.Item as={RouterLink} to="/account">Dates</NavDropdown.Item>
                <NavDropdown.Item as={RouterLink} to="/account">Services</NavDropdown.Item>
                <NavDropdown.Item as={RouterLink} to="/account">Barbers</NavDropdown.Item>
              </NavDropdown>
              <NavDropdown title="Account" id="collasible-nav-dropdown">
                <NavDropdown.Item as={RouterLink} to="/account">My account</NavDropdown.Item>
                <NavDropdown.Item as={RouterLink} to="/">Log out</NavDropdown.Item>
              </NavDropdown>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </>
  );
}

export default AppNavbar;