import { Component, Input } from '@angular/core';
import { TrainStation } from "assets/cargoInterfaces/Cargo";

@Component({
    moduleId: module.id,
    selector: 'route-location',
    templateUrl: 'route-location.component.html',
    styleUrls: ['route-location.component.scss']
})
export class RouteLocationComponent {

    @Input() location: TrainStation;
    @Input() date: string;
}
