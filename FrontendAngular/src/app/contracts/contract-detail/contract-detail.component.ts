import { Component } from '@angular/core';
import { ContractService } from "app/contracts/shared/contract.service";
import { Contract } from "assets/cargoInterfaces/Cargo";

@Component({
    moduleId: module.id,
    selector: 'contract-detail',
    templateUrl: 'contract-detail.component.html',
    styleUrls: ['contract-detail.component.scss']
})
export class ContractDetailComponent {

    constructor(private contractService: ContractService) {}

    public get contract(): Contract {
        return this.contractService.contract;
    }

    public close(): void {
        this.contractService.clearCurrentContract();
    }
}
