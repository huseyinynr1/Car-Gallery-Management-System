import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { BarChart, Bar, Cell, XAxis, YAxis, CartesianGrid } from 'recharts';
import * as maintenanceActions from "../../../redux/actions/maintenanceActions";


const YearlyMaintenanceIncidence = () => {
    const colors = ['#1F77B4', '#FF7F0E', '#2CA02C', '#D62728', '#9467BD', '#8C564B','#E377C2','#7F7F7F','#BCBD22','#17BECF','#FFD700','#2E4053'];
    const dispatch = useDispatch();

    useEffect(() => {
      dispatch(maintenanceActions.getYearlyMaintenanceIncidenceCount());
    },[dispatch]);

    const data = useSelector((state) => state.maintenance.getYearlyMaintenanceIncidenceData);
    
    const getPath = (x, y, width, height) => {
      return `M${x},${y + height}C${x + width / 3},${y + height} ${x + width / 2},${y + height / 3}
      ${x + width / 2}, ${y}
      C${x + width / 2},${y + height / 3} ${x + (2 * width) / 3},${y + height} ${x + width}, ${y + height}
      Z`;
    };
    
    const TriangleBar = (props) => {
      const { fill, x, y, width, height } = props;
    
      return <path d={getPath(x, y, width, height)} stroke="none" fill={fill} />;
    };
    

      return (
        <div className='monthly-maintenance-incidence-container'> 
            <h3>Yıllık Bakım Sıklığı</h3>
            <div className='monthly-maintenance-incidence-graph'>
              {data && data.length > 0 ? (<BarChart
          width={1000}
          height={300}
          data={data}
          margin={{
            top: 20,
            right: 30,
            left: 20,
            bottom: 5,
          }}
        >
          <CartesianGrid strokeDasharray="3 3" />
          <XAxis dataKey="year" />
          <YAxis />
          <Bar dataKey="yearCount" fill="#8884d8" shape={<TriangleBar />} label={{ position: 'top' }}>
            {data.map((entry, index) => (
              <Cell key={`cell-${index}`} fill={colors[index % 20]} />
            ))}
          </Bar>
        </BarChart>)
        : 
        (<p>Yükleniyor...</p>)}
            
            </div>
        </div>
       
      );
    }


export default YearlyMaintenanceIncidence;