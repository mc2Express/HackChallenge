import { Component, Input } from '@angular/core';

@Component({
    moduleId: module.id,
    selector: 'contract-detail-section',
    templateUrl: 'contract-detail-section.component.html',
    styleUrls: ['contract-detail-section.component.scss']
})
export class ContractDetailSectionComponent {

    @Input() title: string;

    public opened: boolean = true;

    public toggle(): void {
        this.opened = !this.opened;
    }
}
