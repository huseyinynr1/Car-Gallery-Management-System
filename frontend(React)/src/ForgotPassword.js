import React, { Component } from 'react'
import "./ForgotPassword.css";

export default class ForgotPassword extends Component {
  render() {
    return (
      <div className='box-1'>
        <div className='panel'>
            <form className='frm-1'>
                <label id='lbl-1'>Şifrenizi mi unuttunuz?</label>
                <label id='lbl-2'>Mail Adresi</label>
                <input type='txt' className='inpt-1'></input>
                <label>Bu e-posta adresi hesabınız ile eşleşmesi durumunda onay kodu göndereceğiz.</label>
                <button className='btnn-1'>İleri</button>
                <button className='btnn-1'>Geri</button>
            </form>
        </div>
      </div>
    )
  }
}

