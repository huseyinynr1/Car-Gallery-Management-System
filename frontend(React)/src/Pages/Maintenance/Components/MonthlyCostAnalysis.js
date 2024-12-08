import { LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend } from "recharts";
import * as maintenanceActions from "../../../redux/actions/maintenanceActions";
import { useDispatch, useSelector } from "react-redux";
import { useEffect } from "react";

const MonthlyCostAnalysis= () => {

  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(maintenanceActions.getMonthlyMaintenanceTotalCost());
  }, [dispatch]);

    const monthlyMaintenanceData = useSelector((state) => state.maintenance.getMonthlyMaintenanceTotalCostData);;
return (
<div className="year-cost-graph-container">
      <h3>Aya Göre Genel Bakım Maliyeti </h3>
      <div className="year-cost-graph">
      <LineChart
        width={820}
        height={300}
        data={monthlyMaintenanceData}
        margin={{ top: 20, right: 30, left: 20, bottom: 5 }}
      >
        <CartesianGrid strokeDasharray="3 3" />
        <XAxis dataKey="month" />
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
export default MonthlyCostAnalysis;