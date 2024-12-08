import React from "react";
import Filters from "./Components/Filters";
import StockManagement from "./Components/StockManagement";
import MaintenanceTarget from "./Components/MaintenanceTarget";
import SalesTarget from "./Components/SalesTarget";
import BrandStockOverview from "./Components/BrandStockOverview";
import ListOfCar from "./Components/ListOfCar";

const Inventory = () => {
  return (
    <div className="inventory-layout">
      <Filters />
      <div className="inventory-layout2">
        <StockManagement />
        <MaintenanceTarget value={2.0} />
        <SalesTarget value={5.0} />
        <BrandStockOverview />
        <ListOfCar />
      </div>
    </div>
  );
};

export default Inventory;
