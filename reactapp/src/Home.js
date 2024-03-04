import React from 'react';
import Card from 'react-bootstrap/Card';
import ListGroup from 'react-bootstrap/ListGroup';
import './App.css';
import './Home.css';

const Home = () => {
  return (
    <div className="App">
      <section id="home" className="startSection">
        <h1>
          <img src={require('./img/pole.png')} alt="pole" className="pole" />
          <span className="barberhouse">BARBERHOUSE</span>
          <img src={require('./img/pole.png')} alt="pole" className="pole" />
        </h1>
        <img src={require('./img/icon.png')} alt="icon" className="icon" />
        <h2>EXPERIENCE BARBERHOUSE: WHERE STYLE MEETS EXCELLENCE</h2>
        <h3>Step into our world of expert grooming and leave feeling confident and refreshed</h3>
      </section>
      <section id="about" className="blackBackground">
        <h1>About us</h1>
        <h5>At BarberHouse, we're dedicated to providing top-notch grooming services tailored to your style and preferences.</h5>
        <h5>With a team of skilled professionals, we strive to create a welcoming environment where every client feels valued and leaves looking their best.</h5>
        <p></p>
        <h6>
          <img src={require('./img/working-hours.png')} alt="working-hours" className="contact" />
          <span> Working hours: </span>
          <span className="contact-def">Mon - Fri: 9:00 - 17:00</span>
          <span>, </span>
          <span className="contact-def">Sat: 9:00 - 14:00</span>
          <span>, </span>
          <span className="contact-def">Sun: Closed</span>
        </h6>
        <h6>
          <img src={require('./img/location.png')} alt="location" className="contact" />
          <span> Location: </span>
          <span className="contact-def">Long Street 21</span>
          <span>, </span>
          <span className="contact-def">Cracow</span>
        </h6>
        <h6>
          <img src={require('./img/phone.png')} alt="phone" className="contact" />
          <span> Contact: </span>
          <span className="contact-def">+48 123 456 789</span>
        </h6>
        <h6>
          <img src={require('./img/email.png')} alt="email" className="contact" />
          <span> E-mail: </span>
          <span className="contact-def">barberhouse@gmail.com</span>
        </h6>
      </section>
      <section id="team" className="whiteBackground">
        <h1>Team</h1>
        <h5>Meet our skilled barbers dedicated to precision cuts and personalized grooming.</h5>
        <h5>Leave feeling confident and refreshed with our tailored services.</h5>
      </section>
      <section id="team" className="whiteBackground d-flex justify-content-center align-items-center">
        <div className="card-container">
          <div className="row">
            <div className="col-lg-4 col-md-6 mb-4 d-flex justify-content-center">
              <Card style={{ width: '18rem' }}>
                <Card.Img variant="top" src="https://cdn.galleries.smcloud.net/t/galleries/gf-ZTYg-2eMv-nnf2_boxdel-spina-wiek-wzrost-zeby-dziewczyna-majatek-choroba-kim-jest-michal-baron-994x828.jpg" />
                <Card.Body>
                  <Card.Title>Name</Card.Title>
                  <Card.Text>Surname</Card.Text>
                </Card.Body>
                <ListGroup className="list-group-flush">
                  <ListGroup.Item>Phone</ListGroup.Item>
                  <ListGroup.Item>E-mail</ListGroup.Item>
                </ListGroup>
              </Card>
            </div>
            <div className="col-lg-4 col-md-6 mb-4 d-flex justify-content-center">
              <Card style={{ width: '18rem' }}>
                <Card.Img variant="top" src="https://cdn.galleries.smcloud.net/t/galleries/gf-ZTYg-2eMv-nnf2_boxdel-spina-wiek-wzrost-zeby-dziewczyna-majatek-choroba-kim-jest-michal-baron-994x828.jpg" />
                <Card.Body>
                  <Card.Title>Name</Card.Title>
                  <Card.Text>Surname</Card.Text>
                </Card.Body>
                <ListGroup className="list-group-flush">
                  <ListGroup.Item>Phone</ListGroup.Item>
                  <ListGroup.Item>E-mail</ListGroup.Item>
                </ListGroup>
              </Card>
            </div>
            <div className="col-lg-4 col-md-6 mb-4 d-flex justify-content-center">
              <Card style={{ width: '18rem' }}>
                <Card.Img variant="top" src="https://cdn.galleries.smcloud.net/t/galleries/gf-ZTYg-2eMv-nnf2_boxdel-spina-wiek-wzrost-zeby-dziewczyna-majatek-choroba-kim-jest-michal-baron-994x828.jpg" />
                <Card.Body>
                  <Card.Title>Name</Card.Title>
                  <Card.Text>Surname</Card.Text>
                </Card.Body>
                <ListGroup className="list-group-flush">
                  <ListGroup.Item>Phone</ListGroup.Item>
                  <ListGroup.Item>E-mail</ListGroup.Item>
                </ListGroup>
              </Card>
            </div>
          </div>
        </div>
      </section>
      <section id="services" className="blackBackground">
      <h1>Services</h1>
      <h5>Explore our range of grooming options designed to enhance your style and confidence.</h5>
      <h5>From classic cuts to beard trims, we offer personalized services tailored to your needs.</h5>
      </section>
      <section id="services" className="blackBackground d-flex justify-content-center align-items-center">
        <div className="card-container">
          <div className="row">
            <div className="col-lg-4 mb-4 d-flex justify-content-center">
              <Card border="warning" style={{ width: '18rem' }}>
                <Card.Body>
                  <Card.Title>Service</Card.Title>
                  <Card.Header>Value</Card.Header>
                  <Card.Text>Description</Card.Text>
                  <Card.Header>Time</Card.Header>
                </Card.Body>
              </Card>
            </div>
            <div className="col-lg-4 mb-4 d-flex justify-content-center">
              <Card border="warning" style={{ width: '18rem' }}>
                <Card.Body>
                  <Card.Title>Service</Card.Title>
                  <Card.Header>Value</Card.Header>
                  <Card.Text>Description</Card.Text>
                  <Card.Header>Time</Card.Header>
                </Card.Body>
              </Card>
            </div>
            <div className="col-lg-4 mb-4 d-flex justify-content-center">
              <Card border="warning" style={{ width: '18rem' }}>
                <Card.Body>
                  <Card.Title>Service</Card.Title>
                  <Card.Header>Value</Card.Header>
                  <Card.Text>Description</Card.Text>
                  <Card.Header>Time</Card.Header>
                </Card.Body>
              </Card>
            </div>
          </div>
        </div>
      </section>
      <section id="socials" className="socials-whiteBackground">
        <h1>Our socials</h1>
        <h4>Stay up to date with us on our social media!</h4>
        <a href="https://www.facebook.com/" target="_blank" rel="noopener noreferrer">
          <img src={require('./img/facebook.png')} alt="facebook" className="socials" />
        </a>
        <a href="https://www.instagram.com/" target="_blank" rel="noopener noreferrer">
          <img src={require('./img/instagram.png')} alt="instagram" className="socials" />
        </a>
        <a href="https://www.tiktok.com/" target="_blank" rel="noopener noreferrer">
          <img src={require('./img/tiktok.png')} alt="tiktok" className="socials" />
        </a>
      </section>
    </div>
  );
}

export default Home;