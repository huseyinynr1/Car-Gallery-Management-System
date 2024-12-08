import RecordList from "./Components/RecordList";
import Record from "./Components/Records";
import BrandCostAnalysis from "./Components/BrandCostAnalysis";
import YearlyCostAnalysis from "./Components/YearlyCostAnalysis";
import "./styles/maintenance.css";
import TypeCostAnalysis from "./Components/TypeCostAnalysis";
import MaintenanceTypeCostAnalysis from "./Components/MaintenanceTypeCostAnalysis";
import MonthlyCostAnalysis from "./Components/MonthlyCostAnalysis";
import MonhtlyMaintenanceIncidence from "./Components/MonhtlyMaintenanceIncidence";
import YearlyMaintenanceIncidence from "./Components/YearlyMaintenanceIncidence";
import MaintenanceIncidenceForKilometer from "./Components/KilometerForMaintenanceIncidence";

const Maintenance = () => {
  return (
    <div>
      <Record />
      <RecordList />
      <div className="analysis-containers">
        <MonhtlyMaintenanceIncidence />
        <YearlyMaintenanceIncidence />
      </div>

      <div className="analysis-containers-time">
        <MonthlyCostAnalysis />
        <YearlyCostAnalysis />
      </div>

      <div className="analysis-containers">
        <MaintenanceTypeCostAnalysis />
        <TypeCostAnalysis />
      </div>

      <div className="analysis-containers">
      <BrandCostAnalysis />
      <MaintenanceIncidenceForKilometer />
      </div>

    </div>
  );
};

export default Maintenance;
