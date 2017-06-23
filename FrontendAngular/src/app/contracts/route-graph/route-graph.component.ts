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
        return this.contractService.contract.wagons[0].reservationReceiveDate;
    }

    public get reservationSendDate(): string {
        return this.contractService.contract.wagons[0].reservationSendDate;
    }
}
