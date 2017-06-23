// Angular Imports

import { AgmCoreModule } from '@agm/core';
import { Angular2FontawesomeModule } from "angular2-fontawesome/angular2-fontawesome";
import { ArraySearchPipe } from './shared/ArraySearch.pipe';
import { CommonModule } from "@angular/common";
import { ContractDetailComponent } from "app/contracts/contract-detail/contract-detail.component";
import { ContractDetailModule } from './contract-detail/contract-detail.module';
import { ContractDetailSectionComponent } from "app/contracts/contract-detail-section/contract-detail-section.component";
import { ContractMapComponent } from './contractMap/contractMap.component';
import { ContractService } from "app/contracts/shared/contract.service";
import { ContractTableComponent } from './contract-table/contract-table.component';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { NgPipesModule } from 'ng-pipes';
import { RailwayBillsComponent } from "app/contracts/railway-bills/railway-bills.component";
import { RouteGraphComponent } from "app/contracts/route-graph/route-graph.component";
import { RouteLocationComponent } from "app/contracts/route-location/route-location.component";

// This Module's Components
@NgModule({
    imports: [
        CommonModule,
        AgmCoreModule.forRoot({
            apiKey: 'AIzaSyDCDbfOm-duBaHtjjhI9qT8MFc7p4Telt4'
        }),
        Angular2FontawesomeModule,
        FormsModule,
        NgPipesModule
    ],
    declarations: [
        ContractTableComponent, ContractDetailComponent, ContractDetailSectionComponent,
        RailwayBillsComponent, ContractMapComponent, RouteGraphComponent, RouteLocationComponent, ArraySearchPipe
    ],
    exports: [
        ContractTableComponent, ContractMapComponent
    ],
    providers: [ContractService]
})
export class ContractModule { }
