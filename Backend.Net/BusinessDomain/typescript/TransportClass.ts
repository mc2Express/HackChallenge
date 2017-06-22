

module Models {  

    export interface TransportClass { 
        from: TrainStation;
        via: TrainStation;
        to: TrainStation;
        szVertragNr: string;
        railwayBills: RailwayBill[];
    }
}