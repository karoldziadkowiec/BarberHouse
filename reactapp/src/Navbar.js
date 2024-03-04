import React from 'react';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
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
      <Navbar bg="dark" variant="dark">
        <Container>
          <Navbar.Brand as={RouterLink} to="/">BarberHouse</Navbar.Brand>
          <Nav className="me-auto">
            <Nav.Link onClick={() => handleClick("home")} style={{cursor: "pointer"}}>Home</Nav.Link>
            <Nav.Link onClick={() => handleClick("about")} style={{cursor: "pointer"}}>About us</Nav.Link>
            <Nav.Link onClick={() => handleClick("team")} style={{cursor: "pointer"}}>Team</Nav.Link>
            <Nav.Link onClick={() => handleClick("services")} style={{cursor: "pointer"}}>Services</Nav.Link>
            <Nav.Link onClick={() => handleClick("socials")} style={{cursor: "pointer"}}>Our socials</Nav.Link>
            <Nav.Link as={RouterLink} to="/book">Book</Nav.Link>
            <Nav.Link as={RouterLink} to="/visits">Visits</Nav.Link>
            <Nav.Link as={RouterLink} to="/account">Account</Nav.Link>
            <Nav.Link as={RouterLink} to="/login">Sign up</Nav.Link>
          </Nav>
        </Container>
      </Navbar>
    </>
  );
}

export default AppNavbar;