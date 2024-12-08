import React, { Component } from "react";
import StatisticsPanel from './Components/StatisticsPanel';
import QuickAccessButton from './Components/QuickAccessButton';
import IndıcatorComponent from './Components/IndıcatorComponent';
import Announcements from './Components/Announcements';
import './Styles/homepage.css';
import LogOutButton from "./Components/LogOutButton";

class HomePage extends Component {
  render() {
    return (
      <div className="homepage-background">
        <Announcements />
        <StatisticsPanel />
        <IndıcatorComponent />
        <QuickAccessButton />
        <LogOutButton />
      </div>
    );
  }
}

export default HomePage;
