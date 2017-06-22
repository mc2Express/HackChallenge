



export interface Contract {
	contractNr: string;
	spContractDescription: string;
	creationDate: string;
	offertDate: string;
	offertNr: string;
	offertTextIntern: string;
	offertOrganisation: string;
	sumWagen: string;
	sumTonnen: string;
	transportClasses: TransportClass[];
	railwayBills: RailwayBill[];
	invoices: IncomingInvoicesConfirmations[];
	wagons: Wagon[];

}