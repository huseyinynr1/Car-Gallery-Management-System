import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  Modal,
  Form,
  FormGroup,
  Input,
  ModalBody,
  ModalFooter,
  ModalHeader,
} from "reactstrap";
import * as carActions from "../../../redux/actions/carActions";
import "../Styles/inventory.css";

const UpdateCarModal = ({ isOpen, toggle, car, onSubmit }) => {
  const [updatedCar, setUpdatedCar] = useState({});
  const [brandId, setBrandId] = useState("");
  const [modelId, setModelId] = useState("");
  const [transmissionId, setTransmissionId] = useState("");
  const [fuelId, setFuelId] = useState("");
  const [statusId, setStatusId] = useState("");

  const dispatch = useDispatch();

  const brandsData = useSelector((state) => state.brand.brands);
  const modelsData = useSelector((state) => state.model.models);
  const transmissionsData = useSelector(
    (state) => state.transmission.transmissions
  );
  const fuelsData = useSelector((state) => state.fuel.fuels);
  const statusData = useSelector((state) => state.status.status);
  console.log(car);

  // Gelen BrandName'den BrandId bulmak için bir fonksiyon
  const findBrandIdByName = (brandName) => {
    const brand = brandsData.find((b) => b.name === brandName);
    return brand ? brand.id : "";
  };

  const findModelIdByName = (modelName) => {
    const model = modelsData.find((m) => m.name === modelName);
    return model ? model.id : "";
  };

  const findTransmissionIdByType = (transmissionType) => {
    const transmission = transmissionsData.find(
      (t) => t.type === transmissionType
    );
    return transmission ? transmission.id : "";
  };

  const findFuelIdByType = (fuelType) => {
    const fuel = fuelsData.find((f) => f.type === fuelType);
    return fuel ? fuel.id : "";
  };

  const findStatusIdByStatus = (status) => {
    const statusDataItem = statusData.find((s) => s.status === status);
    return statusDataItem ? statusDataItem.id : "";
  };

  useEffect(() => {
    if (car) {
      setUpdatedCar(car);

      // Gelen BrandName, ModelName, FuelType vb. verileri kullanarak ID'leri buluyoruz
      setBrandId(findBrandIdByName(car?.brandName));
      setModelId(findModelIdByName(car?.modelName));
      setTransmissionId(findTransmissionIdByType(car?.transmissionType));
      setFuelId(findFuelIdByType(car?.fuelType));
      setStatusId(findStatusIdByStatus(car?.status));
    }
  }, [car, brandsData, modelsData, transmissionsData, fuelsData, statusData]);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setUpdatedCar({
      ...updatedCar,
      [name]: value,
    });
  };

  const handleSubmit = () => {
    const updatedCarData = {
      ...updatedCar,
      brandId: brandId || car?.brandId, // Yukarıda bulduğumuz ID'leri kullanıyoruz
      modelId: modelId || car?.modelId,
      transmissionId: transmissionId || car?.transmissionId,
      fuelId: fuelId || car?.fuelId,
      statusId: statusId || car?.statusId,
    };

    console.log("Updated car data:", updatedCarData);
    dispatch(carActions.handleUpdateCar(updatedCarData));
    onSubmit(updatedCarData);
  };

  return (
    <Modal isOpen={isOpen} toggle={toggle} className="custom-modal" size="lg">
      <ModalBody>
        <ModalHeader className="modal-header">Güncelleme İşlemleri</ModalHeader>
        <Form className="custom-form">
          <Form className="custom-form-1">
           
            <div className="custom-form-2">
            <label>Marka</label>
            <label>Model</label>
            <label>Fiyat</label>
            </div>

            <div className="custom-form-3">
              <FormGroup>
                <Input
                  type="select"
                  name="brandId"
                  value={brandId || car?.brandId} // state'teki brandId'yi gösteriyoruz
                  onChange={(e) => setBrandId(e.target.value)}
                >
                  {car && (
                    <option value={car?.brandId}>{car?.brandName}</option>
                  )}
                  {brandsData.map((brand) => (
                    <option key={brand.id} value={brand.id}>
                      {brand.name}
                    </option>
                  ))}
                </Input>
              </FormGroup>

              <FormGroup>
                <Input
                  type="select"
                  name="modelId"
                  value={modelId || car?.modelId}
                  onChange={(e) => setModelId(e.target.value)}
                >
                  {car && (
                    <option value={car?.modelId}>{car?.modelName}</option>
                  )}
                  {modelsData.map((model) => (
                    <option key={model.id} value={model.id}>
                      {model.name}
                    </option>
                  ))}
                </Input>
              </FormGroup>

              <FormGroup>
                <Input
                  type="text"
                  name="price"
                  value={updatedCar.price || car?.price || ""}
                  onChange={handleInputChange}
                />
              </FormGroup>
            </div>

            <div className="custom-form-4">

              <div className="custom-form-5">
              <label>Plaka</label>
              <label>Durumu</label>
              </div>

              <div className="custom-form-6">
              <img src="/Images/car-modal.png" alt="car"></img>

              <FormGroup>
                <Input
                  type="text"
                  name="plate"
                  value={updatedCar.plate || car?.plate || ""}
                  onChange={handleInputChange}
                />
              </FormGroup>

              <FormGroup>
                <Input
                  type="select"
                  name="statusId"
                  value={statusId || car?.statusId}
                  onChange={(e) => setStatusId(e.target.value)}
                >
                  {car && <option value={car?.statusId}>{car?.status}</option>}
                  {statusData.map((status) => (
                    <option key={status.id} value={status.id}>
                      {status.status}
                    </option>
                  ))}
                </Input>
              </FormGroup>
              </div>
              
            </div>
          </Form>

          <Form className="custom-form-7">
            <FormGroup>
            <div className="label-circle-container">
              <p className="circle"></p>
              <label className="label-with-circle">Vites Tipi</label>
              </div>
              <Input
                type="select"
                name="transmissionId"
                value={transmissionId || car?.transmissionId}
                onChange={(e) => setTransmissionId(e.target.value)}
              >
                {car && (
                  <option value={car?.transmissionId}>
                    {car?.transmissionType}
                  </option>
                )}
                {transmissionsData.map((transmission) => (
                  <option key={transmission.id} value={transmission.id}>
                    {transmission.type}
                  </option>
                ))}
              </Input>
            </FormGroup>

            <FormGroup>
              <div className="label-circle-container">
              <p className="circle"></p>
              <label className="label-with-circle">Yakıt Tipi</label>
              </div>
           
              <Input
                type="select"
                name="fuelId"
                value={fuelId || car?.fuelId}
                onChange={(e) => setFuelId(e.target.value)}
              >
                {car && <option value={car?.fuelId}>{car?.fuelType}</option>}
                {fuelsData.map((fuel) => (
                  <option key={fuel.id} value={fuel.id}>
                    {fuel.type}
                  </option>
                ))}
              </Input>
            </FormGroup>

            <FormGroup>
            <div className="label-circle-container">
              <p className="circle"></p>
              <label className="label-with-circle">Üretim Yılı</label>
              </div>
              
              <Input
                type="number"
                name="year"
                value={updatedCar.year || car?.year || ""}
                onChange={handleInputChange}
              />
            </FormGroup>

            <FormGroup>
            <div className="label-circle-container">
              <p className="circle"></p>
              <label className="label-with-circle">Kilometre</label>
              </div>
              
              <Input
                type="number"
                name="kilometer"
                value={updatedCar.kilometer || car?.kilometer || ""}
                onChange={handleInputChange}
              />
            </FormGroup>
          </Form>
        </Form>
      </ModalBody>
      <ModalFooter>
        <button className="update-button" onClick={handleSubmit}>
          Güncelle
        </button>
        <button className="cancel-button" onClick={toggle}>
          İptal
        </button>
      </ModalFooter>
    </Modal>
  );
};

export default UpdateCarModal;
