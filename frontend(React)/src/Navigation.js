import React, { Component } from 'react'
import {Link} from 'react-router-dom';
import "./css/global.css";
import "./css/main.css";


export default class Navigation extends Component {
  render() {
    return (
      <div >
          <nav id="navi-bar">
            <h1 className='heading-small'>Company Name</h1>
            <ul>
                <li><Link to="/">Ana Sayfa</Link></li>
                <li><Link to='/car-management'>Araç Yönetimi</Link></li>
                <li><Link to='/Inventory'>Envanter</Link></li>
                <li><Link to='/serviceAndMaintenance'>Servis ve Bakım</Link></li>
                <li><Link to='/salesHub'>Satış Merkezi</Link></li>         
            </ul>
        </nav>
      </div>
      )
  }
}
