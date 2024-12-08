const initialState = {
  loginData: {
    user: null,
    loading: false,
    error: null,
    isRedirecting: false,
  },

  carData: {
    data: null,
    error: null,
    totalCount: 0,
    selectedCarQuantity: 0,
    selectedCarMaintenanceNumber: 0,
    numberOfSoldInSelectedCar:0,
    totalCarInStorage: 0,
    reserveCarCount:0,
    updateCar: null,
    getList:{},
    maintenanceCarData:null
  },

  brandData: {
    brands: [],
    error: null,
    carsCountByBrandName:{},
  },

  modelData: {
    models: [],
    modelByBrand: [],
    error: null,
  },

  transmissionData: {
    transmissions: [],
    error: null,
  },

  fuelData: {
    fuels: [],
    error: null,
  },

  formData: {
    image: [],
    error: null,
  },

  statusData : {
    status:[],
    error: null,
  },

  filtersData: {
    filters:[],
    paginationInfo :{
      count : 0,
      pages : 1,
    },
    error: null,
  },

  maintenanceData : {
    maintenanceRecords: [],
    maintenancePlanningRecords: [],
    pastMaintenanceRecordList: [],
    activeMaintenanceRecordList: [],
    pendingMaintenanceRecordList: [],
    getMonthlyMaintenanceIncidenceData: [],
    getYearlyMaintenanceIncidenceData: [],
    getMonthlyMaintenanceTotalCostData: [],
    getYearlyMaintenanceTotalCostData: [],
    getCostByBrandData : [],
    getCostByTypedData: [],
    getCostByVehicleTypedData: [],
    selectedUpdateCar: null,
    error : null
  },

  maintenanceStateData : {
    maintenanceStateItem:[],
    error :null
  },

  maintenanceTypeData : {
    maintenanceTypeItem: [],
    error : null
  }
};

export default initialState;
