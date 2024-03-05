import React from 'react';
import { Form, Button } from 'react-bootstrap';
import '../App.css';

const Login = () => {

  return (
    <div className="App">
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

      <Form>
        <h3>Sign Up</h3>
        <Form.Group className="mb-3">
          <Form.Label>Name</Form.Label>
          <Form.Control type="text" placeholder="Enter name" />
        </Form.Group>
        <Form.Group className="mb-3">
          <Form.Label>Surname</Form.Label>
          <Form.Control type="text" placeholder="Enter surname" />
        </Form.Group>
        <Form.Group className="mb-3">
          <Form.Label>E-mail</Form.Label>
          <Form.Control type="email" placeholder="Enter e-mail" />
        </Form.Group>
        <Form.Group className="mb-3">
          <Form.Label>Password</Form.Label>
          <Form.Control type="password" placeholder="Enter password" />
        </Form.Group>
        <Form.Group className="mb-3">
          <Form.Label>Confirm password</Form.Label>
          <Form.Control type="password" placeholder="Enter password again" />
        </Form.Group>
        <Form.Group className="mb-3">
          <Form.Label>Phone number</Form.Label>
          <Form.Control type="tel" placeholder="Enter phone number" />
        </Form.Group>
        <Form.Group className="mb-3">
          <Form.Label>Address</Form.Label>
          <Form.Control type="text" placeholder="Enter address" />
        </Form.Group>
        <Form.Group className="mb-3">
          <Form.Label>Birthday</Form.Label>
          <Form.Control type="date" />
        </Form.Group>
        <Form.Check type="switch" id="custom-switch" label="I confirm the terms and conditions.*" />
        <div className="d-grid">
          <Button variant="warning" type="submit">Register</Button>
          <Button variant="secondary" type="reset">Clear fields</Button>
        </div>
      </Form>
    </div>
  );
}

export default Login;