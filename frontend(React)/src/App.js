import React from "react";
import {
  BrowserRouter as Router,
  Route,
  Routes,
  Navigate,
} from "react-router-dom";
import HomePage from "./Pages/Home/HomePage";
import Navigation from "./Navigation";
import CarManagement from "./Pages/CarManagement/CarManagement";
import Inventory from "./Pages/Inventory/Inventory";
import Login from "./Pages/Login/Login";
import { connect } from "react-redux";
import Maintenance from "./Pages/Maintenance/Maintenance";
import {  ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";



function App({ loginData }) {
  const isLoggedIn = loginData.user; // Kullanıcının login olup olmadığını kontrol ediyoruz
  const isRedirecting = loginData.isRedirecting;

  return (
    <div className="app-background">
      <Router>
      <ToastContainer 
        position="top-center" 
        autoClose = {3000} 
         hideProgressBar={false} 
        newestOnTop={false} 
        closeOnClick 
        rtl={false} 
        pauseOnFocusLoss 
        draggable 
        pauseOnHover/>
        <Routes>
          {/* Giriş yapılmadıysa login ekranına yönlendir */}
          <Route path="/login" element={<Login />} />

          {/* Her sayfa için Navigation componentini ekliyoruz */}
          <Route
            path="/"
            element={
              isLoggedIn && !isRedirecting ? (
                <>
                  <Navigation />
                  <HomePage />
                </>
              ) : (
                <Navigate to="/login" />
              )
            }
          />

          <Route
            path="/car-management"
            element={
              isLoggedIn && !isRedirecting ? (
                <>
                  <Navigation />
                  <CarManagement />
                </>
              ) : (
                <Navigate to="/login" />
              )
            }
          />

          <Route
            path="/inventory"
            element={
              isLoggedIn && !isRedirecting ? (
                <>
                  <Navigation />
                  <Inventory />
                </>
              ) : (
                <Navigate to="/login" />
              )
            }
          />

          <Route
            path="/serviceAndMaintenance"
            element={
              isLoggedIn && !isRedirecting ? (
                <>
                  <Navigation />
                  <Maintenance />
                </>
              ) : (
                <Navigate to="/login" />
              )
            }
          />
        </Routes>
      </Router>
    </div>
  );
}

function mapStateToProps(state) {
  return {
    loginData: state.login,
  };
}

export default connect(mapStateToProps)(App);
