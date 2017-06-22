import { Component, Input, OnInit } from '@angular/core';
import { Contract } from "assets/cargoInterfaces/Cargo";

@Component({
    moduleId: module.id,
    selector: 'contract-detail',
    templateUrl: 'contract-detail.component.html',
    styleUrls: ['contract-detail.component.scss']
})
export class ContractDetailComponent {

    @Input() contract: Contract;
}
