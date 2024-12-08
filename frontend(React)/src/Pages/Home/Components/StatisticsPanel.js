import React, { useEffect, useRef } from "react";
import Chart from "chart.js/auto";
import { Carousel } from "react-responsive-carousel";
import "react-responsive-carousel/lib/styles/carousel.min.css";

const StatisticsPanel = () => {
  const chartRefs = useRef([]); // Grafik referanslarını tutacak dizi
  const charts = useRef([]); // Oluşturulan grafikleri saklayacak dizi

  useEffect(() => {
    // Grafikleri oluşturma
    createChart(0, 'bar'); // İlk grafiği oluştur
    createChart(1, 'pie'); // İkinci grafiği oluştur
    createChart(2, 'line'); // Üçüncü grafiği oluştur

    // Bileşen unmount olduğunda grafiklerin yok edilmesi
    const currentCharts = charts.current; // charts.current'i bir değişkene kopyala
    return () => {
      currentCharts.forEach((chart) => chart && chart.destroy());
    };
  }, []);

  const createChart = (index, type) => {
    const ctx = chartRefs.current[index]?.getContext('2d');

    if (charts.current[index]) {
      charts.current[index].destroy(); // Eğer grafik varsa, eskiyi yok et
    }

    let data, labels;
    if (index === 0) {
      data = [50, 60, 70, 40, 30, 80, 20, 90, 10, 100, 50, 110];
      labels = ['Ocak', 'Şubat', 'Mart', 'Nisan', 'Mayıs', 'Haziran', 'Temmuz', 'Ağustos', 'Eylül', 'Ekim', 'Kasım', 'Aralık'];
    } else if (index === 1) {
      data = [12, 19, 3, 5];
      labels = ['BMW', 'Audi', 'Mercedes', 'Toyota'];
    } else if (index === 2) {
      data = [5, 10, 4, 7];
      labels = ['1. Hafta', '2. Hafta', '3. Hafta', '4. Hafta'];
    }

    charts.current[index] = new Chart(ctx, {
      type: type,
      data: {
        labels: labels,
        datasets: [{
          label: type === 'bar' ? 'Satış Miktarı' : 'Veri',
          data: data,
          backgroundColor: type === 'pie' ?
            ['rgba(255, 99, 132, 0.6)', 'rgba(54, 162, 235, 0.6)', 'rgba(255, 206, 86, 0.6)', 'rgba(75, 192, 192, 0.6)'] :
            'rgba(75, 192, 192, 0.6)',
          borderColor: type === 'pie' ?
            ['rgba(255, 99, 132, 1)', 'rgba(54, 162, 235, 1)', 'rgba(255, 206, 86, 1)', 'rgba(75, 192, 192, 1)'] :
            'rgba(75, 192, 192, 1)',
          borderWidth: 1
        }]
      },
      options: {
        scales: type !== 'pie' ? {
          y: {
            beginAtZero: true
          }
        } : {}
      }
    });
  };

  return (
    <div className="statistics-panel">
      <Carousel
        autoPlay // Otomatik oynatma
        infiniteLoop // Sonsuz Döngüde Çalışma
        interval={5000} // Her 5 saniyede bir grafiğin değişmesi
        showThumbs={false} // Karoselin altındaki küçük resimleri gizler
        showIndicators={false} // Karoselin altındaki nokta göstergelerini gizler
      >
        <div>
          <h3>Satış Verileri</h3>
          <canvas ref={(ref) => (chartRefs.current[0] = ref)}></canvas>
        </div>

        <div>
          <h3>Envanter Durumu</h3>
          <canvas ref={(ref) => (chartRefs.current[1] = ref)}></canvas>
        </div>

        <div>
          <h3>Son Servis Aktiviteleri</h3>
          <canvas ref={(ref) => (chartRefs.current[2] = ref)}></canvas>
        </div>
      </Carousel>
    </div>
  );
};

export default StatisticsPanel;
