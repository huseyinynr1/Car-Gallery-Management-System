import { useEffect, useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faCopyright,
  faCarRear,
  faMoneyBill1,
  faCalendarDays,
} from "@fortawesome/free-solid-svg-icons";
import { Pagination, PaginationItem, PaginationLink } from "reactstrap";
import { useDispatch, useSelector } from "react-redux";
import * as maintenanceActions from "../../../redux/actions/maintenanceActions";
import * as maintenanceStateActions from "../../../redux/actions/maintenanceStateActions";
import * as maintenanceTypeActions from "../../../redux/actions/maintenanceTypeActions";
import * as brandActions from "../../../redux/actions/brandActions";
import * as modelActions from "../../../redux/actions/modelActions";

const RecordList = () => {
  const dispatch = useDispatch();
  const [filters, setFilters] = useState({
    brandName: "",
    modelName: "",
    state: "",
    type: "",
    minDealPrice: null,
    maxDealPrice: null,
  });
  const [selectedTable, setSelectedTable] = useState("Bakım Geçmişi Tablosu");
  const [selectedDateFilter, setSelectedDateFilter] = useState(null);
  const [totalPages, setTotalPages] = useState(1);
  const [currentPage, setCurrentPage] = useState(1); // Tablolarda hangi sayfada verisini tutmak için

  const pastMaintenanceRecord = useSelector(
    (state) => state.maintenance.pastMaintenanceRecordList
  );
  const activeMaintenanceRecord = useSelector(
    (state) => state.maintenance.activeMaintenanceRecordList
  );
  const pendingMaintenanceRecord = useSelector(
    (state) => state.maintenance.pendingMaintenanceRecordList
  );
  const brandsData = useSelector((state) => state.brand.brands);
  const modelsData = useSelector(filters.brandName 
    ? (state) => state.model.modelByBrand 
    : (state) => state.model.models) || [];
  
  const statesData = useSelector(
    (state) => state.maintenanceState.maintenanceStateItem
  );
  const typesData = useSelector(
    (state) => state.maintenanceType.maintenanceTypeItem
  );

  const pageSize = 10; // Sayfa başına kaç veri gösterileceğini sabit tuttum

  const { count = 0, pages = 1 } = useSelector(
    (state) => state.filter.paginationInfo
  );

  // // Sayfa numarası değiştiğinde API'ye istek atmak için useEffect kullanıyoruz
  // useEffect(() => {
  //   // Sayfa numarası ve sayfa başına gösterilecek veri sayısını API'ye gönderiyoruz
  //   dispatch(
  //     filterActions.handleGetFilterList({
  //       pageIndex: currentPage - 1,  // Sayfa numarası (0 tabanlı)
  //       pageSize: pageSize,          // Her sayfada kaç veri göstereceğinize göre
  //     })
  //   );
  // }, [currentPage, dispatch]);


  const handleTableChange = (event) => {
    setSelectedTable(event.target.value);
  };

  const formatDate = (date) => {
    if (!date) return null;
    return date.split("T")[0];
  };

  const handleInputChange = (e) => {
    const {name , value} = e.target;
    setFilters((prevData) => ({
      ...prevData,
      [name] : value
    }))
  };

  const handleSelectChange = (e, dataList, key) => {
    const value = e.target.value;
    setFilters((prevData) => {
      const updateData = { ...prevData };

      if (value === "") {
        updateData[`${key}Id`] = "";
        updateData[key] = "";
      } else {
        const selectedItem = dataList.find((item) => String(item.id) === value);
        if (selectedItem) {
          updateData[`${key}Id`] = selectedItem.id;
          updateData[key] =
            selectedItem.name || selectedItem.type || selectedItem.state;
        }
      }

      console.log("Seçilen filtreler", updateData);
      return updateData; // HER DURUMDA ÇALIŞACAK ŞEKİLDE DÜZENLENDİ
    });
  };

  const calculateDateRange = (filterValue) => {
    const now = new Date();
    switch (filterValue) {
      case "last7days":
        return {
          startDate: new Date(now.setDate(now.getDate() - 7)),
          endDate: new Date(),
        };
      case "last1month":
        return {
          startDate: new Date(now.setMonth(now.getMonth() - 1)),
          endDate: new Date(),
        };
      case "last3months":
        return {
          startDate: new Date(now.setMonth(now.getMonth() - 3)),
          endDate: new Date(),
        };
      case "last6months":
        return {
          startDate: new Date(now.setMonth(now.getMonth() - 6)),
          endDate: new Date(),
        };
      case "last1year":
        return {
          startDate: new Date(now.setFullYear(now.getFullYear() - 1)),
          endDate: new Date(),
        };
      default:
        return { startDate: null, endDate: null }; // Tüm tarih aralıklarını kapsar
    }
  };


  useEffect(() => {
    if (pages) {
      setTotalPages(pages);
    }

    if(filters.brandName)
      {
        const selectedBrand = filters.brandName;
  
        dispatch(modelActions.getModelByBrandListHandler(selectedBrand));
        return;
      }
      else
      {
        dispatch(modelActions.getModelListHandler());
      }
    const dateRange = calculateDateRange(selectedDateFilter); // Dropdown seçimi

    if (selectedTable === "Bakım Geçmişi Tablosu") {

      const pastMaintenanceRecordData = {
        pageRequest: {
          pageIndex: currentPage-1,
          pageSize: 99,
        },
        brandName: filters.brandName,
        modelName: filters.modelName,
        type: filters.type,
        state: filters.state,
        time: dateRange.startDate ? dateRange.startDate.toISOString() : null,
        minDealPrice: null,
        maxDealPrice: null
      };
      dispatch(maintenanceActions.getPastMaintenanceRecordList(pastMaintenanceRecordData));
    }
    if (selectedTable === "Aktif Bakım Tablosu") {
      const activeMaintenanceRecordData = {
        pageRequest: {
          pageIndex: currentPage-1,
          pageSize: 5,
        },
        brandName: filters.brandName,
        modelName: filters.modelName,
        type: filters.type,
        state: filters.state,
        time: dateRange.startDate ? dateRange.startDate.toISOString() : null,
      };
      dispatch(maintenanceActions.getactiveMaintenanceRecord(activeMaintenanceRecordData));
    }

    if (selectedTable === "Bekleyen Bakım Tablosu") {
      const pendingMaintenanceRecordData = {
        pageRequest: {
          pageIndex: currentPage-1,
          pageSize: 5,
        },
        brandName: filters.brandName,
        modelName: filters.modelName,
        type: filters.type,
        state: filters.state,
        time: dateRange.startDate ? dateRange.startDate.toISOString() : null,
      };
      dispatch(maintenanceActions.getPendingMaintenanceRecord(pendingMaintenanceRecordData));
    }
   

    dispatch(maintenanceStateActions.handleGetMaintenanceStateList());
    dispatch(maintenanceTypeActions.handleGetMaintenanceTypeList());
    dispatch(brandActions.getBrandList());

    
  }, [filters.brandName,selectedTable, pages, dispatch]); // Başka bir sayfaya geçildiğinde API'den gelen toplam sayfa sayısını güncelle

  useEffect(() => {
    if (pastMaintenanceRecord && pastMaintenanceRecord.totalCount) {
      const calculatedPages = Math.ceil(pastMaintenanceRecord.totalCount / pageSize);
      setTotalPages(calculatedPages);
    }
  }, [pastMaintenanceRecord]);

  // Sayfa değiştirildiğinde çalışacak fonksiyon
  const handlePageChange = (pageNumber) => {
    setCurrentPage(pageNumber); // Sayfa numarasını güncelle
  };

  const handleButtonClick = async () => {
    const dateRange = calculateDateRange(selectedDateFilter); // Dropdown seçimi

    if (selectedTable === "Bakım Geçmişi Tablosu") {

      const pastMaintenanceRecordData = {
        pageRequest: {
          pageIndex: currentPage-1,
          pageSize: 5,
        },
        brandName: filters.brandName,
        modelName: filters.modelName,
        type: filters.type,
        state: filters.state,
        time: dateRange.startDate ? dateRange.startDate.toISOString() : null,
        minDealPrice: filters.minDealPrice,
        maxDealPrice: filters.maxDealPrice
      };
      console.log("Apiye gönderilen geçmiş bakım filtreleri", pastMaintenanceRecordData)
      dispatch(maintenanceActions.getPastMaintenanceRecordList(pastMaintenanceRecordData));
      return;
    }
    if (selectedTable === "Aktif Bakım Tablosu") {
      const activeMaintenanceRecordData = {
        pageRequest: {
          pageIndex: currentPage-1,
          pageSize: 5,
        },
        brandName: filters.brandName,
        modelName: filters.modelName,
        type: filters.type,
        state: filters.state,
        time: dateRange.startDate ? dateRange.startDate.toISOString() : null,
      };
      dispatch(maintenanceActions.getactiveMaintenanceRecord(activeMaintenanceRecordData));
      return;
    }

    if (selectedTable === "Bekleyen Bakım Tablosu") {
      const pendingMaintenanceRecordData = {
        pageRequest: {
          pageIndex: currentPage-1,
          pageSize: 5,
        },
        brandName: filters.brandName,
        modelName: filters.modelName,
        type: filters.type,
        state: filters.state,
        time: dateRange.startDate ? dateRange.startDate.toISOString() : null,
      };
      dispatch(maintenanceActions.getPendingMaintenanceRecord(pendingMaintenanceRecordData));
      return;
    }

  };

  console.log("Geçmiş Bakım Kayıtları", pastMaintenanceRecord);
  return (
    <div className="maintenance-filters-area">
      <div className="maintenance-filters">
        <h3>Filtreler</h3>
        <div className="maintenance-filter-item">
          <img src="/Images/listing.png" alt="listing"></img>
          <select onChange={handleTableChange} value={selectedTable}>
            <option value="" disabled selected>
              Tablo Seç
            </option>
            <option>Bakım Geçmişi Tablosu</option>
            <option>Aktif Bakım Tablosu</option>
            <option>Bekleyen Bakım Tablosu</option>
            <option>Fatura Listesi</option>
          </select>
        </div>

        <div className="maintenance-filter-item">
          <FontAwesomeIcon
            icon={faCalendarDays}
            className="maintenance-icons"
          />
          <select
            value={selectedDateFilter}
            onChange={(e) => setSelectedDateFilter(e.target.value)}
          >
            <option value="">Tarih Aralığı Seçin</option>
            <option value="last7days">Son 7 Gün</option>
            <option value="last1month">Son 1 Ay</option>
            <option value="last3months">Son 3 Ay</option>
            <option value="last6months">Son 6 Ay</option>
            <option value="last1year">Son 1 Yıl</option>
          </select>
        </div>

        <div className="maintenance-filter-item">
          <FontAwesomeIcon icon={faCopyright} className="maintenance-icons" />
          <select
            name="brandName"
            value={filters.brandId} // Marka state'i bağlı
            onChange={(e) => handleSelectChange(e, brandsData, "brandName")}
          >
            <option value="">Marka Seçin</option>
            {Array.isArray(brandsData) &&
              brandsData.map((brand) => (
                <option key={brand.id} value={brand.id}>
                  {brand.name}
                </option>
              ))}
          </select>
        </div>

        <div className="maintenance-filter-item">
          <FontAwesomeIcon icon={faCarRear} className="maintenance-icons" />
          <select
            name="modelName"
            value={filters.modelId}
            onChange={(e) => handleSelectChange(e, modelsData, "modelName")}
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

        <div className="maintenance-filter-item">
          <img src="/Images/maintenance-type.png" alt="type"></img>

          <select
            name="type"
            value={filters.typeId}
            onChange={(e) => handleSelectChange(e, typesData, "type")}
          >
            <option value="">Bakım Türü</option>
            {Array.isArray(typesData) &&
              typesData.map((type) => (
                <option key={type.id} value={type.id}>
                  {type.type}
                </option>
              ))}
          </select>
        </div>

        <div className="maintenance-filter-item">
          <img src="/Images/maintenance-status.png" alt="status"></img>
          <select
            name="state"
            value={filters.stateId}
            onChange={(e) => handleSelectChange(e, statesData, "state")}
          >
            <option value="" disabled selected>
              Bakım Durumu
            </option>
            {Array.isArray(statesData) &&
              statesData.map((state) => (
                <option key={state.id} value={state.id}>
                  {state.state}
                </option>
              ))}
          </select>
        </div>

        <div className="maintenance-filter-item">
          <FontAwesomeIcon
            icon={faMoneyBill1}
            className="maintenance-icons-price"
          />
          <div className="maintenance-filter-item-price">
            <input
              type="number"
              min="0"
              step="0.01"
              placeholder="min 0.00"
              name="minDealPrice"
              value={filters.minDealPrice}
              onChange={handleInputChange}
            ></input>
            <input
              type="number"
              min="0"
              step="0.01"
              placeholder="max 0.00"
              name="maxDealPrice"
              value={filters.maxDealPrice}
              onChange={handleInputChange}
            ></input>
          </div>
        </div>

        <div>
          <button className="filters-button" onClick={handleButtonClick}>
            Ara
          </button>
        </div>
      </div>
      <div className="maintenance-filters-list">
        {selectedTable === "Bakım Geçmişi Tablosu" && (
          <div className="maintenance-history">
            <h2>Bakım Geçmişi</h2>
            <table className="maintenance-history-table">
              <thead>
                <tr>
                  <th scope="col">Marka</th>
                  <th scope="col">Model</th>
                  <th scope="col">Bakım Türü</th>
                  <th scope="col">Bakım Durumu</th>
                  <th scope="col">Başlangıç Tarihi</th>
                  <th scope="col">Bitiş Tarihi</th>
                  <th scope="col">Maliyet</th>
                </tr>
              </thead>
              <tbody>
                {pastMaintenanceRecord && pastMaintenanceRecord.length > 0 ? (
                  pastMaintenanceRecord.map((record, index) => (
                    <tr key={index}>
                      <td>{record.brandName}</td>
                      <td>{record.modelName}</td>
                      <td>{record.type}</td>
                      <td>{record.state}</td>
                      <td>{formatDate(record.startDate)}</td>
                      <td>{formatDate(record.endDate)}</td>
                      <td>{record.dealPrice}</td>
                    </tr>
                  ))
                ) : (
                  <tr>
                    <td colSpan="4">Veri bulunamadı</td>
                  </tr>
                )}
              </tbody>
            </table>
          </div>
        )}
        {selectedTable === "Aktif Bakım Tablosu" && (
          <div className="active-maintenance">
            <h2>Aktif Bakım Listesi</h2>
            <table>
              <thead>
                <tr>
                  <th scope="col">Marka</th>
                  <th scope="col">Model</th>
                  <th scope="col">Bakım Türü</th>
                  <th scope="col">Bakım Durumu</th>
                  <th scope="col">Başlangıç Tarihi</th>
                  <th scope="col">Bitiş Tarihi</th>
                </tr>
              </thead>
              <tbody>
                {activeMaintenanceRecord &&
                activeMaintenanceRecord.length > 0 ? (
                  activeMaintenanceRecord.map((record, index) => (
                    <tr key={index}>
                      <td>{record.brandName}</td>
                      <td>{record.modelName}</td>
                      <td>{record.type}</td>
                      <td>{record.state}</td>
                      <td>{formatDate(record.startDate)}</td>
                      <td>{formatDate(record.endDate)}</td>
                    </tr>
                  ))
                ) : (
                  <tr>
                    <td colSpan="4">Veri bulunamadı</td>
                  </tr>
                )}
              </tbody>
            </table>
          </div>
        )}
        {selectedTable === "Bekleyen Bakım Tablosu" && (
          <div className="pending-maintenance">
            <h2>Bekleyen Bakım Tablosu</h2>
            <table>
              <thead>
                <tr>
                  <th scope="col">Marka</th>
                  <th scope="col">Model</th>
                  <th scope="col">Bakım Türü</th>
                  <th scope="col">Bakım Durumu</th>
                  <th scope="col">Başlangıç Tarihi</th>
                  <th scope="col">Bitiş Tarihi</th>
                </tr>
              </thead>
              <tbody>
                {pendingMaintenanceRecord &&
                pendingMaintenanceRecord.length > 0 ? (
                  pendingMaintenanceRecord.map((record, index) => (
                    <tr key={index}>
                      <td>{record.brandName}</td>
                      <td>{record.modelName}</td>
                      <td>{record.type}</td>
                      <td>{record.state}</td>
                      <td>{formatDate(record.startDate)}</td>
                      <td>{formatDate(record.endDate)}</td>
                    </tr>
                  ))
                ) : (
                  <tr>
                    <td colSpan="4">Veri bulunamadı</td>
                  </tr>
                )}
              </tbody>
            </table>
          </div>
        )}
        {selectedTable === "Fatura Listesi" && (
          <div className="bill-list">
            <h2>Fatura Listesi</h2>
            <table>
              <thead>
                <tr>
                  <th scope="col">Fatura No</th>
                  <th scope="col">Fatura Tarihi</th>
                  <th scope="col">Marka</th>
                  <th scope="col">Model</th>
                  <th scope="col">Şasi No</th>
                  <th scope="col">Bakım Türü</th>
                  <th scope="col">Toplam Maliyet</th>
                  <th scope="col"></th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>001</td>
                  <td>20.10.2024</td>
                  <td>Mercedes</td>
                  <td>AMG</td>
                  <td>4a5R5g8EX</td>
                  <td>Periyodik Bakım</td>
                  <td>450 TL</td>
                  <td>
                    <button className="bill-list-button">
                      Detay Görüntüle
                    </button>
                  </td>
                </tr>
                <tr>
                  <td>001</td>
                  <td>20.10.2024</td>
                  <td>Mercedes</td>
                  <td>AMG</td>
                  <td>4a5R5g8EX</td>
                  <td>Periyodik Bakım</td>
                  <td>450 TL</td>
                  <td>
                    <button className="bill-list-button">
                      Detay Görüntüle
                    </button>
                  </td>
                </tr>
                <tr>
                  <td>001</td>
                  <td>20.10.2024</td>
                  <td>Mercedes</td>
                  <td>AMG</td>
                  <td>4a5R5g8EX</td>
                  <td>Periyodik Bakım</td>
                  <td>450 TL</td>
                  <td>
                    <button className="bill-list-button">
                      Detay Görüntüle
                    </button>
                  </td>
                </tr>
                <tr>
                  <td>001</td>
                  <td>20.10.2024</td>
                  <td>Mercedes</td>
                  <td>AMG</td>
                  <td>4a5R5g8EX</td>
                  <td>Periyodik Bakım</td>
                  <td>450 TL</td>
                  <td>
                    <button className="bill-list-button">
                      Detay Görüntüle
                    </button>
                  </td>
                </tr>
                <tr>
                  <td>001</td>
                  <td>20.10.2024</td>
                  <td>Mercedes</td>
                  <td>AMG</td>
                  <td>4a5R5g8EX</td>
                  <td>Periyodik Bakım</td>
                  <td>450 TL</td>
                  <td>
                    <button className="bill-list-button">
                      Detay Görüntüle
                    </button>
                  </td>
                </tr>
              </tbody>
            </table>
          </div>
        )}
        {/* Sayfalama kısmı */}
        <div className="pagination">
  <Pagination>
    <PaginationItem disabled={currentPage === 1}>
      <PaginationLink first onClick={() => handlePageChange(1)} />
    </PaginationItem>
    <PaginationItem disabled={currentPage === 1}>
      <PaginationLink previous onClick={() => handlePageChange(currentPage - 1)} />
    </PaginationItem>
    {[...Array(totalPages)].map((_, i) => (
      <PaginationItem active={currentPage === i + 1} key={i}>
        <PaginationLink onClick={() => handlePageChange(i + 1)}>
          {i + 1}
        </PaginationLink>
      </PaginationItem>
    ))}
    <PaginationItem disabled={currentPage === totalPages}>
      <PaginationLink next onClick={() => handlePageChange(currentPage + 1)} />
    </PaginationItem>
    <PaginationItem disabled={currentPage === totalPages}>
      <PaginationLink last onClick={() => handlePageChange(totalPages)} />
    </PaginationItem>
  </Pagination>
</div>

      </div>
    </div>
  );
};

export default RecordList;
