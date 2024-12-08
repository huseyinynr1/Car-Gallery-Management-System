import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import * as carActions from "../../../redux/actions/carActions";
import "../Styles/inventory.css";

const StockManagement = () => {
  const dispatch = useDispatch();
  const totalCount = useSelector((state) => state.carData.totalCount);
  const getListCar = useSelector((state) => state.carData.getList);
  const totalCarInStorage = useSelector((state) => state.carData.totalCarInStorage);
  const totalSaleReserveCarCount = useSelector((state) => state.carData.reserveCarCount)

  useEffect(() => {
    dispatch(carActions.handleGetTotalCarCount());
    dispatch(carActions.handleGetCarList());
    dispatch(carActions.handleGetTotalCarInStorage());
    dispatch(carActions.handleGetSaleReserveCount());
  }, [dispatch]);


  const totalMaintenanceCarCount = Array.isArray(getListCar)
  ? getListCar.filter(car => car.status === "Bakımda").length
  : 0;

  return (
    <div>
      <div className='area-one'>
        <table className='stock-table'>
          <thead>
            <tr>
              <th scope='col'>Total</th>
              <th scope='col'></th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <th scope='row'>Toplam Araç Sayısı</th>
              <td >{totalCount}</td> 
            </tr>
            <tr>
              <th scope='row'>Satılmaya Hazır</th>
              <td>{totalCarInStorage?.count || 0 }</td>
            </tr>
            <tr>
              <th scope='row'>Bakımda</th>
              <td>{totalMaintenanceCarCount}</td>
            </tr>
            <tr>
              <th scope='row'>Satış Rezervde</th>
              <td>{totalSaleReserveCarCount?.count || 0}</td>
            </tr>
          </tbody>
        </table>
        <img src='/Images/area-one.png' alt='area-one'></img>
      </div>
    </div>
  );
};

export default StockManagement;
