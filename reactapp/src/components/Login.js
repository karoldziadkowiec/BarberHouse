import React, { useState } from 'react';
import { Form, Button, Col, Row, Modal } from 'react-bootstrap';
import '../App.css';
import '../styles/Login.css';

const Login = () => {
  const [formData, setFormData] = useState({
    name: '',
    surname: '',
    email: '',
    password: '',
    confirmedPassword: '',
    phone: '',
    birthday: new Date().toISOString().split('.')[0],
    address: ''
  });

  const [termsAccepted, setTermsAccepted] = useState(false);
  const [showModal, setShowModal] = useState(false);
  const [errorMessage, setErrorMessage] = useState('');

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData(prevState => ({
      ...prevState,
      [name]: value
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    for (const key in formData) {
      if (formData[key] === '') {
        setShowModal(true);
        setErrorMessage('All fields are required.');
        return;
      }
    }

    if (formData.password !== formData.confirmedPassword) {
      setShowModal(true);
      setErrorMessage('Passwords do not match.');
      return;
    }

    if (!termsAccepted) {
      setShowModal(true);
      setErrorMessage('You must confirm the terms and conditions.');
      return;
    }

    try {
      const response = await fetch('https://localhost:7184/api/register', {
          method: 'POST',
          headers: {
              'Content-Type': 'application/json'
          },
          body: JSON.stringify(formData)
      });

      if (!response.ok) {
          throw new Error('Registration failed.');
      }

      setShowModal(true);
      setErrorMessage('Your account has been successfully registered.');
      window.location.reload();

    } catch (error) {
      console.error('Error:', error);
      window.location.reload();
    }
  };

  return (
    <div className="App">
      <div className="row">
        <div className="col-md-6 left-side">
          <div className="left-container">
            <Form>
              <h3>Sign In</h3>
              <Form.Group className="mb-3">
                <Form.Label>E-mail</Form.Label>
                <Form.Control type="Email" placeholder="Enter e-mail" />
              </Form.Group>
              <Form.Group className="mb-3">
                <Form.Label>Password</Form.Label>
                <Form.Control type="Password" placeholder="Enter password" />
              </Form.Group>
              <div className="d-grid">
                <Button variant="dark" type="submit">Log In</Button>
              </div>
            </Form>
          </div>
        </div>
        <div className="col-md-6 right-side">
          <div className="right-container">
            <Form onSubmit={handleSubmit}>
              <h3>Sign Up</h3>
              <Row>
                <Form.Group as={Col} className="mb-3">
                  <Form.Label className="white-label">Name</Form.Label>
                  <Form.Control name="name" size="sm" type="text" placeholder="Enter name" onChange={handleInputChange} />
                </Form.Group>
                <Form.Group as={Col} className="mb-3">
                  <Form.Label className="white-label">Surname</Form.Label>
                  <Form.Control name="surname" size="sm" type="text" placeholder="Enter surname" onChange={handleInputChange} />
                </Form.Group>
              </Row>
              <Form.Group className="mb-3">
                <Form.Label className="white-label">E-mail</Form.Label>
                <Form.Control name="email" size="sm" type="email" placeholder="Enter e-mail" onChange={handleInputChange} />
              </Form.Group>
              <Row>
                <Form.Group as={Col} className="mb-3">
                  <Form.Label className="white-label">Password</Form.Label>
                  <Form.Control name="password" size="sm" type="password" placeholder="Enter password" onChange={handleInputChange} />
                </Form.Group>
                <Form.Group as={Col} className="mb-3">
                  <Form.Label className="white-label">Confirm password</Form.Label>
                  <Form.Control name="confirmedPassword" size="sm" type="password" placeholder="Enter password again" onChange={handleInputChange} />
                </Form.Group>
              </Row>
              <Row>
                <Form.Group as={Col} className="mb-3">
                  <Form.Label className="white-label">Phone number</Form.Label>
                  <Form.Control name="phone" size="sm" type="tel" placeholder="Enter phone number" onChange={handleInputChange} />
                </Form.Group>
                <Form.Group as={Col} className="mb-3">
                  <Form.Label className="white-label">Birthday</Form.Label>
                  <Form.Control name="birthday" size="sm" type="date" onChange={handleInputChange} />
                </Form.Group>
              </Row>
              <Form.Group className="mb-3">
                <Form.Label className="white-label">Address</Form.Label>
                <Form.Control name="address" size="sm" type="text" placeholder="Enter address" onChange={handleInputChange} />
              </Form.Group>
              <Form.Check className="white-label" type="switch" id="switcher" label="I confirm the terms and conditions.*" onChange={() => setTermsAccepted(!termsAccepted)} />
              
              <Modal show={showModal} onHide={() => setShowModal(false)}>
                <Modal.Header closeButton>
                  <Modal.Title>Error</Modal.Title>
                </Modal.Header>
                <Modal.Body>{errorMessage}</Modal.Body>
                <Modal.Footer>
                  <Button variant="secondary" onClick={() => setShowModal(false)}>
                    Close
                  </Button>
                </Modal.Footer>
              </Modal>
              
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