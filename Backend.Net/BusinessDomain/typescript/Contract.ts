

 

    export interface Contract { 
        contractNr: string;
        spContractDescription: string;
        creationDate: string;
        offertDate: string;
        offertNr: string;
        transportClasses: TransportClass[];
        railwayBills: RailwayBill[];
        invoices: IncomingInvoicesConfirmations[];
        wagons: Wagon[];
    
}