import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Modal, ModalBody } from "reactstrap";
import * as maintenanceStateActions from "../../../redux/actions/maintenanceStateActions";
import * as maintenanceTypeActions from "../../../redux/actions/maintenanceTypeActions";
import * as maintenanceActions from "../../../redux/actions/maintenanceActions";
import { toast } from "react-toastify";

const MaintenancePlanningRecordModal = ({ isOpen, toggle, car }) => {
  const [newPlanningRecord, setNewPlanningRecord] = useState({
    carId: 0,
    brandName: "",
    modelName: "",
    chassisNo: "",
    plate: "",
    state: "",
    type: "",
    estimatedElapsedTime: "",
    estimatedWorkmanshipCost: "",
    estimatedComponentCost: "",
    estimatedTotalCost: "",
    estimatedStartDate: "",
    estimatedEndDate: "",
    description: "",
  });

  const dispatch = useDispatch();
  const [loading, setLoading] = useState(false);

  const maintenanceStateData = useSelector((state) => state.maintenanceState.maintenanceStateItem);
  const maintenanceTypeData = useSelector((state) => state.maintenanceType.maintenanceTypeItem);

  useEffect(() => {
    if (car) {
      setNewPlanningRecord((prev) => ({
        ...prev,
        carId: car?.id || "",
        brandName: car?.brandName || "",
        modelName: car?.modelName || "",
        chassisNo: car?.chassisNo || "",
        plate: car?.plate || "",
      }));
    }

    dispatch(maintenanceStateActions.handleGetMaintenanceStateList());
dispatch(maintenanceTypeActions.handleGetMaintenanceTypeList());

  }, [car, dispatch]);

  const handleSelectChange = (e, dataList, key) =>{
    const value = e.target.value;

    setNewPlanningRecord((prevFormsData) => {
      const updatedFormData = {...prevFormsData}
      if(value === "")
      {
        updatedFormData[`${key}Id`] = "";
        updatedFormData[key] = "";
      }
      
      else
      {
        const selectedItem = dataList.find((item) => String(item.id) === value);
        if(selectedItem)
        {
          updatedFormData[`${key}Id`] = selectedItem.id;
          updatedFormData[key] = selectedItem.name || selectedItem.state || selectedItem.type;
        }
      }

      console.log("Updated Form Data:", updatedFormData); // Güncellenen veriyi kontrol edin
      return updatedFormData;
    })
  }

  const handleInputChange = (e) => {
    const {name, value} = e.target;
    setNewPlanningRecord((prevData) => ({
      ...prevData,
      [name] : value
    }))
  }


  const formatToIsoDate = (date) => {
    if(!date) return null;
    const isoDate = new Date(date).toISOString();
    return isoDate;
  }

  const delay = (ms) => new Promise((resolve) => setTimeout(resolve, ms));

  const handleClick = async () => {
    if (
      !newPlanningRecord.brandName ||
      !newPlanningRecord.modelName ||
      !newPlanningRecord.chassisNo ||
      !newPlanningRecord.plate ||
      !newPlanningRecord.state ||
      !newPlanningRecord.type ||
      !newPlanningRecord.estimatedStartDate ||
      !newPlanningRecord.estimatedEndDate
    ) {
      toast.warn("Girdiğiniz bilgiler eksik veya hatalı!", {
        position: "top-center",
        autoClose: 2000,
      });
      return;
    }

    const newRecord = {
      carId: newPlanningRecord.carId,
      brandName: newPlanningRecord.brandName,
      modelName: newPlanningRecord.modelName,
      state: newPlanningRecord.state,
      type: newPlanningRecord.type,
      chassisNo: newPlanningRecord.chassisNo,
      plate: newPlanningRecord.plate,
      description: newPlanningRecord.description,
      startDate: formatToIsoDate(newPlanningRecord.estimatedStartDate),
      enddate: formatToIsoDate(newPlanningRecord.estimatedEndDate),
      estimatedComponentCost: parseInt(newPlanningRecord.estimatedComponentCost, 10) || 0,
      estimatedWorkmanshipCost: parseInt(newPlanningRecord.estimatedWorkmanshipCost, 10) || 0,
      estimatedCost: parseInt(newPlanningRecord.estimatedTotalCost, 10) || 0,
      estimatedElapsedTime: parseInt(newPlanningRecord.estimatedElapsedTime, 10) || 0,
    };

    setLoading(true);

    try {
      await dispatch(maintenanceActions.createMaintenancePlanningRecord(newRecord));
      await delay(2000);
      toast.success("Kayıt başarıyla oluşturuldu!", {
        position: "top-center",
        autoClose: 2000,
      });
    } catch (error) {
      toast.error("Bir hata oluştu!", {
        position: "top-center",
        autoClose: 2000,
      });
    } finally {
      setLoading(false);
    }
  };

  if (!car) {
    return null;
  }

  return (
    <Modal isOpen={isOpen} toggle={toggle} size="lg" className="maintenance-record-modal">
      <ModalBody>
        <div className="maintenance-record-modal-design">
          <div className="maintenance-record-modal-container">
            <div className="maintenance-record-modal-record-info">
              {/* Form Alanları */}
              <div>
                <span>Marka</span>
                <input type="text" name="brandName" value={car.brandName || ""} readOnly />
              </div>
              <div>
                <span>Model</span>
                <input type="text" name="modelName" value={car.modelName || ""} readOnly />
              </div>
              <div>
                <span>Şasi No</span>
                <input type="text" name="chassisNo" value={car.chassisNo || ""} readOnly />
              </div>
              <div>
                <span>Plaka</span>
                <input type="text" name="plate" value={car.plate || ""} readOnly />
              </div>
              {/* Devamı */}
              <div>
                <span>Bakım Tipi</span>
                <select
                  name="type"
                  value={newPlanningRecord.typeId || ""}
                  onChange={(e) => handleSelectChange(e, maintenanceTypeData, "type")}
                >
                  <option value="">Bakım Tipi</option>
                  {Array.isArray(maintenanceTypeData) && maintenanceTypeData.map((type) => (
                    <option key={type.id} value={type.id}>
                      {type.type}
                    </option>
                  ))}
                </select>
              </div>
              <div>
                <span>Bakım Durumu</span>
                <select
                  name="state"
                  value={newPlanningRecord.stateId || ""}
                  onChange={(e) => handleSelectChange(e, maintenanceStateData, "state")}
                >
                  <option value="">Bakım Durumu</option>
                  {Array.isArray(maintenanceStateData) && maintenanceStateData.map((state) => (
                    <option key={state.id} value={state.id}>
                      {state.state}
                    </option>
                  ))}
                </select>
              </div>

              <div>
                <span>Anlaşılan Zaman</span>
                <input type="number"
                name ="estimatedElapsedTime" value ={ newPlanningRecord.estimatedElapsedTime} onChange={handleInputChange}  />
              </div>

              <div>
                <span>Tahmini İşçilik Tutarı</span>
                <input type="number" 
                name ="estimatedWorkmanshipCost" value ={ newPlanningRecord.estimatedWorkmanshipCost} onChange={handleInputChange}   />
              </div>

              <div>
                <span>Tahmini Parça Tutarı</span>
                <input type="number" 
                name ="estimatedComponentCost" value ={ newPlanningRecord.estimatedComponentCost} onChange={handleInputChange}  />
              </div>

              <div>
                <span>Tahmini Toplam Tutar</span>
                <input type="number" 
                name ="estimatedTotalCost" value ={ newPlanningRecord.estimatedTotalCost}
                onChange={handleInputChange}  />
              </div>

              <div>
                <span>Tahmini Başlangıç Tarihi</span>
                <input
                  type="date"
                  name="estimatedStartDate"
                  value={newPlanningRecord.estimatedStartDate}
                  onChange={handleInputChange}
                />
              </div>
              <div>
                <span>Tahmini Bitiş Tarihi</span>
                <input
                  type="date"
                  name="estimatedEndDate"
                  value={newPlanningRecord.estimatedEndDate}
                  onChange={handleInputChange}
                />
              </div>

              <div>
                <span className="maintenance-record-comment">Açıklama</span>
                <textarea rows={4} cols={50} placeholder="Açıklama Giriniz.."
                name ="description"
                value ={newPlanningRecord.description || ''} onChange={handleInputChange} />
              </div>


            </div>
          </div>
          <div className="maintenance-record-modal-record-info-button-container">
            <button className="maintenance-record-modal-record-info-create-button" onClick={handleClick}>
              {loading ? <div className="spinner"></div> : "Oluştur"}
            </button>
            <button className="maintenance-record-modal-record-info-exit-button" onClick={toggle}>
              İptal
            </button>
          </div>
        </div>
      </ModalBody>
    </Modal>
  );
};

export default MaintenancePlanningRecordModal;
