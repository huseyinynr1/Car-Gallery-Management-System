import { combineReducers } from "redux";
import loginReducer from "./loginReducer";
import carReducer from "./carReducer";
import brandReducer from "./brandReducer";
import modelReducer from "./modelReducer";
import transmissionReducer from "./transmissionReducer";
import fuelReducer from "./fuelReducer";
import imageReducer from "./imageReducer";
import statusReducer from "./statusReducer";
import filterReducer from "./filterReducer";
import maintenanceStateReducer from "./maintenanceStateReducer";
import maintenanceTypeReducer from "./maintenanceTypeReducer";
import maintenanceReducer from "./maintenanceReducer";


// Uygulama genelinde kullanılan tüm reducer'ları tek bir root reducer altında birleştiriyoruz.
const rootReducer = combineReducers({
  login: loginReducer,                 // Kullanıcı girişi için reducer
  carData: carReducer,                 // Araç verileri için reducer
  brand: brandReducer,                 // Araç markaları için reducer
  model: modelReducer,                 // Araç modelleri için reducer
  transmission: transmissionReducer,   // Şanzıman türleri için reducer
  fuel: fuelReducer,                   // Yakıt türleri için reducer
  image: imageReducer,                 // Görseller için reducer
  status: statusReducer,               // Araç durumları için reducer
  filter: filterReducer,               // Filtreleme işlemleri için reducer
  maintenanceState: maintenanceStateReducer, // Bakım durumları için reducer
  maintenanceType: maintenanceTypeReducer, // Bakım tipleri için reducer
  maintenance : maintenanceReducer        // Bakım işlemleri için reducer
});

export default rootReducer;
