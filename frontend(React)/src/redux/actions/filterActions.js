import * as filterActionTypes from './filterActionTypes'

export function getFilterListSuccess(data) {
    return { 
        type: filterActionTypes.GET_FILTER_LIST_SUCCESS, 
        payload: {
            items: data.items,     // Filtrelenmiş araç listesi
            count: data.count,     // Toplam kayıt sayısı
            pages: data.pages      // Toplam sayfa sayısı
        }
    };
}

export function getFilterListFailure(error) {
    return {
        type: filterActionTypes.GET_FILTER_LIST_FAILURE,
        payload: error,
    };
}
export function handleGetFilterList(filterData, currentPage = 1, pageSize = 10) {
    return function(dispatch) {
        const url = `http://localhost:60805/api/Cars/GetFilteredCarList?pageIndex=${currentPage}&pageSize=${pageSize}`;
        return fetch(url, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(filterData)
        })
        .then(response => {
            if (!response.ok) {
                return response.json().then(error => {
                    throw new Error(error);
                });
            }
            return response.json();  // API'den gelen JSON veriyi işle
        })
        .then(result => {
            dispatch(getFilterListSuccess(result));  // Başarılı olursa Redux'a sonucu gönder
        })
        .catch(error => {
            dispatch(getFilterListFailure(error.message));  // Hata olursa hatayı yakala
        });
    };
}

