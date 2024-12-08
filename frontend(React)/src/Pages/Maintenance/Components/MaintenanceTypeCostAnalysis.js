import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Pie, PieChart, Tooltip, Legend, Cell } from "recharts";
import * as maintenanceActions from "../../../redux/actions/maintenanceActions";


const MaintenanceTypeCostAnalysis = () => {

  const dispatch = useDispatch();
  const nameKeyValue = "Adet";

  useEffect(() => {
    dispatch(maintenanceActions.getCostByType());
  }, [dispatch]);

  const getCostByTypedData = useSelector((state) => state.maintenance.getCostByTypedData || []);
 

  const COLORS = ['#1F77B4', '#FF7F0E', '#2CA02C', '#D62728', '#9467BD', '#8C564B','#E377C2','#7F7F7F','#BCBD22','#17BECF','#FFD700','#2E4053'];


  return (
    <div className="maintenance-type-cost-analysis-container">
      <h3>Bakım Türüne Göre Araç Sayısı ve Maliyeti</h3>
      <div style={{ width: 800 , height: 410 }} className="maintenance-type-cost-analysis-graph">
        
      <PieChart width={800} height={400}>
      <Pie
              data={getCostByTypedData}
              dataKey="count"
              cx="50%"
              cy="50%"
              outerRadius={90}
              fill="#8884d8"
              label
              nameKey={nameKeyValue}
            >
                {getCostByTypedData.map((entry, index) => (
            <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
          ))}
            </Pie>
            <Pie
              data={getCostByTypedData}
              dataKey="cost"
              cx="50%"
              cy="50%"
              innerRadius={130}
              outerRadius={150}
              fill="#82ca9d"
              label
              nameKey="type"
            >
                {getCostByTypedData.map((entry, index) => (
            <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
          ))}
            </Pie>
            <Legend verticalAlign="bottom" height={36} /> {/* Legend eklendi */}
            <Tooltip />
          </PieChart>
      </div>
    </div>
  );
};

export default MaintenanceTypeCostAnalysis;
