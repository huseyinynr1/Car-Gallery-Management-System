import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Modal, ModalBody } from "reactstrap";
import * as maintenanceStateActions from "../../../redux/actions/maintenanceStateActions";
import * as maintenanceTypeActions from "../../../redux/actions/maintenanceTypeActions";
import * as maintenanceActions from "../../../redux/actions/maintenanceActions"
import { toast } from "react-toastify";
import { resolve } from "chart.js/helpers";

const UpdateMaintenanceRecordModal = ({ isOpen, toggle, car }) => {

  const [updateFormData, setUpdateFormData] = useState({
    id : "",
    carId : "",
    brandName : "",
    modelName : "",
    state : "",
    type : "",
    chassisNo : "",
    plate : "",
    description : "",
    startDate : "",
    endDate : "",
    componentCost : "",
    workmanshipCost : "",
    dealPrice : "",
    elapsedTime : "",
  });

  const dispatch = useDispatch();
  const [loading, setLoading] = useState(false);

  const maintenanceStateData = useSelector((state) => state.maintenanceState.maintenanceStateItem);
  const maintenanceTypeData = useSelector((state) => state.maintenanceType.maintenanceTypeItem);

  useEffect(() => {
    if(car){
      setUpdateFormData((prevData) => ({
        ...prevData,
        id: car?.id || '',
        carId : car?.carId || '',
        brandName : car?.brandName || '',
        modelName : car?.modelName || '',
        state : car?.state || '',
        type : car?.type || '',
        chassisNo : car?.chassisNo || '',
        plate : car?.plate || '',
        description : car?.description || '',
        startDate : car?.startDate || '',
        endDate : car?.endDate || '',
        componentCost : car?.componentCost || '',
        workmanshipCost : car?.workmanshipCost || '',
        dealPrice : car?.dealPrice || '',
        elapsedTime : car?.dealPrice || '',
      }))
    }
    
    dispatch(maintenanceStateActions.handleGetMaintenanceStateList());
    dispatch(maintenanceTypeActions.handleGetMaintenanceTypeList());
  }, [car, dispatch]);

  const handleInputChange = (e) => {
    const {name, value} = e.target;
    setUpdateFormData((prevData) => ({
      ...prevData,
      [name] : value
    }))
  }

  const handleSelectChange = (e, dataList , key) => {
    const value = e.target.value;
    setUpdateFormData((prevData) => {
     const updateFormData = {...prevData};
      if(value === '')
      {
        updateFormData[`${key}Id`] = '';
        updateFormData[key] = '';
      }

      else
      {
        const selectedItem = dataList.find((item) => String(item.id) === value);
        if(selectedItem)
        {
          updateFormData[`${key}Id`] = selectedItem.id;
          updateFormData[key] = selectedItem.name || selectedItem.state || selectedItem.type;
        }
      }
      return updateFormData;
  })}

  const formatDateForInput = (date) => {
    if (!date) return ""; // Eğer tarih yoksa boş string döner
    return date.split("T")[0]; // "2024-11-21T18:48:24.475" -> "2024-11-21"
  };

  const formatToIsoDate = (date) => {
    if(!date) return null;
    const isoDate = new Date(date).toISOString();
    return isoDate;
  }

  const delay = (ms) => new Promise((resolve) => setTimeout(resolve, ms));

  const handleClick = async() => {
    if(!updateFormData.brandName || !updateFormData.modelName || !updateFormData.chassisNo || !updateFormData.plate || !updateFormData.state ||
      !updateFormData.type || !updateFormData.startDate || !updateFormData.endDate || !updateFormData.elapsedTime 
      || !updateFormData.workmanshipCost || !updateFormData.componentCost || !updateFormData.dealPrice || !updateFormData.description)
    {
      toast.warn("Boş veya hatalı veri girdiniz", {
        position : "top-center",
        autoClose : 2000
      })
    }

    setLoading(true);

    const newUpdateRecord = {
      id: updateFormData.id,
      carId: updateFormData.carId,
      brandName: updateFormData.brandName,
      modelName: updateFormData.modelName,
      state: updateFormData.state,
      type: updateFormData.type,
      chassisNo: updateFormData.chassisNo,
      plate: updateFormData.plate,
      description: updateFormData.description,          
      startDate: formatToIsoDate(updateFormData.startDate),
      endDate: formatToIsoDate(updateFormData.endDate),
      componentCost: parseInt(updateFormData.componentCost, 10),
      workmanshipCost: parseInt(updateFormData.workmanshipCost, 10),
      dealPrice: parseInt(updateFormData.dealPrice,10),
      elapsedTime: parseInt(updateFormData.elapsedTime, 10)   
    }

    try {
      console.log("Apiye gönderilecek veri", newUpdateRecord);
      await dispatch(maintenanceActions.updateMaintenanceRecord(newUpdateRecord));
      await delay(2000);
      toast.success("Kayıt başarılı!", {
        position : "top-center",
        autoClose : 2000
      })
    } catch (error) {
      toast.error("Kayıt Yapılırken Bir Hata Oluştu !", {
        position : "top-center",
        autoClose : 2000
      })
    }
    finally{
      setLoading(false);
    }

  }
  if (!car) {
    return null;
  }
  console.log("Gencellenen veri",updateFormData);

  return (
    <Modal isOpen={isOpen} toggle={toggle} size="lg" className="maintenance-record-modal">
      <ModalBody>
        <div className="maintenance-record-modal-design">
          <div className="maintenance-record-modal-container">
            <div className="maintenance-record-modal-record-info">
              <div>
                <span>Marka</span>
                <input type="text" name="brandName" value={updateFormData.brandName} onChange={handleInputChange} />
              </div>

              <div>
                <span>Model</span>
                <input type="text" name="modelName" value={updateFormData.modelName || ""} onChange={handleInputChange}  />
              </div>

              <div>
                <span>Şasi No</span>
                <input type="text" name="chassisNo" value={updateFormData.chassisNo || ""} onChange={handleInputChange}  />
              </div>

              <div>
                <span>Plaka</span>
                <input type="text" name="plate" value={updateFormData.plate || ""} onChange={handleInputChange}  />
              </div>

              <div>
                <span>Bakım Tipi</span>
                <select name="type" value={updateFormData.typeId} onChange={(e) => handleSelectChange(e, maintenanceTypeData, "type")}>
                  <option value={car.type || ""}  >
                    {car.type || "Bakım Tipi"}
                  </option>
                 {
                  Array.isArray(maintenanceTypeData) &&
                  maintenanceTypeData.map((type) => (
                    <option key={type.id} value={type.id}>
                      {type.type}
                    </option>
                  ))
                 }
                </select>
              </div>

              <div>
                <span>Bakım Durumu</span>
                <select name="state" value={updateFormData.stateId} onChange={(e) => handleSelectChange(e, maintenanceStateData, "state")}>
                  <option value={car.state || ""} >
                    {car.state || "Bakım Durumu"}
                  </option>
                  {
                  Array.isArray(maintenanceStateData) &&
                  maintenanceStateData.map((state) => (
                    <option key={state.id} value={state.id}>
                      {state.state}
                    </option>
                  ))
                 }
                </select>
              </div>

              <div>
                <span>Anlaşılan Zaman</span>
                <input type="number" name="elapsedTime" value={updateFormData.elapsedTime || 0} onChange={handleInputChange} />
              </div>

              <div>
                <span>İşçilik Tutarı</span>
                <input type="number" name="workmanshipCost" value={updateFormData.workmanshipCost || 0} onChange={handleInputChange} />
              </div>

              <div>
                <span>Parça Tutarı</span>
                <input type="number" name="componentCost" value={updateFormData.componentCost || 0} onChange={handleInputChange} />
              </div>

              <div>
                <span>Toplam Tutar</span>
                <input type="number" name="dealPrice" value={updateFormData.dealPrice || 0} onChange={handleInputChange} />
              </div>

              <div>
                <span>Başlangıç Tarihi</span>
                <input type="date" name="startDate" value={formatDateForInput(updateFormData.startDate)} onChange={handleInputChange} />
              </div>

              <div>
                <span>Bitiş Tarihi</span>
                <input type="date" name="endDate" value={formatDateForInput(updateFormData.endDate)} onChange={handleInputChange} />
              </div>

              <div>
                <span className="maintenance-record-comment">Açıklama</span>
                <textarea rows={4} cols={50} name="description" value={updateFormData.description || ""} onChange={handleInputChange} />
              </div>
            </div>
          </div>

          <div className="maintenance-record-modal-record-info-button-container">
            <button className="maintenance-record-modal-record-info-create-button" onClick={handleClick}>{loading ? (<div className="spinner"></div>): ("Oluştur")}</button>
            <button className="maintenance-record-modal-record-info-exit-button" onClick={toggle}>
              İptal
            </button>
          </div>
        </div>
      </ModalBody>
    </Modal>
  );
};

export default UpdateMaintenanceRecordModal;
