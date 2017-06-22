

module App { 
    export class TransportClass { 
        public from: TrainStation;
        public via: TrainStation;
        public to: TrainStation;
        public szVertragNr: string;
        public railwayBills: RailwayBill[];
    }
} 