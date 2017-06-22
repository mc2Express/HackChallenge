

module Models {  

    export interface Contract { 
        contractNr: string;
        creationDate: string;
        offertDate: string;
        offertNr: string;
        transportClasses: TransportClass[];
        railwayBills: RailwayBill[];
        invoices: IncomingInvoicesConfirmations[];
        wagons: Wagon[];
    }
}