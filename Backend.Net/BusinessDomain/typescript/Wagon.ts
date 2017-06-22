

 

    export interface Wagon { 
        wagonNumber: string;
        info: string;
        totalWeight: string;
        cargo: Cargo;
        reservation: ShuttleReservationListItem;
        reservationTrainNumber: string;
        reservationSendDate: string;
        reservationReceiveDate: string;
        wagonStatus: WagonStatus[];
    
}