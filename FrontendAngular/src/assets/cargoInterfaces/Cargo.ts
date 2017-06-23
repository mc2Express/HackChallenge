export interface Cargo {
    id: string;
    description: string;
    weight: string;

}

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

export interface Country {
    countryCode: string;
    name: string;
}

export interface IncomingInvoicesConfirmations {
    invoiceNb: string;
    invoiceDate: string;
    to: string;
    chargedService: string;
    wagonNb: string;
    executionDate: string;
    attacedDocuments: string;
}





export interface PurchaseContract {
    purchaseContractNb: string;
    dateOfPurchase: string;
    conceringRoute: string;
    axle: string;
    cargo: string;
    offeredService: string;
    additionalInfos: string;
    fee: string;
    entity: string;

}





export interface RailwayBill {
    gvId: string;
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





export interface RelationInfo {
    lookupStatus: LookupStatus[];
    werteGereiht: Werteliste[];
    werteFreigegeben: Werteliste[];
    werterKzub: Werteliste[];
    werteUbehVzweNr: Werteliste[];

}
export interface LookupStatus {
    id: string;
    status: string;
}

export interface Werteliste {
    wert: string;
    description: string;

}





export interface ShuttleReservation {
    trainNumber: string;
    sendDate: string;
    receiveDate: string;
    zulaufNachTarvisio: string;
    items: ShuttleReservationListItem[];

}





export interface ShuttleReservationListItem {
    number: number;
    waggonNumber: string;
    nhm: string;
    gut: string;
    versandBhf: string;
    empfaenger: string;
    info: string;
    ax: string;
    brutto: string;
    lüP: string;
    versanddatum: string;
    v_VW: string;
    bahnhofNumber: string;
    e_VW: string;
    e_BahnhofNumber: string;
    versandNumber: string;
    waggonnummer: string;
    tarifnummer: string;
    partner: string;
    netto_Gewicht: string;
    aSumme_NTO: string;
    zug_Abfahrt: string;
    wgLeerRetour: string;
    aufenthaldStunden: string;

}





export interface SupplyChain {
    contract: Contract[];

}





export interface TrainStation {
    stationId: string;
    country: Country;
    name: string;

}









export interface WagonStatus {
    zugNumber: string;
    date: string;
    lageBahnhofVerwaltung: string;
    lageBahnhofNumber: string;
    lageZeitpunkt: string;
    status: string;
    prz: string;
    wagennr: string;
    gV_ID: string;
    unterwegsbehandlungscode: string;
    storno: string;
    empfänger: string;
    lastModified: string;
    s: string;

}
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
    invoice: IncomingInvoicesConfirmations;
}

export interface TransportClass {
    from: TrainStation;
    via: TrainStation;
    to: TrainStation;
    szVertragNr: string;
    railwayBills: RailwayBill[];
}