import { Component, Input, OnInit } from '@angular/core';

import { ArraySearchPipe } from '../shared/ArraySearch.pipe';
import { ContainsPipe } from 'ng-pipes';
import { Contract } from "assets/cargoInterfaces/Cargo";
import { ContractService } from "app/contracts/shared/contract.service";

@Component({
    selector: 'contract-table',
    templateUrl: 'contract-table.component.html',
    styleUrls: ['contract-table.component.scss'],
     providers: [ArraySearchPipe],
})
export class ContractTableComponent implements OnInit {
    
    private contracts: Contract[];

    constructor(private contractService: ContractService) {
    }

    @Input()
    public queryString : string = ""
    
    ngOnInit(): void {
        this.contractService.search().subscribe(contracts => this.contracts = contracts);
    }

     public openContract(contract : Contract): void {
        console.log(`Open contract ${contract.contractNr}`);
        this.contractService.setCurrentContract(contract);
    }
}
