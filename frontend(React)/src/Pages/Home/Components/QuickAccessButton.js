const QuickAccessButton = () => {
  return (
    <div className="button-block">
      <div>
        <button className="add-car"></button>
        <h3>Araba Ekle</h3>
      </div>

      <div>
        <button className="add-invoice"></button>
        <h3>Satış Kaydı</h3>
      </div>

      <div>
        <button className="add-maintenance"></button>
        <h3>Bakım Randevusu</h3>
      </div>

      <div>
        <button className="list-stock"></button>
        <h3>Stok Durumu</h3>
      </div>
    </div>
  );
}

export default QuickAccessButton;
