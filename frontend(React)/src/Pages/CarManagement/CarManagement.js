import React, { Component } from 'react'
import SearchBar from './Components/SearchBar'
import AddCarBlock from './Components/AddCarBlock'
import "./Styles/carManagement.css";
import CarList from './Components/CarList';


export default class CarManagement extends Component {
  render() {
    return (
      <div>
       <SearchBar/>
       <div className='panel'>
       <AddCarBlock/>
       <CarList />
     </div>
       
      </div>
    )
  }
}
