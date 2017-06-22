// Angular Imports

import { AgmCoreModule } from '@agm/core';
import { CommonModule } from "@angular/common";
import { ContractDetailComponent } from "app/contracts/contract-detail/contract-detail.component";
import { ContractDetailModule } from './contract-detail/contract-detail.module';
import { ContractDetailSectionComponent } from "app/contracts/contract-detail-section/contract-detail-section.component";
import { ContractMapComponent } from './contractMap/contractMap.component';
import { ContractRowComponent } from "app/contracts/contract-row/contract-row.component";
import { ContractService } from "app/contracts/shared/contract.service";
import { ContractTableComponent } from './contract-table/contract-table.component';
import { NgModule } from '@angular/core';

// This Module's Components
@NgModule({
    imports: [
        CommonModule,
        AgmCoreModule.forRoot({
            apiKey: 'AIzaSyDCDbfOm-duBaHtjjhI9qT8MFc7p4Telt4'
        })
    ],

    declarations: [
        ContractTableComponent, ContractRowComponent, ContractDetailComponent, ContractDetailSectionComponent,
        ContractMapComponent
    ],
    exports: [
        ContractTableComponent, ContractMapComponent
    ],
    providers: [ContractService]
})
export class ContractModule { }
