import { Component, Input } from '@angular/core';
import { TransportClass, RailwayBill, TrainStation, Country } from "assets/cargoInterfaces/Cargo";
import { ContractService } from "app/contracts/shared/contract.service";

@Component({
    moduleId: module.id,
    selector: 'route-graph',
    templateUrl: 'route-graph.component.html',
    styleUrls: ['route-graph.component.scss']
})
export class RouteGraphComponent {

    @Input() railwayBill: RailwayBill;

    constructor(private contractService: ContractService) {}

    public collectionStation: TrainStation = <TrainStation> {
        country: <Country> {
            countryCode: "81",
            name: "Österreich"
        },
        name: "Villach",
        stationId: undefined
    };

    public get reservationReceiveDate(): string {
        return this.railwayBill.wagon.reservationReceiveDate;
    }

    public get reservationSendDate(): string {
        return this.railwayBill.wagon.reservationSendDate;
    }

    public get endStationDate(): string {
        return this.railwayBill.wagon.invoice.executionDate;
    }

    public get endStation(): TrainStation {
        if (!this.railwayBill.wagon.invoice) {
            return undefined;
        }
        
        return {
            country: this.contractService.getCountryById("83"),
            name: this.railwayBill.wagon.invoice.to,
            stationId: undefined
        }
    }
}
