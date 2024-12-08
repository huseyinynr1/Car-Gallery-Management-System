import { configureStore } from "@reduxjs/toolkit";
import { persistReducer, persistStore } from "redux-persist";
import storage from "redux-persist/lib/storage"; // LocalStorage için
import reducers from "./index"; // Tüm reducer'larınızın birleştirildiği yer
import {thunk} from "redux-thunk";

// Persist Config
const persistConfig = {
  key: 'root',  // Hangi anahtarla persist edileceğini belirler
  storage,      // Depolama tipi (localStorage)
};

// Persist edilmiş reducer
const persistedReducer = persistReducer(persistConfig, reducers);

export default function createAppStore() {
  const store = configureStore({
    reducer: persistedReducer,  // Persist edilmiş reducer'ı burada kullanıyoruz
    middleware: (getDefaultMiddleware) =>
      getDefaultMiddleware({
        serializableCheck: false, // Persist işlemleri sırasında seri hale getirme kontrolünü devre dışı bırakıyoruz
      }).concat(thunk),
  });

  const persistor = persistStore(store);  // Store'u persist etmek için persistor'u oluşturuyoruz
  return { store, persistor };
}
