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
import { RailwayBillsComponent } from "app/contracts/railway-bills/railway-bills.component";
import { Angular2FontawesomeModule } from "angular2-fontawesome/angular2-fontawesome";
import { RouteGraphComponent } from "app/contracts/route-graph/route-graph.component";
import { RouteLocationComponent } from "app/contracts/route-location/route-location.component";

// This Module's Components
@NgModule({
    imports: [
        CommonModule,
        AgmCoreModule.forRoot({
            apiKey: 'AIzaSyDCDbfOm-duBaHtjjhI9qT8MFc7p4Telt4'
        }),
        Angular2FontawesomeModule
    ],
    declarations: [
        ContractTableComponent, ContractRowComponent, ContractDetailComponent, ContractDetailSectionComponent,
        RailwayBillsComponent, ContractMapComponent, RouteGraphComponent, RouteLocationComponent
    ],
    exports: [
        ContractTableComponent, ContractMapComponent
    ],
    providers: [ContractService]
})
export class ContractModule { }
