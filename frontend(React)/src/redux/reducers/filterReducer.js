import * as filterActionTypes from '../actions/filterActionTypes';
import initialState from "./initialState";

function filterReducer(state = initialState.filtersData, action) {
    switch (action.type) {
        case filterActionTypes.GET_FILTER_LIST_SUCCESS:
            return {
                ...state,
                filters: action.payload.items, // API'den gelen araç listesi
                paginationInfo: {
                    count: action.payload.count || 0,  // API'den gelen toplam kayıt sayısı veya varsayılan değer
                    pages: action.payload.pages || 1   // API'den gelen toplam sayfa sayısı veya varsayılan değer
                },
                error: null,
            };
        case filterActionTypes.GET_FILTER_LIST_FAILURE:
            return {
                ...state,
                filters: [],
                paginationInfo: { count: 0, pages: 1 }, // Hata durumunda varsayılan değerler
                error: action.payload,
            };
        default:
            return state;
    }
}

export default filterReducer;
