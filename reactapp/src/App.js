import React from 'react';
import './App.css';
import Navbar from './Navbar';
import Footer from './Footer';
import Login from './components/Login';
import Registration from './components/Registration';
import Home from './components/Home';
import Book from './components/Book';
import Visits from './components/Visits';
import Account from './components/Account';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

const App = () => {
  const RenderWithNavbar = ({ children }) => (
    <>
      <Navbar />
      {children}
    </>
  );
  
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/registration" element={<Registration />} />
        <Route path="/home" element={<RenderWithNavbar><Home /></RenderWithNavbar>} />
        <Route path="/book" element={<RenderWithNavbar><Book /></RenderWithNavbar>} />
        <Route path="/visits" element={<RenderWithNavbar><Visits /></RenderWithNavbar>} />
        <Route path="/account" element={<RenderWithNavbar><Account /></RenderWithNavbar>} />
      </Routes>
      <Footer />
    </Router>
  );
}

export default App;
