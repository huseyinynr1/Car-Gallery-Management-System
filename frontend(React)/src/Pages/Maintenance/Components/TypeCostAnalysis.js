import { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { PieChart, Pie, Cell, Tooltip, Legend } from "recharts";
import * as maintenanceActions from "../../../redux/actions/maintenanceActions";


const TypeCostAnalysis = () => {

  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(maintenanceActions.getCostByVehicleType());
  }, [dispatch])

  const vehicleTypeData = useSelector((state) => state.maintenance.getCostByVehicleTypedData || {});

  const COLORS = ['#1F77B4', '#FF7F0E', '#2CA02C', '#D62728', '#9467BD', '#8C564B','#E377C2','#7F7F7F','#BCBD22','#17BECF','#FFD700','#2E4053'];

  return (
    <div className="type-cost-analysis-container">
      <h3>Araç Türüne Göre Maliyeti</h3>
      <div className="type-cost-graph">
      <PieChart width={400} height={400}>
        <Pie
          data={vehicleTypeData}
          dataKey="cost"
          nameKey="type"
          cx="50%"
          cy="50%"
          outerRadius={170}
          fill="#8884d8"
          label
        >
          {vehicleTypeData.length > 0 && vehicleTypeData.map((entry, index) => (
            <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
          ))}
        </Pie>
        <Tooltip />
        <Legend />
      </PieChart>
      </div>
    
    </div>
  );
};

export default TypeCostAnalysis;
