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
