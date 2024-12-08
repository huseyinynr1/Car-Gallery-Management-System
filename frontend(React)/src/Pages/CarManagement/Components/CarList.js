import React, { Component } from "react";
import "../Styles/carManagement.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCircleInfo } from "@fortawesome/free-solid-svg-icons";

export default class CarList extends Component {
  render() {
    return (
      <div>

        <div className="list-car-block">
          <h3>Araba Listele</h3>
          <form>
            <input type="text" placeholder="Bir sayfa başına kaç adet araba listelenecek?"></input>
            <button type="button" class="btn btn-success">Listele</button>
          </form>
        </div>
        
        <div className="car-list-container">
          <img src="/Images/car-list-example.png" alt="example-img"></img>
          <form className="label-form">
            <label>Renault</label>
            <label>Megane 15.dCI Joy</label>
          </form>

          <div className="car-list-form-button">
            <form>
              <button className="info-button">
                <FontAwesomeIcon icon={faCircleInfo} />
              </button>
              <button type="button" className="btn btn-warning">
                Güncelle
              </button>
              <button type="button" className="btn btn-danger">
                Sil
              </button>
            </form>
          </div>
        </div>
      </div>
    );
  }
}
