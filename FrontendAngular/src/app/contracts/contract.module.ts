// Angular Imports
import { NgModule } from '@angular/core';

// This Module's Components
import { ContractTableComponent } from './contract-table/contract-table.component';
import { ContractRowComponent } from "app/contracts/contract-row/contract-row.component";
import { ContractService } from "app/contracts/shared/contract.service";
import { CommonModule } from "@angular/common";
import { ContractDetailComponent } from "app/contracts/contract-detail/contract-detail.component";

@NgModule({
    imports: [
        CommonModule
    ],
    declarations: [
        ContractTableComponent, ContractRowComponent, ContractDetailComponent
    ],
    exports: [
        ContractTableComponent, ContractRowComponent, ContractDetailComponent
    ],
    providers: [ContractService]
})
export class ContractModule {}
