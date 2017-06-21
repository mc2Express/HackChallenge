import './rx-addons';
import 'hammerjs';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { HttpModule, RequestOptions } from '@angular/http';

import { AlertModule } from 'ngx-bootstrap';
import { AppComponent } from './app.component';
import { BrowserModule } from '@angular/platform-browser';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MomentModule } from 'angular2-moment';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { rootRouterConfig } from './app.routes';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule, FormsModule, HttpModule, FlexLayoutModule.forRoot(), ReactiveFormsModule, RouterModule.forRoot(rootRouterConfig), MomentModule,
    AlertModule.forRoot()
  ],
  providers: [
    { provide: LocationStrategy, useClass: HashLocationStrategy }
  ],
  bootstrap: [AppComponent],
})
export class AppModule {
  
  constructor() {}
}
