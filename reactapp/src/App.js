import React from 'react';
import './App.css';
import Navbar from './Navbar';
import Footer from './Footer';
import Home from './Home';
import About from './About';
import Services from './Services';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

const App = () => {
  return (
    <Router>
      <Navbar />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/about" element={<About />} />
        <Route path="/services" element={<Services />} />
      </Routes>
      <Footer /> 
    </Router>
  );
}

export default App;