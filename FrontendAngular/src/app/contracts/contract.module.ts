// Angular Imports

import { CommonModule } from "@angular/common";
import { ContractDetailComponent } from "app/contracts/contract-detail/contract-detail.component";
import { ContractMapComponent } from './contractMap/contractMap.component';
import { ContractService } from "app/contracts/shared/contract.service";
import { ContractTableComponent } from './contract-table/contract-table.component';
import { NgModule } from '@angular/core';
import { ContractRowComponent } from "app/contracts/contract-row/contract-row.component";
import { ContractDetailSectionComponent } from "app/contracts/contract-detail-section/contract-detail-section.component";

// This Module's Components
@NgModule({
    imports: [
        CommonModule
    ],

    declarations: [
        ContractTableComponent, ContractRowComponent, ContractDetailComponent, ContractDetailSectionComponent,
        ContractMapComponent
    ],
    exports: [
        ContractTableComponent
    ],
    providers: [ContractService]
})
export class ContractModule { }
