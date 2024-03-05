import React from 'react';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';
import { Link as RouterLink } from 'react-router-dom';
import { animateScroll } from 'react-scroll';

const AppNavbar = () => {

  const handleClick = (id) => {
    const path = window.location.pathname;

    if (path === "/") {
      animateScroll.scrollTo(document.getElementById(id).offsetTop, {
        smooth: true,
        duration: 100
      });
    }
    else {
      window.location.href = "/";
    }
  };

  return (
    <>
      <Navbar bg="dark" variant="dark" expand="lg">
        <Container>
          <Navbar.Brand as={RouterLink} to="/">BarberHouse</Navbar.Brand>
          <Navbar.Toggle aria-controls="responsive-navbar-nav" />
          <Navbar.Collapse id="responsive-navbar-nav">
            <Nav className="me-auto">
              <Nav.Link onClick={() => handleClick("home")} style={{ cursor: "pointer" }}>Home</Nav.Link>
              <Nav.Link onClick={() => handleClick("about")} style={{ cursor: "pointer" }}>About us</Nav.Link>
              <Nav.Link onClick={() => handleClick("team")} style={{ cursor: "pointer" }}>Team</Nav.Link>
              <Nav.Link onClick={() => handleClick("services")} style={{ cursor: "pointer" }}>Services</Nav.Link>
              <Nav.Link onClick={() => handleClick("socials")} style={{ cursor: "pointer" }}>Our socials</Nav.Link>
            </Nav>
            <Nav className="ms-auto">
              <Nav.Link as={RouterLink} to="/book">Book</Nav.Link>
              <Nav.Link as={RouterLink} to="/visits">Visits</Nav.Link>
              <NavDropdown title="ADMIN PANEL" id="collasible-nav-dropdown">
                <NavDropdown.Item as={RouterLink} to="/">Visits</NavDropdown.Item>
                <NavDropdown.Item as={RouterLink} to="/">Users</NavDropdown.Item>
                <NavDropdown.Item as={RouterLink} to="/">Dates</NavDropdown.Item>
                <NavDropdown.Item as={RouterLink} to="/">Services</NavDropdown.Item>
                <NavDropdown.Item as={RouterLink} to="/">Barbers</NavDropdown.Item>
              </NavDropdown>
              <NavDropdown title="Account" id="collasible-nav-dropdown">
                <NavDropdown.Item as={RouterLink} to="/account">My account</NavDropdown.Item>
                <NavDropdown.Item as={RouterLink} to="/">Log out</NavDropdown.Item>
              </NavDropdown>
              <Nav.Link as={RouterLink} to="/login">Sign In</Nav.Link>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </>
  );
}

export default AppNavbar;