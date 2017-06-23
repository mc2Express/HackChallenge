import { Component, OnInit } from '@angular/core';
import { RailwayBill, TransportClass } from "assets/cargoInterfaces/Cargo";
import { ContractService } from "app/contracts/shared/contract.service";

@Component({
    moduleId: module.id,
    selector: 'railway-bills',
    templateUrl: 'railway-bills.component.html',
    styleUrls: ['railway-bills.component.scss']
})
export class RailwayBillsComponent {

    constructor(private contractService: ContractService) {}

    public get transports(): TransportClass[] {
        return this.contractService.contract.transportClasses;
    }
}
