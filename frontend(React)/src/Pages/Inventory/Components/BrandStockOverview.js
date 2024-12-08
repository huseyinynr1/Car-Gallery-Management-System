import React from 'react'
import "../Styles/inventory.css";
import { useDispatch, useSelector } from 'react-redux';
import * as brandActions from "../../../redux/actions/brandActions";


const BrandStockOverview = () => {
const dispatch = useDispatch();

const carCount = useSelector((state) => state.brand.carsCountByBrandName);

const handleMouseEnter = (brandName) => {
  console.log(`Fetching car count for ${brandName}`); // Hangi markanın sayısını çektiğinizi kontrol edin
  dispatch(brandActions.handleGetCarsCountByBrandName(brandName));
};
  return (
    <div className='brad-overview-container'>
      <h3>Marka Bazlı Stok Durumu</h3>

      <div className='brand-first-block'> 
      <button className='brand-img' 
      id='mercedes'
      onMouseEnter={() => handleMouseEnter('Mercedes')}
      >
        <span className='tooltip-text'>Mercedes : {carCount.Mercedes}</span>
      </button>

      <button className='brand-img'
      id='audi'
      onMouseEnter={() => handleMouseEnter('Audi')}>
      <span className='tooltip-text'>Audi : {carCount.Audi}</span>
      </button>

      <button className='brand-img' 
      id='bmw'
      onMouseEnter={() => handleMouseEnter('BMW')}>
      <span className='tooltip-text'>BMW : {carCount.BMW}</span>
      </button>

      <button className='brand-img' 
      id='renault'
      onMouseEnter={() => handleMouseEnter('Renault')}>
      
      <span className='tooltip-text'>Renault : {carCount.Renault}</span>
      </button>

      <button className='brand-img' 
      id='ford'
      onMouseEnter={() => handleMouseEnter('Ford')}>
      <span className='tooltip-text'>Ford : {carCount.Ford}</span>
      </button>

      </div>
      
      <div className='brand-second-block'>

      <button className='brand-img' 
      id='volkswagen'
      onMouseEnter={() => handleMouseEnter('Volkswagen')}>
      <span className='tooltip-text'>Volkswagen : {carCount.Volkswagen}</span>
      </button>

      <button className='brand-img' 
      id='hyundai'
      onMouseEnter={() => handleMouseEnter('Hyundai')}>
      <span className='tooltip-text'>Hyundai : {carCount.Hyundai}</span>
      </button>

      <button className='brand-img' 
      id='honda'
      onMouseEnter={() => handleMouseEnter('Honda')}>
      <span className='tooltip-text'>Honda : {carCount.Honda}</span>
      </button>
      <button className='brand-img' id='ferrari'
      onMouseEnter={() => handleMouseEnter('Ferrari')}>

      <span className='tooltip-text'>Ferrari : {carCount.Ferrari}</span>
      </button>

      <button className='brand-img' id='dacia'
      onMouseEnter={() => handleMouseEnter('Dacia')}>

      <span className='tooltip-text'>Dacia : {carCount.Dacia}</span>
      </button>
      </div>
      
      <div className='brand-third-block'>

      <button className='brand-img' 
      id='alfa'
      onMouseEnter={() => handleMouseEnter('Alfa')}>

      <span className='tooltip-text'>Alfa : {carCount.Alfa}</span>
      </button>

      <button className='brand-img' 
      id='skoda'
      onMouseEnter={() => handleMouseEnter('Skoda')}>
      <span className='tooltip-text'>Skoda : {carCount.Skoda}</span>
      </button>

      <button className='brand-img' 
      id='jeep'
      onMouseEnter={() => handleMouseEnter('Jeep')}>

      <span className='tooltip-text'>Jeep : {carCount.Jeep}</span>
      </button>

      <button className='brand-img' 
      id='fiat'
      onMouseEnter={() => handleMouseEnter('Fiat')}>

      <span className='tooltip-text'>Fiat : {carCount.Fiat}</span>
      </button>

      <button className='brand-img' 
      id='opel'
      onMouseEnter={() => handleMouseEnter('Opel')}>

      <span className='tooltip-text'>Opel : {carCount.Opel}</span>
      </button>
      </div>
      
    </div>
  )
}
export default BrandStockOverview ;