import React from 'react';
import './App.css';
import Navbar from './Navbar';
import Footer from './Footer';
import Home from './components/Home';
import Book from './components/Book';
import Visits from './components/Visits';
import Account from './components/Account';
import Login from './components/Login';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

const App = () => {
  return (
    <Router>
      <Navbar />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/book" element={<Book />} />
        <Route path="/visits" element={<Visits />} />
        <Route path="/account" element={<Account />} />
        <Route path="/login" element={<Login />} />
      </Routes>
      <Footer /> 
    </Router>
  );
}

export default App;