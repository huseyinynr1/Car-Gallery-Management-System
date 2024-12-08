import React, { Component } from "react";
import "../Styles/carManagement.css";

export default class SearchBar extends Component {
  render() {
    return (
      <div className="search-bar">
        <input type="text" placeholder="Search..." className="search-input" />
        <i className="bi bi-search"></i>
      </div>
    );
  }
}
