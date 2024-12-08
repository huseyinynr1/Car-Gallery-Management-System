import { useEffect, useState } from "react";
import "../styles/maintenance.css";
import NewMaintenanceRecordModal from "./NewMaintenanceRecordModal";
import UpdateMaintenanceRecordModal from "./UpdateMaintenanceRecordModal";
import MaintenancePlanningRecordModal from "./MaintenancePlanningRecordModal";
import { useDispatch, useSelector } from "react-redux";
import * as carActions from "../../../redux/actions/carActions";
import * as brandActions from "../../../redux/actions/brandActions";
import * as modelActions from "../../../redux/actions/modelActions";
import * as maintenanceActions from "../../../redux/actions/maintenanceActions";
import { toast } from "react-toastify";

const Record = () => {
  const dispatch = useDispatch();
  const [formsData, setFormsData] = useState({
    newRecordForm:{brand: "",model: "",chassisNo: ""},
    updateRecordForm:{id: "", chassisNo: ""},
    planningNewRecordForm:{brand: "",model: "",chassisNo: ""}

  });

  

  //Apiden dönen bilgileri tutacak state
  const [carDetails, setCarDetails] = useState(null);

  const [newRecordButtonAnimate, setNewRecordButtonAnimate] = useState(false);
  const [showNewRecordForms, setShowNewRecordForms] = useState(false);
  const [updateRecordButtonAnimate, setUpdateRecordButtonAnimate] = useState(false);
  const [showUpdateRecordForms, setShowUpdateRecordForms] = useState(false);
  const [planButtonAnimate, setPlaRecordButtonAnimate] = useState(false);
  const [showPlanRecordForms, setShowPlanRecordForms] = useState(false);

  // Modal Pencerelerinin açık kapalı durumunu tutmak için gerekli state'ler
  const [isNewMaintenanceRecordModalOpen, setIsNewMaintenanceRecordModalOpen] = useState(false);
  const [isUpdateMaintenanceRecordModalOpen,setIsUpdateMaintenanceRecordModalOpen] = useState(false);
  const [isMaintenancePlanningRecordModalOpen,setIsMaintenancePlanningRecordModalOpen] = useState(false);


  const brandsData = useSelector((state) => state.brand.brands); // Veritabanındaki markaları alıyoruz.
  const modelsData = useSelector((state) => state.model.models); // Veritabanındaki modelleri alıyoruz.
  const selectedCar = useSelector((state) => state.carData.maintenanceCarData);
  const selectedUpdateCar = useSelector((state) => state.maintenance.selectedUpdateCar);
  console.log("selectedUpdateCar0", selectedUpdateCar);


  // API'den gelen hata mesajını reducer'dan alma

  const error = useSelector((state) => state.carData.error);

  // API'den marka ve model listelerini çeken redux metoduna bağlama
  useEffect(() => {
    dispatch(brandActions.getBrandList());
    dispatch(modelActions.getModelListHandler());
  }, [dispatch]);



  const handleClickNewRecord = () => {
    if (!newRecordButtonAnimate) {
      setNewRecordButtonAnimate(true);

      setTimeout(() => {
        setShowNewRecordForms(true);
      }, 1050);
    }

    if (newRecordButtonAnimate === false) {
      setNewRecordButtonAnimate(true);
    } else if (newRecordButtonAnimate === true) {
      setNewRecordButtonAnimate(false);
      setShowNewRecordForms(false);
    }
  };

  const handleClickUpdateRecord = () => {
    if (!updateRecordButtonAnimate) {
      setUpdateRecordButtonAnimate(true);
      setTimeout(() => {
        setShowUpdateRecordForms(true);
      }, 1050);
    }

    if (updateRecordButtonAnimate === false) {
      setUpdateRecordButtonAnimate(true);
    } else if (updateRecordButtonAnimate === true) {
      setUpdateRecordButtonAnimate(false);
      setShowUpdateRecordForms(false);
    }
  };

  // Bakım Planlaması butonuna basınca animasyonun başlaması
  const handleClickPlan = () => {
    if (!planButtonAnimate) {
      setPlaRecordButtonAnimate(true);
      setTimeout(() => {
        setShowPlanRecordForms(true);
      }, 1050);
    }

    if (planButtonAnimate === false) {
      setPlaRecordButtonAnimate(true);
    } else if (planButtonAnimate === true) {
      setPlaRecordButtonAnimate(false);
      setShowPlanRecordForms(false);
    }
  };




  // Kullanıcının girdiği şasi numarasını yakala ve al

  const handleChassisInputChange = (e,formName) => {
    const { name, value } = e.target;
    setFormsData((prevData) => ({
      ...prevData,
      [formName] : {
        ...prevData[formName],
        [name]: value
      }
      
    }));
  };



  // Select item'dan seçili veriyi state'e kaydetme işlevi
  const handleSelectChange = (e, datalist, key, formName) => {
    const value = e.target.value;

    setFormsData((prevFormsData) => {
      const updatedFormData = {...prevFormsData[formName]}

      // Eğer dropdown item'dan boş değer geldiyse , değeri boş olarak güncelle
      if(value === '')
      {
        updatedFormData[`${key}Id`] = "";
        updatedFormData[key] = "";
      }

      // Eğer dropdown item'dan bir değer geldiyse, apiden gelen veri listesindeki verinin aynısı olup olmadığını sorgula, 
      //eğer aynısı ise id ve name alanını seçilen verinin id ve name'i ile güncelle
      
      else
      {
        const selectedItem = datalist.find((item) => String(item.id) === value) // value değeri string , item.id int değer olduğu için item.id'yi string'e çeviriyoruz. Seçili veriyi bu sayede buluyor.
        if(selectedItem)
        {
          updatedFormData[`${key}Id`] = selectedItem.id
          updatedFormData[key] = selectedItem.name

        }
      }

      console.log("Updated Form Data:", updatedFormData); // Güncellenen veriyi kontrol edin

      return{
        ...prevFormsData,
        [formName] : updatedFormData
      };
    })
  }



  
  // Yeni Bakım Kaydı için Modal Açılışı

  const toggleNewMaintenanceRecordModal = () =>
    setIsNewMaintenanceRecordModalOpen(!isNewMaintenanceRecordModalOpen);
  // Yeni Bakım Kaydı için Modal Açılışı ve API Çağrısı
  const handleNewMaintenanceRecordClick = async () => {
    try {
      const { brand, model, chassisNo } = formsData.newRecordForm;
      if (!brand || !model || !chassisNo) {
        alert("Lütfen tüm bilgileri girin");
        return;
      }
  
      // API'ye istek atma
      await dispatch(carActions.handleGetCarByChassisNo(brand, model, chassisNo));
    
      if (selectedCar) {
        setCarDetails(selectedCar);
        toggleNewMaintenanceRecordModal();
      } else {
        alert("Araba bulunamadı");
      }
    } catch (error) {
      // Sadece hata mesajını kullanıcıya gösterin
      alert(error.message || "Beklenmeyen bir hata oluştu");
    }
  };
  




  // Bakım Kaydı Güncellemek İçin Modal Açılışı
  const toggleUpdateMaintenanceRecordModal = () =>
    setIsUpdateMaintenanceRecordModalOpen(!isUpdateMaintenanceRecordModalOpen);
  const handleUpdateMaintenanceRecordClick = async() => {
    const {id, chassisNo}=formsData.updateRecordForm;

    try {

      if(!id  || !chassisNo)
        {
          toast.warn("Lütfen tüm bilgileri girin",{
            position: "top-center",
            autoClose: 2000
          });
          return;
        }
       await dispatch(maintenanceActions.getCarByRecordIdAndChassisNo(id, chassisNo));
       console.log("selectedUpdateCar", selectedUpdateCar);
        if(selectedUpdateCar)
        {
          setCarDetails(selectedUpdateCar);
          console.log("selectedUpdateCar2", selectedUpdateCar);

          toggleUpdateMaintenanceRecordModal();
          return;
        }
    
        else
        {
          toast.error("Araba Bulunamadı",{
            position: "top-center",
            autoClose: 2000
          });
        }
    } catch (error) {
    }
    
  
  };


  const toggleMaintenancePlanningRecordModal = () =>
    setIsMaintenancePlanningRecordModalOpen(
      !isMaintenancePlanningRecordModalOpen
    );

  const handleClickPlanningRecord = async() => {
    const {brand, model, chassisNo}=formsData.planningNewRecordForm;

    try {

      if(!brand || !model || !chassisNo)
        {
          toast.warn("Lütfen tüm bilgileri girin",{
            position: "top-center",
            autoClose: 2000
          });
          return;
        }
    
       await dispatch(carActions.handleGetCarByChassisNo(brand, model, chassisNo));
        if(selectedCar)
        {
          setCarDetails(selectedCar);
          toggleMaintenancePlanningRecordModal();
        }
    
        else
        {
          toast.error("Araba Bulunamadı",{
            position: "top-center",
            autoClose: 2000
          });
        }
    } catch (error) {
    }
    
  
  };

console.log("Apiye gönderielcek veri", formsData.updateRecordForm);

  return (
    <div className="main-div">
      <div className="first-part">
        <img
          src="/Images/maintenance-schedule.png"
          alt="maintenance"
          className="header-image"
        />
        <div className="maintenance-events">
          <h1>Araç Bakım Yönetimi</h1>
          <div className="maintenance-log">
            <div className="new-record-form-container">


              {/* Yeni Bakım Kaydı Alanı */ }
              {showNewRecordForms && (
                <div className="forms-container">
                  <div>
                    <select
                      name="brand"
                      value={formsData.newRecordForm.brandId}
                      onChange={(e) =>
                        handleSelectChange(e, brandsData, "brand", "newRecordForm")
                      }
                      className="record-form-select-item"
                    >
                      <option value="">Marka</option>
                      {Array.isArray(brandsData) &&
                        brandsData.map((brand) => (
                          <option key={brand.id} value={brand.id}>
                            {brand.name}
                          </option>
                        ))}
                    </select>
                  </div>

                  <div>
                    <select
                      name="model"
                      value={formsData.newRecordForm.modelId} // Eğer boşsa default olarak boş string
                      onChange={(e) =>
                        handleSelectChange(e, modelsData, "model", "newRecordForm")
                      }
                      className="record-form-select-item"
                    >
                      <option value="">Model</option>
                      {Array.isArray(modelsData) &&
                        modelsData.map((model) => (
                          <option key={model.id} value={model.id}>
                            {model.name}
                          </option>
                        ))}
                    </select>
                  </div>

                  <div>
                    <input
                      name="chassisNo"
                      type="text"
                      placeholder="Şasi No"
                      className="record-form-input"
                      value={formsData.newRecordForm.chassisNo || ''}
                      onChange={(e) => handleChassisInputChange(e,"newRecordForm")}
                    ></input>
                  </div>

                  <div>
                    <button
                      className="record-form-button"
                      onClick={() => handleNewMaintenanceRecordClick()}
                    >
                      Oluştur
                    </button>
                  </div>
                </div>
              )}
              <NewMaintenanceRecordModal
                isOpen={isNewMaintenanceRecordModalOpen}
                toggle={toggleNewMaintenanceRecordModal}
                car = {carDetails}
              />
              <button
                className={`maintenance-log-button ${
                  newRecordButtonAnimate ? "buttonAnimate" : ""
                }`}
                onClick={handleClickNewRecord}
              >
                Yeni Bakım Kaydı
              </button>
            </div>


            {/* Bakım Kaydı Güncelleme Alanı */ }

            <div className="update-record-container">
              {showUpdateRecordForms && (
                <div className="forms-container">
                  <div>
                    <input
                      name="id"
                      type="text"
                      placeholder="Bakım Kayıt No"
                      className="record-form-input"
                      value={formsData.updateRecordForm.id || ''}
                      onChange={(e) => handleChassisInputChange(e, "updateRecordForm")}
                    ></input>
                  </div>

                  <div>
                    <input
                      name="chassisNo"
                      type="text"
                      placeholder="Şasi No"
                      className="record-form-input"
                      value={formsData.updateRecordForm.chassisNo || ''}
                      onChange={(e) => handleChassisInputChange(e, "updateRecordForm")}
                    ></input>
                  </div>
                  <div>
                    <button
                      className="record-form-button"
                      onClick={() => handleUpdateMaintenanceRecordClick()}
                    >
                      Oluştur
                    </button>
                  </div>
                </div>
              )}

              <UpdateMaintenanceRecordModal
                isOpen={isUpdateMaintenanceRecordModalOpen}
                toggle={toggleUpdateMaintenanceRecordModal}
                car = {carDetails}
              />

              <button
                className={`maintenance-log-button ${
                  updateRecordButtonAnimate ? "buttonAnimate" : ""
                }`}
                onClick={handleClickUpdateRecord}
              >
                Bakım Kaydı Güncelle
              </button>
            </div>


            {/*  Bakım Planlaması Alanı */ }

            <div className="planning-record-container">
              {showPlanRecordForms && (
                <div className="forms-container">
                  <div>
                    <select
                    className="record-form-select-item"
                    name="brand"
                     value={formsData.planningNewRecordForm.brandId || ''}
                     onChange={(e) => handleSelectChange(e, brandsData, "brand", "planningNewRecordForm")}
                     >
                      <option value="" disabled selected>Marka</option>
                      {Array.isArray(brandsData) &&
                        brandsData.map((brand) => (
                          <option key={brand.id} value={brand.id}>
                            {brand.name}
                          </option>
                        ))}
                    </select>
                  </div>

                  <div>
                    <select className="record-form-select-item"
                    name="model"
                    value={formsData.planningNewRecordForm.modelId || ''}
                    onChange={(e) => handleSelectChange(e, modelsData, "model", "planningNewRecordForm")}>
                      <option value="" disabled selected>Model</option>
                      {Array.isArray(modelsData)
                      && modelsData.map((model) => (
                        <option key={model.id} value={model.id}>
                          {model.name}
                        </option>
                      ))}
                    </select>
                  </div>

                  <div>
                    <input
                      name="chassisNo"
                      type="text"
                      placeholder="Şasi No"
                      className="record-form-input"
                      value={formsData.planningNewRecordForm.chassisNo || ''}
                      onChange={(e) =>handleChassisInputChange(e,"planningNewRecordForm")}
                    ></input>
                  </div>
                  <div>
                    <button
                      className="record-form-button"
                      onClick={handleClickPlanningRecord}
                    >
                      Oluştur
                    </button>
                  </div>
                </div>
              )}

              <MaintenancePlanningRecordModal
                isOpen={isMaintenancePlanningRecordModalOpen}
                toggle={toggleMaintenancePlanningRecordModal}
                car = {carDetails}
              />

              <button
                className={`maintenance-log-button ${
                  planButtonAnimate ? "buttonAnimate" : ""
                }`}
                onClick={handleClickPlan}
              >
                Bakım Planlaması
              </button>
            </div>
            {/* {error && <div style={{ color: 'red', marginTop: '10px' }}>{error}</div>} */}

          </div>
        </div>
      </div>
    </div>
  );
};

export default Record;
