import React from 'react';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { Link } from 'react-router-dom';

const AppNavbar = () => {
  return (
    <>
      <Navbar bg="dark" variant="dark">
        <Container>
          <Navbar.Brand as={Link} to="/">BarberHouse</Navbar.Brand>
          <Nav className="me-auto">
            <Nav.Link as={Link} to="/">Home</Nav.Link>
            <Nav.Link as={Link} to="/">About us</Nav.Link>
            <Nav.Link as={Link} to="/">Team</Nav.Link>
            <Nav.Link as={Link} to="/">Services</Nav.Link>
            <Nav.Link as={Link} to="/">Our socials</Nav.Link>
            <Nav.Link as={Link} to="/book">Book</Nav.Link>
            <Nav.Link as={Link} to="/visits">Visits</Nav.Link>
            <Nav.Link as={Link} to="/account">Account</Nav.Link>
            <Nav.Link as={Link} to="/login">Sign up</Nav.Link>
          </Nav>
        </Container>
      </Navbar>
    </>
  );
}

export default AppNavbar;