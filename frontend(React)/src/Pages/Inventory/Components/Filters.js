import React, { useEffect, useState } from "react";
import "../Styles/inventory.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faCopyright,
  faCarRear,
  faMoneyBill1,
  faGasPump,
  faFile,
  faGaugeHigh,
  faCalendarDays,
} from "@fortawesome/free-solid-svg-icons";
import { useDispatch, useSelector } from "react-redux";
import * as statusActions from "../../../redux/actions/statusActions";
import * as filterActions from "../../../redux/actions/filterActions";


const Filters = () => {
  const dispatch = useDispatch();
  const [carData,setCarData] = useState({
    brand : '',
    model: '',
    transmission: '',
    fuel:'',
    carStatus:'',
    
  });

  const brandsData = useSelector((state) => state.brand.brands);
  const modelsData = useSelector((state) => state.model.models);
  const transmissionsData = useSelector((state) => state.transmission.transmissions);
  const fuelsData = useSelector((state) => state.fuel.fuels);
  const statusData = useSelector((state) => state.status.status);
  const filtersData = useSelector((state) => state.filter.filters);

  useEffect(() => {
    dispatch(statusActions.handleGetStatusList());
  }, [dispatch]);


  const handleInputChange = (e) => {
    const {name,value} = e.target;
    setCarData((prevData) => ({
      ...prevData,
      [name] : value,
    }));

  };
  
  const handleSelectChange = (e,dataList,key) => {
    const value = e.target.value;

    if(value === ""){ // Eğer kullanıcı boş bir değer seçerse, ilgili filtreyi temizle
      setCarData((prevData) => ({
        ...prevData, // prevData'daki tüm özellikleri kopyala. (prevData : Seçilen yerin en son değerini alır ve yeni güncellenen veriye atar)
        [`${key}Id`]:"",
      }));
    }

    else{
      const selectedItem = dataList.find(item => item.id === e.target.value);
      if(selectedItem){
        setCarData(
          prevData => ({
            ...prevData,
            [`${key}Id`]: selectedItem.id
          }));
      }
    }  
  };

  const handleSubmit= (e) => {
    e.preventDefault();
    
    const filterData = {
      brandId : carData.brandId || null, //Eğer filtrelemede kullanıcı burada filtre seçmediyse null gidecek
      modelId : carData.modelId || null,
      transmissionId : carData.transmissionId || null,
      fuelId : carData.fuelId || null,
      carStatusId : carData.statusId || null,
      minPrice : carData.minPrice || null,
      maxPrice : carData.maxPrice || null,
      minKilometer : carData.minKm || null,
      maxKilometer : carData.maxKm || null,
      startDate: carData.startDate || null,
      endDate : carData.endDate|| null  
    }
  dispatch(filterActions.handleGetFilterList(filterData));
  }
  return (
    <div>
    <div className="filter-container">
      <div className="filters">
        <FontAwesomeIcon icon={faCopyright} className="icons" />
        <form className="forms">
          <label className="forms-labels">Marka</label>
          <select
            placeholder="Marka"
            className="filter-inputs"
            name="brand"
            value={carData.brandId || ''}
            onChange={(e) => handleSelectChange(e,brandsData,'brand')}
          >
            <option value=''>Marka</option>
            {Array.isArray(brandsData) &&
              brandsData.length > 0 &&
              brandsData.map((brand) => (
                <option key={brand.id} value={brand.id}>
                  {brand.name}
                </option>
              ))}
          </select>

        </form>
      </div>

      <div className="filters">
        <FontAwesomeIcon icon={faCarRear} className="icons" />

        <form className="forms">
          <label className="forms-labels">Model</label>
          <select
          name="model"
          value={carData.modelId || ''}
          onChange={(e) => handleSelectChange(e,modelsData,'model')}
          className="filter-inputs">
            <option value="">Model</option>
            {Array.isArray(modelsData) && modelsData.length > 0 && modelsData.map(model =>(
              <option key={model.id} value={model.id}>
                {model.name}
              </option>
            ))}
            
          </select>

        </form>

      </div>

      <div className="filters">
      <FontAwesomeIcon icon={faMoneyBill1} className="minMax-icon" />

      <form className="forms">

      <label className="forms-labels">Minimum Fiyat (TL)</label>
        <input type="number" placeholder="min" className="minMax-input" name="minPrice" value={carData.minPrice || ''} onChange={handleInputChange}></input>
        <label className="forms-labels">Maksimum Fiyat (TL)</label>
        <input type="number" placeholder="max" className="minMax-input" name="maxPrice" value={carData.maxPrice || ''} onChange={handleInputChange}></input>

      </form>

      </div>

      <div className="filters">
      <img src="/Images/manual-transmission.png" alt="transmission" id="transmission-img"></img>
      
      <form className="forms">

      <label  className="forms-labels" >Vites Tipi</label>

        <select 
        name="transmission"
        value={carData.transmissionId || ''}
        onChange={(e) => handleSelectChange(e,transmissionsData,'transmission')}
        className="filter-inputs">
          <option value="">Vites Tipi</option>
          {Array.isArray(transmissionsData) && transmissionsData.length > 0 && transmissionsData.map((transmission) =>(
            <option key={transmission.id} value={transmission.id}>
              {transmission.type}
            </option>
          ))}          
        </select>

      </form>
      </div>

      <div className="filters">
      <FontAwesomeIcon icon={faGasPump} className="icons" />
      <form className="forms">
      <label className="forms-labels" >Benzin Tipi</label>
        <select 
        name="fuel"
        value={carData.fuelId || ''}
        onChange={(e) => handleSelectChange(e,fuelsData,'fuel')}
        className="filter-inputs">
          <option value="">Benzin Tipi</option>
          {Array.isArray(fuelsData) && fuelsData.length > 0 && fuelsData.map((fuel) =>(
            <option key={fuel.id} value={fuel.id}>
              {fuel.type}
            </option>
          ))}
        </select>
      </form>
      </div>

      <div className="filters">
      <FontAwesomeIcon icon={faFile} className="icons" />
      <form className="forms">
        
      <label className="forms-labels">Durum</label>
        <select 
        name="status"
        value={carData.statusId || ''}
        onChange={(e) => handleSelectChange(e,statusData,'status')}
        className="filter-inputs">
          <option value="">Durum</option>
          {Array.isArray(statusData) && statusData.length > 0 && statusData.map((carStatus) => (
            <option key={carStatus.id} value={carStatus.id}>
              {carStatus.status}
            </option>
          ))}
        </select>
      </form>
      </div>
      
      <div className="filters">
      <FontAwesomeIcon icon={faGaugeHigh} className="minMax-icon" />
      <form className="forms">
         
      <label className="forms-labels">Kilometre</label>
        <input type="number" placeholder="min" className="minMax-input" name="minKilometer" value={carData.minKilometer || ''} onChange={handleInputChange} ></input>
        <input type="number" placeholder="max" className="minMax-input" name="maxKilometer" value={carData.maxKilometer || ''} onChange={handleInputChange}></input>

      </form>
      </div>

      <div className="filters">
      <FontAwesomeIcon icon={faCalendarDays} className="icons" />
      <form className="forms">
      <label className="forms-labels">Başlangıç tarihi</label>
        <input type="date" placeholder="minDate" className="minMax-input"></input>

        <label className="forms-labels">Bitiş tarihi</label>
        <input type="date" placeholder="maxDate" className="minMax-input"></input>
      </form>
      </div>

      <div className="filters">
        <button className="filters-button" onClick={handleSubmit}>Ara</button>
        </div>      
    </div>
  </div>
  )
}
export default Filters;