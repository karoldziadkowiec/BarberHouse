import React from 'react';
import './App.css';
import './Home.css';

const Home = () => {
  return (
    <div className="App">
      <section id="home" className="whiteBackground">
        <h1>BarberHouse</h1>
      </section>
      <section id="about" className="blackBackground">
        <h1>About us</h1>
      </section>
      <section id="team" className="whiteBackground">
        <h1>Team</h1>
      </section>
      <section id="services" className="blackBackground">
        <h1>Services</h1>
      </section>
      <section id="socials" className="whiteBackground">
        <h1>Our socials</h1>
      </section>
    </div>
  );
}

export default Home;
