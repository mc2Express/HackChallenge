

 

    export interface RailwayBill { 
        forwardingNumber: string;
        forwardingStation: TrainStation;
        takeOverStation: TrainStation;
        receivingStation: TrainStation;
        deliveryStation: TrainStation;
        takeOverDate: string;
        issueDate: string;
        issueLocation: string;
        descriptions: string[];
        classOfReservation: string;
        reservationNumber: string;
        wagon: Wagon;
    
}