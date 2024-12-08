  import { useEffect, useState } from "react";
  import { useDispatch, useSelector } from "react-redux";
  import { Modal, ModalBody } from "reactstrap";
  import * as maintenanceStateActions from "../../../redux/actions/maintenanceStateActions";
  import * as maintenanceTypeActions from "../../../redux/actions/maintenanceTypeActions";
  import * as maintenanceActions from "../../../redux/actions/maintenanceActions"
  import { toast } from "react-toastify";

  const NewMaintenanceRecordModal = ({ isOpen, toggle , car }) => {

    const [newRecordFormData, setNewRecordFormData] = useState({
      carId : 0,
      brandName :  '',
      modelName:  '',
      chassisNo : '',
      plate :  '',
      maintenanceState:"",
      maintenanceType:"",
      startDate: "",
      endDate: "",
      elapsedTime : 0,
      workmanshipCost:0,
      componentCost: 0, 
      dealPrice : 0,
      description: ""
    });

    
    const [loading, setLoading] = useState(false);  // Oluştur butonuna tıklayınca yüklenme durumu için


    const dispatch = useDispatch();
    // Bakım durumlarını ilgili reducer'dan alma
    const maintenanceStateData = useSelector((state) => state.maintenanceState.maintenanceStateItem);
    const maintenanceTypeData = useSelector((state) => state.maintenanceType.maintenanceTypeItem);

    useEffect(() => {
      if(car)
      {
        setNewRecordFormData((prev) => ({
          ...prev,
          carId: car?.id || '',
          brandName: car?.brandName || '',
          modelName: car?.modelName || '',
          chassisNo: car?.chassisNo || '',
          plate: car?.plate || ''
        }));
      }
    },[car]);
    // API'den bakım durumu listesini çeken redux metoduna bağlama
    useEffect(() => {

      // Eğer bakım durumu verileri önceden çekilmiş ve mevcutsa birdaha gereksiz yere bağlanıp sürekli sürekli çekme
        dispatch(maintenanceStateActions.handleGetMaintenanceStateList());
      

      // Eğer bakım tipi verileri önceden çekilmiş ve mevcutsa birdaha gereksiz yere bağlanıp sürekli sürekli çekme
        dispatch(maintenanceTypeActions.handleGetMaintenanceTypeList());
      

    },[dispatch]);

    const handleSelectChange = (e, dataList, key) =>{
      const value = e.target.value;

      setNewRecordFormData((prevFormsData) => {
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
      setNewRecordFormData((prevData) => ({
        ...prevData,
        [name] : value
      }))
    }

    const formatToIsoDate = (date) => {
      if(!date) return null;
      const isoDate = new Date(date).toISOString();
      return isoDate;
    }

    const delay = (ms) => new Promise((resolve) => setTimeout(resolve,ms));

    const handleClick = async() => {

      if(!newRecordFormData.brandName || !newRecordFormData.modelName || !newRecordFormData.chassisNo || !newRecordFormData.plate || !newRecordFormData.maintenanceState ||
        !newRecordFormData.maintenanceType || !newRecordFormData.startDate || !newRecordFormData.endDate || !newRecordFormData.elapsedTime 
        || !newRecordFormData.workmanshipCost || !newRecordFormData.componentCost || !newRecordFormData.dealPrice || !newRecordFormData.description)
        {
          toast.warn("Boş veya hatalı veri girdiniz" , {
            position : "top-center",
            autoClose : 3000
          });
          return;
        }

        const newRecord = {
              carId: newRecordFormData.carId,
              brandName: newRecordFormData.brandName,
              modelName: newRecordFormData.modelName,
              state: newRecordFormData.maintenanceState,
              type: newRecordFormData.maintenanceType,
              chassisNo: newRecordFormData.chassisNo,
              plate: newRecordFormData.plate,
              description: newRecordFormData.description,          
              startDate: formatToIsoDate(newRecordFormData.startDate),
              endDate: formatToIsoDate(newRecordFormData.endDate),
              componentCost: parseInt(newRecordFormData.componentCost, 10),
              workmanshipCost: parseInt(newRecordFormData.workmanshipCost, 10),
              dealPrice: parseInt(newRecordFormData.dealPrice,10),
              elapsedTime: parseInt(newRecordFormData.elapsedTime, 10)         
          }
      
        setLoading(true);

        try {
          await dispatch(maintenanceActions.createMaintenanceRecord(newRecord));
          await delay(2000);
          toast.success("Kayıt başarılı!", {
            position : "top-center",
            autoClose : 3000
          });
        } catch (error) {
          toast.error("Kayıt Yapılırken Bir Hata Oluştu !", {
            position : "top-center",
            autoClose: 3000
          });
        }
        finally{
          setLoading(false);
        }
    }
    if (!car) {
    // Eğer bu modal ile işlem yapılmayacaksa, car nesnesini null döndür ki sayfada car nesnelerinden veri gelmediğine dair hata almayasın.
    return null;
    }

    return (
      <Modal isOpen={isOpen} toggle={toggle} size="lg" className="maintenance-record-modal">
        <ModalBody>
          <div className="maintenance-record-modal-design"> 
          <h2></h2>
          <div className="maintenance-record-modal-container">
              
            <div className="maintenance-record-modal-record-info">
              <div>
                <span>Marka</span>
                <input 
                type="text" 
                value={car.brandName || ''} 
                readOnly />
              </div>

              <div>
                <span>Model</span>
                <input type="text" value={car.modelName || ''} readOnly />
              </div>

              <div>
                <span>Şasi No</span>
                <input type="text" value={car.chassisNo}readOnly />
              </div>

              <div>
                <span>Plaka</span>
                <input type="text" value={car.plate} readOnly />
              </div>

              <div>
                <span>Bakım Tipi</span>
                <select
                name="maintenanceType"
                value={newRecordFormData.maintenanceTypeId || ''}
                onChange={(e) => handleSelectChange(e, maintenanceTypeData, "maintenanceType")}
                >
                  <option value="">
                    Bakım Tipi
                  </option>
                  {Array.isArray(maintenanceTypeData) && 
                  maintenanceTypeData.map((maintenanceType) => (
                    <option key={maintenanceType.id} value={maintenanceType.id}>
                      {maintenanceType.type}
                    </option>
                  ))}
                </select>
              </div>

              <div>
                  <span>Bakım Durumu</span>
                  <select
                  name="maintenanceState"
                  value={newRecordFormData.maintenanceStateId || ''}
                  onChange={(e) => handleSelectChange(e, maintenanceStateData, "maintenanceState")}
                  >
                    <option value="" >Bakım Durumu</option>
                    {
                    Array.isArray(maintenanceStateData) &&
                    maintenanceStateData.map((maintenanceState) => (
                      <option key={maintenanceState.id} value={maintenanceState.id}>
                        {maintenanceState.state}
                      </option>
                    ))}
                  </select>
                </div>

              <div>
                  <span>Başlangıç Tarihi</span>
                  <input type="date" name="startDate" value={newRecordFormData.startDate} onChange={handleInputChange}/>
                </div>

                <div>
                  <span>Bitiş Tarihi</span>
                  <input type="date" name = "endDate" value={newRecordFormData.endDate} onChange={handleInputChange}/>
                </div>

              <div>
                <span>Anlaşılan Zaman</span>
                <input type="number" name="elapsedTime" value={newRecordFormData.elapsedTime} onChange={handleInputChange} />
              </div>

              <div>
                  <span>İşçilik Tutarı</span>
                  <input type="number" name="workmanshipCost" value={newRecordFormData.workmanshipCost} onChange={handleInputChange} />
                </div>

                <div>
                  <span>Parça Tutarı</span>
                  <input type="number" name="componentCost" value={newRecordFormData.componentCost} onChange={handleInputChange} />
                </div>

              <div>
                <span>Anlaşılan Miktar</span>
                <input type="number" name="dealPrice" value={newRecordFormData.dealPrice} onChange={handleInputChange} />
              </div>
              
              <div>
                <span class="maintenance-record-comment">Açıklama</span>
                <textarea
                  rows="4"
                  cols="50"
                  placeholder="Açıklama Giriniz.."
                  name="description"
                  value={newRecordFormData.description}
                  onChange={handleInputChange}
                ></textarea>
              </div>

            </div>
            <img src="/Images/maintenance-schedule.png" alt="record"></img>

          </div>

          <div className="maintenance-record-modal-record-info-button-container">
          <button className="maintenance-record-modal-record-info-create-button" onClick={handleClick}>
            {
              loading ? (
                <div className="spinner"></div>
              ): (
                "Oluştur"
              )}
              </button>
          <button className="maintenance-record-modal-record-info-exit-button" onClick={toggle}>İptal</button>
          </div>
  
          </div>
          
        </ModalBody>
      </Modal>
    );
  };

  export default NewMaintenanceRecordModal;
