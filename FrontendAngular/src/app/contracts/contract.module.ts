// Angular Imports
import { NgModule } from '@angular/core';

// This Module's Components
import { ContractTableComponent } from './contract-table/contract-table.component';
import { ContractDetailComponent } from "app/contracts/contract-detail/contract-detail.component";
import { ContractService } from "app/contracts/shared/contract.service";
import { CommonModule } from "@angular/common";

@NgModule({
    imports: [
        CommonModule
    ],
    declarations: [
        ContractTableComponent, ContractDetailComponent
    ],
    exports: [
        ContractTableComponent, ContractDetailComponent
    ],
    providers: [ContractService]
})
export class ContractModule {}
