import React, { useEffect } from "react"; // React kütüphanesini içe aktarıyoruz, bu sayede JSX ve React bileşenlerini kullanabiliriz.
import "../Styles/inventory.css"; // Bileşen için stil tanımlamalarını içeren CSS dosyasını içe aktarıyoruz.
import { useDispatch, useSelector } from "react-redux";
import * as carActions from "../../../redux/actions/carActions";

const MaintenanceTarget = () => {

  const dispatch = useDispatch();
  const getList = useSelector((state) => state.carData.getList);

  useEffect(() => {
    dispatch(carActions.handleGetCarList());
  },[dispatch]);

  const value = Array.isArray(getList) ? getList.filter( car => car.status === "Bakımda").length : 0;
  // Gauge isimli fonksiyon bileşeni oluşturuyoruz ve `value` adında bir prop alıyoruz.
  const radius = 50; // Dairenin yarıçapı 50 birim olarak ayarlanıyor.
  const circumference = 2 * Math.PI * radius; // Dairenin çevresini hesaplıyoruz (2πr formülü).
  const offset = circumference - (value / 10) * circumference; // Dairenin doluluk oranını belirlemek için ofset hesaplıyoruz.

  let color; // Renk değişkenini tanımlıyoruz.
  if (value >= 7) {
    // Eğer `value` 7 veya daha büyükse,
    color = "red"; // Rengi yeşil olarak ayarlıyoruz.
  } else if (value >= 4) {
    // Eğer `value` 4 ile 7 arasında ise,
    color = "orange"; // Rengi turuncu olarak ayarlıyoruz.
  } else {
    // Eğer `value` 4'ten küçükse,
    color = "green"; // Rengi kırmızı olarak ayarlıyoruz.
  }

  return (
    <div className="maintenance-target">,
    <h2>Bakım Hedefi</h2>
      <div className="gauge-container">
        {" "}
        {/* Göstergeyi saran ana div */}
        <svg width="120" height="120" viewBox="0 0 120 120">
          {" "}
          {/* SVG alanını 120x120 olarak ayarlıyoruz */}
          <circle
            className="gauge-bg"
            cx="60"
            cy="60"
            r="50"
            stroke="#e6e6e6"
            strokeWidth="10"
            fill="none"
          />{" "}
          {/* Arka plan için bir daire çiziyoruz */}
          <circle
            className="gauge"
            cx="60"
            cy="60"
            r="50"
            stroke={color}
            strokeWidth="10"
            fill="none"
            strokeDasharray={circumference}
            strokeDashoffset={offset}
          />{" "}
          {/* Doluluk oranını ve rengi belirleyen ön plan dairesi */}
          <text
            x="50%"
            y="50%"
            textAnchor="middle"
            dy=".3em"
            fontSize="30"
            fill={color}
          >
            {value.toFixed(1)}
          </text>{" "}
          {/* Dairenin ortasına `value` değerini yazıyoruz */}
        </svg>
      </div>

      <div className="maintenance-target-info">
        <p>Bakımda Olan Araçlar</p>
        <p>{value}</p>
      </div>

      <div className="maintenance-target-info">
        <p>Hedeflenen Araç Sayısı</p>
        <p>2</p>
      </div>
    </div>
  );
}

export default MaintenanceTarget;
// Bu bileşeni diğer dosyalarda kullanmak için dışa aktarıyoruz.


// Vaule değeri şimdilik göstermelik, ilerde API'den çekilecek!!