import { HeaderComponent, SidebarComponent } from '../shared';

import { AgmCoreModule } from '@agm/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout.component';
import { LayoutRoutingModule } from './layout-routing.module';
import { LiveTrackingComponent } from './tracking/live-tracking/live-tracking.component';
import { NgModule } from '@angular/core';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { TranslateModule } from '@ngx-translate/core';

@NgModule({
    imports: [
        CommonModule,
        NgbDropdownModule.forRoot(),
        LayoutRoutingModule,
        TranslateModule,
        AgmCoreModule.forRoot({
            apiKey: 'AIzaSyDCDbfOm-duBaHtjjhI9qT8MFc7p4Telt4'
        })
    ],
    declarations: [
        LayoutComponent,
        HeaderComponent,
        SidebarComponent,
        LiveTrackingComponent
    ]
})
export class LayoutModule { }
