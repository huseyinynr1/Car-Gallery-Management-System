import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend } from "recharts";
import * as maintenanceActions from "../../../redux/actions/maintenanceActions";

const YearlyCostAnalysis= () => {

const dispatch = useDispatch();

  useEffect(() => {
    dispatch(maintenanceActions.getYearlyMaintenanceTotalCost());
  }, [dispatch]);
  
    const yearlyMaintenanceData = useSelector((state) => state.maintenance.getYearlyMaintenanceTotalCostData);
return (
<div className="year-cost-graph-container">
      <h3>Yıllara Göre Genel Bakım Maliyeti </h3>
      <div className="year-cost-graph">
      <LineChart
        width={800}
        height={300}
        data={yearlyMaintenanceData}
        margin={{ top: 20, right: 30, left: 20, bottom: 5 }}
      >
        <CartesianGrid strokeDasharray="3 3" />
        <XAxis dataKey="year" />
        <YAxis />
        <Tooltip />
        <Legend />
        <Line type="monotone" dataKey="totalCost" stroke="#8884d8" name="Toplam Maliyet" />
        <Line type="monotone" dataKey="averageCost" stroke="#82ca9d" name="Ortalama Maliyet" />
      </LineChart>
      </div>
     
    </div>
);
}
export default YearlyCostAnalysis;