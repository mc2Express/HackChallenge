

module App { 
    export class RailwayBill { 
        public forwardingNumber: string;
        public forwardingStation: TrainStation;
        public takeOverStation: TrainStation;
        public receivingStation: TrainStation;
        public deliveryStation: TrainStation;
        public takeOverDate: string;
        public issueDate: string;
        public issueLocation: string;
        public descriptions: string[];
        public classOfReservation: string;
        public reservationNumber: string;
        public wagon: Wagon;
    }
} 