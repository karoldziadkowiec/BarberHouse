import React from 'react';
import './App.css';
import './Home.css';

const Home = () => {
  return (
    <div className="App">
      <section id="home" className="startSection">
        <h1>
          <img src={require('./img/pole.png')} alt="pole" className="pole"/>
          <span className="barberhouse">BARBERHOUSE</span>
          <img src={require('./img/pole.png')} alt="pole" className="pole"/>
        </h1>
        <img src={require('./img/icon.png')} alt="icon" className="icon"/>
        <h2>EXPERIENCE BARBERHOUSE: WHERE STYLE MEETS EXCELLENCE</h2>
        <h3>Step into our world of expert grooming and leave feeling confident and refreshed</h3>
      </section>
      <section id="about" className="blackBackground">
        <h1>About us</h1>
        <h5>At BarberHouse, we're dedicated to providing top-notch grooming services tailored to your style and preferences.</h5>
        <h5>With a team of skilled professionals, we strive to create a welcoming environment where every client feels valued and leaves looking their best.</h5>
        <p></p>
        <h6>
          <img src={require('./img/working-hours.png')} alt="working-hours" className="contact"/>
          <span> Working hours: </span>
          <span className="contact-def">Mon - Fri: 9:00 - 17:00</span>
          <span>, </span>
          <span className="contact-def">Sat: 9:00 - 14:00</span>
        </h6>
        <h6>
          <img src={require('./img/location.png')} alt="location" className="contact"/>
          <span> Location: </span>
          <span className="contact-def">Long Street 21</span>
          <span>, </span>
          <span className="contact-def">Cracow</span>
        </h6>
        <h6>
          <img src={require('./img/phone.png')} alt="phone" className="contact"/>
          <span> Contact: </span>
          <span className="contact-def">+48 123 456 789</span>
        </h6>
        <h6>
          <img src={require('./img/email.png')} alt="email" className="contact"/>
          <span> E-mail: </span>
          <span className="contact-def">barberhouse@gmail.com</span>
        </h6>
      </section>
      <section id="team" className="whiteBackground">
        <h1>Team</h1>
      </section>
      <section id="services" className="blackBackground">
        <h1>Services</h1>
      </section>
      <section id="socials" className="whiteBackground">
        <h1>Our socials</h1>
        <h4>Stay up to date with us on our social media!</h4>
        <a href="https://www.facebook.com/" target="_blank" rel="noopener noreferrer">
          <img src={require('./img/facebook.png')} alt="facebook" className="socials"/>
        </a>
        <a href="https://www.instagram.com/" target="_blank" rel="noopener noreferrer">
          <img src={require('./img/instagram.png')} alt="instagram" className="socials"/>
        </a>
        <a href="https://www.tiktok.com/" target="_blank" rel="noopener noreferrer">
          <img src={require('./img/tiktok.png')} alt="tiktok" className="socials"/>
        </a>
      </section>
    </div>
  );
}

export default Home;
