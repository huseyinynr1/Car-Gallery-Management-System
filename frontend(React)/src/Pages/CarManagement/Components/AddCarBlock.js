import { useDispatch, useSelector } from "react-redux";
import "../Styles/carManagement.css";
import * as brandActions from "../../../redux/actions/brandActions";
import { useEffect, useState } from "react";
import * as carActions from "../../../redux/actions/carActions";
import * as modelActions from "../../../redux/actions/modelActions";
import * as transmissionActions from "../../../redux/actions/transmissionActions";
import * as fuelActions from "../../../redux/actions/fuelActions";
import * as imageActions from "../../../redux/actions/imageActions";

const AddCarBlock = () => {
  const dispatch = useDispatch();
  const [carData, setCarData] = useState({
    brand: "",
    model: "",
    year: "",
    price: "",
    plate: "",
    kilometer: "",
    transmission: "",
    fuel: "",
  });

  const [carId, setCarId] = useState(null);
  const [carImage, setCarImage] = useState(null); // Tek resim için
  const brandsData = useSelector((state) => state.brand.brands);
  const modelsData = useSelector((state) => state.model.models);
  const transmissionsData = useSelector(
    (state) => state.transmission.transmissions
  );
  const fuelsData = useSelector((state) => state.fuel.fuels);

  useEffect(() => {
    dispatch(brandActions.getBrandList());
  }, [dispatch]);

  useEffect(() => {
    dispatch(modelActions.getModelListHandler());
  }, [dispatch]);

  useEffect(() => {
    dispatch(transmissionActions.getTransmissionTypesHandler());
  }, [dispatch]);

  useEffect(() => {
    dispatch(fuelActions.getFuelTypesHandler());
  }, [dispatch]);

  useEffect(() => {
    console.log("Car ID:", carId);
  }, [carId]);

  // Dosya seçme işlemi için
  const handleFileChange = (e) => {
    setCarImage(e.target.files[0]); // Seçilen dosya
  };

  const handleInputChange = (e) => {
    setCarData({
      ...carData,
      [e.target.name]: e.target.value,
    });
  };

  const handleSelectChange = (e, dataList, key) => {
    const selectedItem = dataList.find(item => item.id === e.target.value);
    if (selectedItem) {
      setCarData(prevData => ({
        ...prevData,
        [`${key}Id`]: selectedItem.id,  // Seçilen öğenin ID'si
      }));
    }
  };
  // Formu gönderme işlemi
  const handleSubmit = (e) => {
    e.preventDefault();

    const carDataWithId = {
      brandId: carData.brandId, // Marka adı
      modelId: carData.modelId, // Model adı
      fuelId: carData.fuelId, // Yakıt tipi
      transmissionId: carData.transmissionId, // Vites tipi
      year: carData.year, // Üretim yılı
      price: carData.price, // Fiyat
      plate: carData.plate, // Plaka
      kilometer: carData.kilometer, // Kilometre
      // ImageUrl burada otomatik olarak resim yüklenince eklenir
    };

    dispatch(carActions.handleAddCar(carDataWithId))
  .then((carResponse) => {
    console.log("Car Response:", carResponse); // API'den dönen yanıtı kontrol edin
    setCarId(carResponse.Id); // Eklenen arabanın ID'sini ayarla
  })
  .catch((error) => {
    console.error("Araba Yükleme Hatası", error);
  });

  };

  const handleSubmitImage = (e) => {
    e.preventDefault();
    const formData = new FormData();
    formData.append("CarId", carId);
    if (carImage) {
      formData.append("ImageFile", carImage);
    }
    dispatch(imageActions.uploadImages(formData))
      .then((imageResponse) => {
        console.log("Resim Başarıyla Yüklendi", imageResponse);
      })
      .catch((error) => {
        console.error("Resim Yükleme Hatası", error);
      });
  };

  return (
    <div>
      <h2 className="add-car-header">Araba Ekle</h2>

      <div className="add-car-container">
        <div>
          <img src="/Images/add-car-block-image.png" alt="add-car-block"></img>
        </div>

        <form onSubmit={handleSubmit}>
          <label>Marka</label>
          <select
            name="brand"
            value={carData.brandId || ""} // brandId'yi saklıyoruz
           onChange={(e) => handleSelectChange(e,brandsData,'brand') }
            required
          >
            <option value="">Marka Seçin</option>
            {Array.isArray(brandsData) &&
              brandsData.length > 0 &&
              brandsData.map((brand) => (
                <option key={brand.id} value={brand.id}>
                  {brand.name}
                </option>
              ))}
          </select>

          <label>Model</label>
          <select
            type="text"
            name="model"
            value={carData.modelId || ''}
            onChange={(e) => handleSelectChange(e,modelsData,'model')}
            required
          >
            <option value="">Model Seçin</option>
            {Array.isArray(modelsData) &&
              modelsData.length > 0 &&
              modelsData.map((model) => (
                <option key={model.id} value={model.id}>
                  {model.name}
                </option>
              ))}
          </select>

          <label>Üretim Yılı</label>
          <input
            type="text"
            name="year"
            value={carData.year}
            onChange={handleInputChange}
            required
          ></input>

          <label>Fiyat</label>
          <input
            type="text"
            name="price"
            value={carData.price}
            onChange={handleInputChange}
            required
          ></input>

          <label>Plaka</label>
          <input
            type="text"
            name="plate"
            value={carData.plate}
            onChange={handleInputChange}
            required
          ></input>

          <label>Kilometre</label>
          <input
            type="text"
            name="kilometer"
            value={carData.kilometer}
            onChange={handleInputChange}
            required
          ></input>

          <label>Vites Tipi</label>
          <select
            name="transmission"
            value={carData.transmissionId || ''}
            onChange={(e) => handleSelectChange(e,transmissionsData,'transmission')}
            required
          >
            <option value="">Vites Tipi Seçin</option>
            {Array.isArray(transmissionsData) &&
              transmissionsData.length > 0 &&
              transmissionsData.map((transmission) => (
                <option key={transmission.id} value={transmission.id}>
                  {transmission.type}
                </option>
              ))}
          </select>

          <label>Yakıt Tipi</label>
          <select
            type="text"
            name="fuel"
            value={carData.fuelId || ''}
            onChange={(e) => handleSelectChange(e,fuelsData,'fuel')}
            required
          >
            <option value="">Yakıt Tipi Seçin</option>
            {Array.isArray(fuelsData) &&
              fuelsData.length > 0 &&
              fuelsData.map((fuel) => (
                <option key={fuel.id} value={fuel.id}>
                  {fuel.type}
                </option>
              ))}
          </select>

          <button className="add-button" type="submit">
            Ekle
          </button>

          {carId && (
            <div>
              <form onSubmit={handleSubmitImage}>
                <label>Araba Resmi Yükle</label>
                <input
                  type="file"
                  accept="image/*"
                  name="carImage"
                  onChange={handleFileChange}
                  required
                ></input>
                <button className="upload-button" type="submit">
                  Resmi Yükle
                </button>
              </form>
            </div>
          )}
        </form>
      </div>
    </div>
  );
};

export default AddCarBlock;
