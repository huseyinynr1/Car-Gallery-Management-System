import { Modal, ModalBody, ModalFooter } from "reactstrap";
import "../Styles/inventory.css";
import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import * as carActions from "../../../redux/actions/carActions";


const InfoModal = ({ isOpen, toggle, car }) => {
  
  // Seçilen arabanın markasının resim yolları
  const brandLogos = {
    Mercedes: "/Images/mercedes.png",
    Audi: "/Images/audi.png",
    BMW: "/Images/bmw.png",
    Renault: "/Images/renault.png",
    Ford: "/Images/ford.png",
    Volkswagen: "/Images/volkswagen.png",
    Hyundai: "/Images/hyundai.png",
    Honda: "/Images/honda.png",
    Ferrari: "/Images/ferrari.png",
    Dacia: "/Images/dacia.png",
    Alfa: "/Images/alfa.png",
    Skoda: "/Images/skoda.png",
    Jeep: "/Images/jeep.png",
    Fiat: "/Images/fiat.png",
    Opel: "/Images/opel.png",
    Citroen: "/Images/citroen.png",
  };

  const [displayedKilometers, setDisplayedKilometers] = useState(0);
  const [displayedYears, setDisplayedYears] = useState(0);
  
  const selectedCarQuantity = useSelector((state) => state.carData.selectedCarQuantity);
  const selectedCarMaintenanceNumber = useSelector((state) => state.carData.selectedCarMaintenanceNumber);
  const numberOfSoldInSelectedCar = useSelector((state) => state.carData.numberOfSoldInSelectedCar);
  const dispatch = useDispatch();

  useEffect(() => {
  if (car && car.brandName) {
    dispatch(carActions.handleSelectedCarQuantity(car.brandName, car.modelName, car.transmissionType, car.fuelType, car.year));
    dispatch(carActions.handleGetSelectedCarMaintenanceNumber(car.brandName,car.modelName,car.transmissionType,car.fuelType,car.year,car.status));
    dispatch(carActions.handleGetNumberCarOfSoldInSelectedCar(car.brandName,car.modelName,car.transmissionType,car.fuelType,car.year,car.status));
  }
}, [dispatch, car]);

  
  
  const TOTAL_DURATION = 2000; // Km animasyonu için sabit süre

  // Kilometre animasyonu fonksiyonu
  const animatedKilometers = (start, end) => {
    if (end === 0) {
      setDisplayedKilometers(0);
      return;
    } else {
      const distance = end - start; // 0'dan başlayıp varılacak kilometre değeri
      const increment = (distance / TOTAL_DURATION) * 10; // 10ms'de bir artış miktarı
      let currentKilometer = start;
      const timer = setInterval(() => {
        currentKilometer = currentKilometer + increment;
        setDisplayedKilometers((prev) => {
          if (currentKilometer >= end) {
            clearInterval(timer);
            return end;
          }
          return Math.floor(currentKilometer);
        });
      }, 10);
    }
  };

  const animatedYears = (start, end) => {
    const distance = end - start;
    const increment = (distance / TOTAL_DURATION) * 10;
    let currentYears = start;

    const timer = setInterval(() => {
      currentYears += increment;
      setDisplayedYears((prev) => {
        if (currentYears >= end) {
          clearInterval(timer);
          return end;
        }
        return Math.floor(currentYears);
      });
    }, 10);
  };

  // Kilometreyi formatlamak için fonksiyon
  const formatKilometersWithDotBoxes = (kilometers) => {
    const kilometersArray = kilometers.toString().split("").reverse();
    const formattedArray = [];
    kilometersArray.forEach((digit, index) => {
      formattedArray.push(digit);
      if ((index + 1) % 3 === 0 && index + 1 !== kilometersArray.length) {
        formattedArray.push("."); // 3 rakamdan sonra nokta
      }
    });
    return formattedArray.reverse();
  };

  // Kilometreleri render etmek için
  const formattedKilometers = formatKilometersWithDotBoxes(displayedKilometers);

  const renderedKilometers = formattedKilometers.map((char, index) => (
    <div key={index} className={`digit-box ${char === "." ? "dot-box" : ""}`}>
      {char}
    </div>
  ));

  const formattedYearsWithBoxes = (years) => {
    const yearsArray = years.toString().split("").reverse();
    const formatArray = [];
    yearsArray.forEach((digit) => {
      formatArray.push(digit);
    });
    return formatArray.reverse();
  };

  const formattedYears = formattedYearsWithBoxes(displayedYears);
  const renderedYears = formattedYears.map((char, index) => (
    <div key={index} className="digit-box">
      {char}
    </div>
  ));

  useEffect(() => {
    // car nesnesinin null olmadığını kontrol et
    if (car && car.kilometer !== undefined && car.year !== undefined) {
      if (car.kilometer === 0 && car.year === 0) {
        setDisplayedKilometers(0); // Kilometre 0 ise direkt 0 göster
        setDisplayedYears(0); // Yıl 0 ise direkt 0 gönder
      } else {
        animatedKilometers(0, car.kilometer); // Animasyonu başlat
        animatedYears(0, car.year);
      }
    }
  }, [car]);

  // Arabanın durumuna göre hazırlanan tasarımı gösterme

  const MaintenanceDesign = () => (
    <div>
      <div className="wrench-and-hammer">
        <div className="hammer">
          <div className="hammer-head">
            <div class="square-end"></div>
            <div class="spike-end"></div>
          </div>
          <div className="hammer-handle"></div>
        </div>
        <div className="wrench">
          <div className="wrench-head"></div>
          <div className="wrench-handle"></div>
        </div>
      </div>
      <div className="status-text">{car.status}</div>
    </div>
  );

  const TransferDesign = () => (
    <div className="transfer-design">
      <div class="road">
        <div class="truck">
          <div class="truckbehind"></div>
          <div class="truckfront"></div>
        </div>
      </div>
      <div className="text">{car.status}</div>
    </div>
  );

  const SoldDesign = () => (
    <div className="sold-design">
      <img src="/Images/money.png" alt="sold" />
      <span>{car.status}</span>
    </div>
  );

  const GalleryDesign = () => (
    <div className="gallery-design">
      <img src="/Images/gallery-icon.png" alt="inGallery" />
      <span>{car.status}</span>
    </div>
  );

  const ReturnedDesign = () => (
    <div className="returned-design">
      <img src="/Images/return.png" alt="returned" />
      <span>{car.status}</span>
    </div>
  );

  const ReserveDesign = () => (
    <div className="reserve-design">
      <img src="/Images/reserve.png" alt="reserve" />
      <span>{car.status}</span>
    </div>
  );

  const PrepareCarDesign = () => (
    <div className="prepare-car-design">
      <img src="/Images/prepare-car.png" alt="prepare-car" />
      <span>{car.status}</span>
    </div>
  );

  const RemoveSaleDesign = () => (
    <div className="remove-sale-design">
      <img src="/Images/remove-cart.png" alt="remove" />
      <span>{car.status}</span>
    </div>
  );

  const PendingDesign = () => (
    <div className="pending-design">
      <img src="/Images/pending.png" alt="pending" />
      <span>{car.status}</span>
    </div>
  );

  const PurchasedDesign = () => (
    <div className="purchased-design">
      <img src="/Images/purchased.png" alt="purchased" />
      <span>{car.status}</span>
    </div>
  );

  const Unknown = () => (
    <div className="unknown-design">
      <img src="/Images/unknown.png" alt="unknown" />
      <span>Durum Bilinmiyor</span>
    </div>
  );

  const renderedStatusDesign = (status) => {
    switch (status) {
      case "Bakımda":
        return <MaintenanceDesign />;
      case "Transfer Ediliyor":
        return <TransferDesign />;
      case "Satıldı":
        return <SoldDesign />;
      case "Depoda":
        return <GalleryDesign />;
      case "İade Edildi":
        return <ReturnedDesign />;
      case "Rezervede":
        return <ReserveDesign />;
      case "Hazırlanıyor":
        return <PrepareCarDesign />;
      case "Satıştan Kaldırıldı":
        return <RemoveSaleDesign />;
      case "Beklemede":
        return <PendingDesign />;
      case "Satış Bekleniyor":
        return <PendingDesign />;
      case "Satın Alındı":
        return <PurchasedDesign />;
      default:
        return <Unknown />;
    }
  };
  
  if (!car || Object.keys(car).length === 0) {
    return <div>Loading...</div>;
  }
  
  
  // Araba markasına göre , markasının logosunu getirme fonksiyonu
  const logoSrc = brandLogos[car.brandName] || "Images/add-car-block-image.png";
  return (
    <Modal
      isOpen={isOpen}
      toggle={toggle}
      className="custom-info-modal"
      size="xl"
    >
      <ModalBody>
        <div className="custom-info-modal-first-part">
          <div className="custom-info-modal-first-part-1">
            <h1>ARABA DETAYI</h1>
            <div className="info-modal-brand-and-model">
              <div className="info-modal-brand">
                <h4>Marka</h4>
                <img src={logoSrc} alt={car.brandName}></img>
                <p>{car.brandName}</p>
              </div>
              <div className="info-modal-model">
                <h4>Model</h4>
                <img
                  src="/Images/info-car-modal-model-icon.png"
                  alt="model"
                ></img>
                <p>{car.modelName}</p>
              </div>
            </div>
          </div>
          <img src="/Images/InfoCarmodalcar.png" alt="car"></img>
        </div>

        <div className="custom-info-modal-medium-part">
          <div className="custom-info-modal-medium-part-1">
            <div className="custom-car-infos">
              <p>Kilometre</p>
              <div className="custom-car-kilometer">{renderedKilometers}</div>
            </div>

            <div className="production-year">
              <p>Üretim Yılı</p>
              <div className="year">{renderedYears}</div>
            </div>

            <div className="car-status">
              <p>Durum</p>
              <div className="status">{renderedStatusDesign(car.status)}</div>
            </div>
          </div>

          <div className="custom-info-modal-medium-part-2">
            <div className="car-price">
              <p>Fiyat</p>
              <div className="price-design">
              <div className="price-box">
              <span className="currency-sembol">₺</span>
              <span className="price">{car.price}</span>
              </div>
              </div>
            </div>

            <div className="car-stock">
              <p>Stok Adedi</p>
              <div className="stock-design">
              <div className="stock-box">
                <img src="/Images/stock.png" alt="stock"></img>
                <span className="stock-count">{selectedCarQuantity?.stockQuantity || 0}</span>
              </div>  
              </div>
              
            </div>

            <div className="car-maintenance">
              <p>Servisteki Araba Adedi</p>
              <div className="maintenance-design">
                <div className="maintenance-box">
                  <img src="/Images/maintenance.png" alt="maintenance"></img>
                  <span className="maintenance-count">{selectedCarMaintenanceNumber?.number || 0}</span>
                </div>
              </div>
            </div>

          </div>

          <div className="custom-info-modal-medium-part-1">

         <div className="car-sold">
              <p>Satılan Adet</p>
              <div className="sold-car-design">
                <div className="sold-car-box">
                  <img src="/Images/sold-car-icon.png" alt="sold-car"></img>
                  <span className="sold-car-count">{numberOfSoldInSelectedCar?.number || 0}</span>
                </div>
              </div>
            </div>
          </div>
        </div>
      </ModalBody>
      <ModalFooter>
        <button onClick={toggle} className="exit-button">Kapat</button>
      </ModalFooter>
    </Modal>
  );
};

export default InfoModal;
