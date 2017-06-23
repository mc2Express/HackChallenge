



import TransportClass = require("./TransportClass");
import ITransportClass = TransportClass.TransportClass;
import RailwayBill = require("./RailwayBill");
import IRailwayBill = RailwayBill.RailwayBill;
import IncomingInvoicesConfirmations = require("./IncomingInvoicesConfirmations");
import IIncomingInvoicesConfirmations = IncomingInvoicesConfirmations.IncomingInvoicesConfirmations;
import Wagon = require("./Wagon");
import IWagon = Wagon.Wagon;

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
	transportClasses: ITransportClass[];
	railwayBills: IRailwayBill[];
	invoices: IIncomingInvoicesConfirmations[];
	wagons: IWagon[];

}