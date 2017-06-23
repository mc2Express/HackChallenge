import { Component } from '@angular/core';
import { ContractService } from "app/contracts/shared/contract.service";
import { Contract, TransportClass } from "assets/cargoInterfaces/Cargo";

@Component({
    moduleId: module.id,
    selector: 'contract-detail',
    templateUrl: 'contract-detail.component.html',
    styleUrls: ['contract-detail.component.scss']
})
export class ContractDetailComponent {

    public fullScreen: boolean = false;

    constructor(private contractService: ContractService) {}

    public get contract(): Contract {
        return this.contractService.contract;
    }

    public get expandIcon(): string {
        return this.fullScreen ? `compress` : `expand`;
    }

    public close(): void {
        this.contractService.clearCurrentContract();
    }

    public getTransportTitle(transport: TransportClass): string {
        return `${transport.from.name} (${transport.from.stationId}) - ${transport.to.name} (${transport.to.stationId})`;
    }

    public toggleFullScreen(): void {
        this.fullScreen = !this.fullScreen;
    }
}
