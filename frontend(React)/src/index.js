  import React from 'react';
  import ReactDOM from 'react-dom/client';
  import App from './App';
  import reportWebVitals from './reportWebVitals';
  import 'bootstrap/dist/css/bootstrap.min.css';
  import 'bootstrap-icons/font/bootstrap-icons.css';
  import 'react-responsive-carousel/lib/styles/carousel.min.css' //Eğer stil dosyası bütün projede kullanılacaksa buraya , yalnızca bir component için kullanılacaksa oraya import edilir
  import configureStore from './redux/reducers/configureStore'
  import { Provider } from 'react-redux';
import { PersistGate } from 'redux-persist/integration/react';

  const {store,persistor} = configureStore();

  const root = ReactDOM.createRoot(document.getElementById('root'));
  root.render(
    <React.StrictMode>
      <Provider store={store}>
        <PersistGate loading={null} persistor={persistor}>
        <App />
        </PersistGate>
      </Provider>
    </React.StrictMode>
  );

  // If you want to start measuring performance in your app, pass a function
  // to log results (for example: reportWebVitals(console.log))
  // or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
  reportWebVitals();
  //Ana javascript konfigürasyon dosyası
  //const root = ReactDOM.createRoot(document.getElementById('root')); root index.html'de geçer, Componentlerde ve ana componentlerimizde yaptıklarımızı gider index.html'de günceller.