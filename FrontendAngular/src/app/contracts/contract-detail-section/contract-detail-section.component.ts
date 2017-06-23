import { Component, Input } from '@angular/core';

@Component({
    moduleId: module.id,
    selector: 'contract-detail-section',
    templateUrl: 'contract-detail-section.component.html',
    styleUrls: ['contract-detail-section.component.scss']
})
export class ContractDetailSectionComponent {

    @Input() title: string;
    @Input() stateIcon: string;

    public opened: boolean = true;

    public get iconRotation(): number {
        return this.opened ? 90 : 0;
    }

    public toggle(): void {
        this.opened = !this.opened;
    }
}
