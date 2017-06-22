// Angular Imports

import { CommonModule } from "@angular/common";
import { ContractDetailComponent } from "app/contracts/contract-detail/contract-detail.component";
import { ContractMapComponent } from './contractMap/contractMap.component';
import { ContractService } from "app/contracts/shared/contract.service";
import { ContractTableComponent } from './contract-table/contract-table.component';
import { NgModule } from '@angular/core';

// This Module's Components
@NgModule({
    imports: [
        CommonModule
    ],
    declarations: [
        ContractTableComponent,
        ContractDetailComponent,
        ContractMapComponent
    ],
    exports: [
        ContractTableComponent, ContractDetailComponent
    ],
    providers: [ContractService]
})
export class ContractModule { }
