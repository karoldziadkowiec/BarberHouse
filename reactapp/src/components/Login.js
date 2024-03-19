import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Form, Button, Modal } from 'react-bootstrap';
import '../App.css';
import '../styles/Login.css';

const Login = () => {
  const [loginData, setLoginData] = useState({
    email: '',
    password: ''
  });

  const [showModal, setShowModal] = useState(false);
  const [message, setMessage] = useState('');
  const navigate = useNavigate();

  const handleLoginInputChange = (e) => {
    const { name, value } = e.target;
    setLoginData(prevState => ({
      ...prevState,
      [name]: value
    }));
  };

  const handleLogin = async (e) => {
    e.preventDefault();

    try {
      const response = await fetch('https://localhost:7184/api/login', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(loginData)
      });

      if (!response.ok) {
        throw new Error('Error: Login failed.');
      }

      const { token } = await response.json();

      localStorage.setItem('token', token);

      moveToHomePage();

    } catch (error) {
      console.error('Error:', error);
      setShowModal(true);
      setMessage('Error: Login failed');
    }
  };

  const moveToHomePage = () => {
    navigate('/home');
  };

  const moveToRegistrationPage = () => {
    navigate('/registration');
  };

  return (
    <div className="Login">
      <div className="login-container">
        <Form onSubmit={handleLogin}>
          <h3>Sign In</h3>
          <Form.Group className="mb-3" controlId="formBasicEmail">
            <Form.Label className="white-label">E-mail</Form.Label>
            <Form.Control type="email" placeholder="Enter e-mail" name="email" value={loginData.email} onChange={handleLoginInputChange} required />
          </Form.Group>
          <Form.Group className="mb-3" controlId="formBasicPassword">
            <Form.Label className="white-label">Password</Form.Label>
            <Form.Control type="password" placeholder="Enter password" name="password" value={loginData.password} onChange={handleLoginInputChange} required />
          </Form.Group>
          <div className="d-grid">
            <Button variant="warning" type="submit">Log In</Button>
            <Button variant="secondary" onClick={moveToRegistrationPage}>Register account</Button>
          </div>
        </Form>

        <Modal show={showModal} onHide={() => setShowModal(false)}>
          <Modal.Header closeButton>
            <Modal.Title>BarberHouse</Modal.Title>
          </Modal.Header>
          <Modal.Body>{message}</Modal.Body>
          <Modal.Footer>
            <Button variant="danger" onClick={() => setShowModal(false)}>Close</Button>
          </Modal.Footer>
        </Modal>
      </div>
    </div>
  );
}

export default Login;
