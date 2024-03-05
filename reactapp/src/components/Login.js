import React from 'react';
import { Form, Button, Col, Row } from 'react-bootstrap';
import '../App.css';
import '../styles/Login.css';

const Login = () => {
  return (
    <div className="App">
      <div className="row">
        <div className="col-md-6 left-side">
          <div className="left-container">
            <Form>
              <h3>Sign In</h3>
              <Form.Group className="mb-3">
                <Form.Label>E-mail</Form.Label>
                <Form.Control type="email" placeholder="Enter e-mail" />
              </Form.Group>
              <Form.Group className="mb-3">
                <Form.Label>Password</Form.Label>
                <Form.Control type="password" placeholder="Enter password" />
              </Form.Group>
              <div className="d-grid">
                <Button variant="dark" type="submit">Log In</Button>
              </div>
            </Form>
          </div>
        </div>
        <div className="col-md-6 right-side">
          <div className="right-container">
            <Form>
              <h3>Sign Up</h3>
              <Row>
                <Form.Group as={Col} className="mb-3">
                  <Form.Label className="white-label">Name</Form.Label>
                  <Form.Control size="sm" type="text" placeholder="Enter name" />
                </Form.Group>
                <Form.Group as={Col} className="mb-3">
                  <Form.Label className="white-label">Surname</Form.Label>
                  <Form.Control size="sm" type="text" placeholder="Enter surname" />
                </Form.Group>
              </Row>
              <Form.Group className="mb-3">
                <Form.Label className="white-label">E-mail</Form.Label>
                <Form.Control size="sm" type="email" placeholder="Enter e-mail" />
              </Form.Group>
              <Row>
                <Form.Group as={Col} className="mb-3">
                  <Form.Label className="white-label">Password</Form.Label>
                  <Form.Control size="sm" type="password" placeholder="Enter password" />
                </Form.Group>
                <Form.Group as={Col} className="mb-3">
                  <Form.Label className="white-label">Confirm password</Form.Label>
                  <Form.Control size="sm" type="password" placeholder="Enter password again" />
                </Form.Group>
              </Row>
              <Row>
                <Form.Group as={Col} className="mb-3">
                  <Form.Label className="white-label">Phone number</Form.Label>
                  <Form.Control size="sm" type="tel" placeholder="Enter phone number" />
                </Form.Group>
                <Form.Group as={Col} className="mb-3">
                  <Form.Label className="white-label">Birthday</Form.Label>
                  <Form.Control size="sm" type="date" />
                </Form.Group>
              </Row>
              <Form.Group className="mb-3">
                <Form.Label className="white-label">Address</Form.Label>
                <Form.Control size="sm" type="text" placeholder="Enter address" />
              </Form.Group>
              <Form.Check className="white-label" type="switch" id="custom-switch" label="I confirm the terms and conditions.*" />
              <Row>
                <Form.Group as={Col} className="mb-3">
                  <Button variant="warning" type="submit" className="long-button">Register</Button>
                </Form.Group>
                <Form.Group as={Col} className="mb-3">
                  <Button variant="secondary" type="reset" className="long-button">Clear fields</Button>
                </Form.Group>
              </Row>
            </Form>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Login;