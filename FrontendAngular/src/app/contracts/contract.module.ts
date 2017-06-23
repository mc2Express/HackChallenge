// Angular Imports

import { CommonModule } from "@angular/common";
import { ContractDetailComponent } from "app/contracts/contract-detail/contract-detail.component";
import { ContractMapComponent } from './contractMap/contractMap.component';
import { ContractService } from "app/contracts/shared/contract.service";
import { ContractTableComponent } from './contract-table/contract-table.component';
import { NgModule } from '@angular/core';
import { ContractRowComponent } from "app/contracts/contract-row/contract-row.component";
import { ContractDetailSectionComponent } from "app/contracts/contract-detail-section/contract-detail-section.component";
import { RailwayBillsComponent } from "app/contracts/railway-bills/railway-bills.component";
import { Angular2FontawesomeModule } from "angular2-fontawesome/angular2-fontawesome";

// This Module's Components
@NgModule({
    imports: [
        CommonModule, Angular2FontawesomeModule 
    ],
    declarations: [
        ContractTableComponent, ContractRowComponent, ContractDetailComponent, ContractDetailSectionComponent,
        RailwayBillsComponent, ContractMapComponent
    ],
    exports: [
        ContractTableComponent
    ],
    providers: [ContractService]
})
export class ContractModule { }
