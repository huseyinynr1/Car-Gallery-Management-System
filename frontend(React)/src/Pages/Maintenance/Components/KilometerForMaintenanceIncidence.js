
import { Bar, BarChart, CartesianGrid, XAxis, YAxis, Tooltip, Legend, Rectangle } from "recharts";

const  MaintenanceIncidenceForKilometer = () =>{
    const data = [
        {mileAgeRange:"0-20,000 km", maintenanceFrequency:10},
        {mileAgeRange:"20,001-50.000 km", maintenanceFrequency:15},
        {mileAgeRange:"50,001-100,000 km", maintenanceFrequency:20},
        {mileAgeRange:"100,001-150,000 km", maintenanceFrequency:25},
        {mileAgeRange:"150,001-200,000 km", maintenanceFrequency:30},
        {mileAgeRange:"200,001-250,000 km", maintenanceFrequency:35},
        {mileAgeRange:"250,001-300,000 km", maintenanceFrequency:35},
        {mileAgeRange:"300,001-350,000 km", maintenanceFrequency:35},
        {mileAgeRange:"350,001-400,000 km", maintenanceFrequency:35},
        {mileAgeRange:"400,001+ km", maintenanceFrequency:35},


    ];

    return(
        <div className="incidence-for-kilometer-container">
            <h3>Kilometreye Göre Bakım Sıklığı</h3>
            <div className="incidence-for-kilometer-graph">
                <BarChart 
                width={900} 
                height={300} 
                data={data}
                margin={{
                    top :5,
                    right :30,
                    left: 20,
                    bottom: 5
                }}>
                    <CartesianGrid strokeDasharray="3 3" />
                    <XAxis dataKey="mileAgeRange"  name="Kilometre Aralığı"/>
                    <YAxis />
                    <Tooltip />
                    <Legend />
                    <Bar dataKey="maintenanceFrequency" fill="#1F77B4" activeBar = {<Rectangle fill="gold" stroke="purple" />} name="Bakım Sıklığı"></Bar>
                </BarChart>
            </div>
        </div>
    )
}
export default  MaintenanceIncidenceForKilometer;