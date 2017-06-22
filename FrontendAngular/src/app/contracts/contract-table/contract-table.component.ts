import { Component, OnInit } from '@angular/core';
import { ContractService } from "app/contracts/shared/contract.service";
import { Contract } from "assets/cargoInterfaces/Cargo";

@Component({
    selector: 'contract-table',
    templateUrl: 'contract-table.component.html',
    styleUrls: ['contract-table.component.scss']
})
export class ContractTableComponent implements OnInit {
    
    private contracts: Contract[];

    constructor(private contractService: ContractService) {}
    
    ngOnInit(): void {
        this.contractService.search().subscribe(contracts => this.contracts = contracts);
    }
}
