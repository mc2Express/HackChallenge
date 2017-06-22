import { Component, Input, OnInit } from '@angular/core';
import { Contract } from "assets/cargoInterfaces/Cargo";
import { ContractService } from "app/contracts/shared/contract.service";

@Component({
    moduleId: module.id,
    selector: 'contract-row',
    templateUrl: 'contract-row.component.html',
    styleUrls: ['contract-row.component.scss']
})
export class ContractRowComponent {

    @Input() contract: Contract;

    constructor(private contractService: ContractService) {}

    public openContract(): void {
        console.log(`Open contract ${this.contract.contractNr}`);
        this.contractService.setCurrentContract(this.contract);
    }
}
