import React, { useEffect, useState } from "react";
import {
  Card,
  CardBody,
  ListGroupItem,
  ListGroup,
  CardTitle,
  CardText,
  Pagination,
  PaginationItem,
  PaginationLink,
} from "reactstrap";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCircleInfo } from "@fortawesome/free-solid-svg-icons";
import { useDispatch, useSelector } from "react-redux";
import "../Styles/inventory.css";
import * as filterActions from "../../../redux/actions/filterActions";
import UpdateCarModal from "./UpdateCarModal";
import InfoModal from "./InfoModal";
import "../Styles/inventory.css";

const ListOfCar = () => {
  const [totalPages, setTotalPages] = useState(1);
  const [currentPage, setCurrentPage] = useState(1);      // Sayfa numarası ve toplam sayfa sayısı için state
  const [selectedCar, setSelectedCar] = useState(null);   // Güncellenecek araba
  const [isUpdateCarModalOpen, setIsUpdateCarModalOpen] = useState(false);  // Araba güncelleme Modal kontrolü
  const [isInfoModalOpen, setIsInfoModalOpen] = useState(false);
  const dispatch = useDispatch();
  const pageSize = 10;  // Sayfa başına kaç veri gösterileceğini sabit tuttum
  
  // Redux'tan filtre sonuçlarını alıyoruz
  const filtersData = useSelector((state) => state.filter.filters);
  const { count = 0, pages = 1 } = useSelector((state) => state.filter.paginationInfo);

  // Sayfa numarası değiştiğinde API'ye istek atmak için useEffect kullanıyoruz
  useEffect(() => {
    // Sayfa numarası ve sayfa başına gösterilecek veri sayısını API'ye gönderiyoruz
    dispatch(
      filterActions.handleGetFilterList({
        pageIndex: currentPage - 1,  // Sayfa numarası (0 tabanlı)
        pageSize: pageSize,          // Her sayfada kaç veri göstereceğinize göre
      })
    );
  }, [currentPage, dispatch]);

  useEffect(() => {
    if (pages) {
      setTotalPages(pages);
    }
  }, [pages]); // Başka bir sayfaya geçildiğinde API'den gelen toplam sayfa sayısını güncelle

  if (!filtersData || filtersData.length === 0) {
    return <div>Filtre sonuçları bulunamadı</div>;
  }

  // Sayfa değiştirildiğinde çalışacak fonksiyon
  const handlePageChange = (pageNumber) => {
    setCurrentPage(pageNumber);  // Sayfa numarasını güncelle
  };

  const toggleUpdateCarModal = () => setIsUpdateCarModalOpen(!isUpdateCarModalOpen); // Modal açık
  const toggleInfoModal = () => setIsInfoModalOpen(!isInfoModalOpen);

  const handleUpdateClick = (car) => {
    setSelectedCar(car);  // Güncellenmek istenen araba bilgilerini ayarla
    toggleUpdateCarModal();        // Modal'ı aç
  }

  const handleInfoClick = (car) => {
    setSelectedCar(car);  // Araba bilgilerini gönder
    toggleInfoModal();        // Modal'ı aç 
  }

  //Modal'da arabaya ait veriler (updatedCar) girilip submit edildiğinde aşağıdaki fonksiyonla API'ye istek atılır ve modal kapatılır.
  const handleUpdateSubmit = (updatedCar) => {
    toggleUpdateCarModal();      //Modal'ı kapat
  }

  return (
    <div>
      <div className="list-of-car-layout">
        {filtersData.map((car, index) => (
          <div key={index}>
            <Card className="list-of-car-layout-card" key={car.id}>
              <img alt="Car" src={car.imageUrl} id="card-img" />
              <CardBody>
                <CardTitle tag="h5">{car.brandName} - {car.modelName}</CardTitle>
                <CardText>Fiyat: {car.price} TL</CardText>
                <CardText>Kilometre: {car.kilometer} km</CardText>
              </CardBody>

              <ListGroup flush>
                <ListGroupItem>Vites: {car.transmissionType}</ListGroupItem>
                <ListGroupItem>Yakıt: {car.fuelType}</ListGroupItem>
                <ListGroupItem>Durum: {car.status}</ListGroupItem>
              </ListGroup>

              <CardBody>
                <form className="car-list-form-button">
                  <button 
                  type="button"
                  className="info-button"
                  onClick={() => handleInfoClick(car)}>
                    <FontAwesomeIcon icon={faCircleInfo} />
                  </button>
                  <button 
                  type="button"
                  onClick={() => handleUpdateClick(car)}
                  className="btn btn-warning">
                    Güncelle
                  </button>
                  <button type="button" className="btn btn-danger">
                    Sil
                  </button>
                </form>
              </CardBody>
            </Card>
          </div>
        ))}
      </div>

      <InfoModal
      isOpen={isInfoModalOpen}
      toggle={toggleInfoModal}
      car={selectedCar}/>

      <UpdateCarModal
      isOpen={isUpdateCarModalOpen}
      toggle={toggleUpdateCarModal}
      car={selectedCar}
      onSubmit={handleUpdateSubmit}
      />
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
              <PaginationLink onClick={() => handlePageChange(i + 1)}>{i + 1}</PaginationLink>
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
  );
};
export default ListOfCar;
