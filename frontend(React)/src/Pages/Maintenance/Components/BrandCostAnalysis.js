

import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { BarChart, Bar, XAxis, YAxis, CartesianGrid, Tooltip } from "recharts";
import * as maintenanceActions from "../../../redux/actions/maintenanceActions";

const BrandCostAnalysis = () => {
  // Şimdiki yıl ve ay için başlangıç değerlerini ayarla
  const [dateData, setDateData] = useState({
    year: new Date().getFullYear(), // Şimdiki yıl
    month: new Date().getMonth() + 1, // Şimdiki ay (0-11 olduğu için +1 eklenir)
  });

  const dispatch = useDispatch();

  // Tarih değişikliklerini handle eden fonksiyon
  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setDateData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  // Grafik verilerini Redux'tan al
  const getCostByBrandData = useSelector((state) => state.maintenance.getCostByBrandData || []);
  console.log("Redux'tan gelen veriler:", getCostByBrandData);


  // İlk yüklemede ve tarih değiştiğinde verileri çek
  useEffect(() => {
    dispatch(maintenanceActions.getCostByBrand(dateData.year, dateData.month));
  }, [dispatch, dateData]);

  // Grafik boyutunu dinamik olarak ayarla
  const chartWidth = getCostByBrandData.length > 0 ? getCostByBrandData.length * 100 : 500;

  return (
    <div className="brand-cost-graphic-container">
      <h3>Markaya Göre Bakım Maliyeti</h3>
      <div>
        <form>
          <input
            type="number"
            placeholder="Yıl Giriniz"
            name="year"
            value={dateData.year}
            onChange={handleInputChange}
          />
          <input
            type="number"
            placeholder="Ay Giriniz"
            name="month"
            value={dateData.month}
            onChange={handleInputChange}
          />
        </form>
      </div>
      <div className="brand-cost-graphic">
        {getCostByBrandData.length > 0 ? (
          <BarChart
            width={chartWidth}
            height={300}
            data={getCostByBrandData}
            margin={{ top: 20, right: 30, left: 20, bottom: 5 }}
          >
            <CartesianGrid strokeDasharray="3 3" />
            <XAxis dataKey="brandName" />
            <YAxis />
            <Tooltip />
            <Bar dataKey="yearCost" fill="#8884d8" name="Yıllık Maliyet" />
            <Bar dataKey="monthCost" fill="#82ca9d" name="Aylık Maliyet" />
          </BarChart>
        ) : (
          <p>Veriler yükleniyor veya mevcut değil...</p>
        )}
      </div>
    </div>
  );
};

export default BrandCostAnalysis;
