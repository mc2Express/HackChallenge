import { Component, Input, OnInit } from '@angular/core';

import { ContractService } from 'app/contracts/shared/contract.service';
import { ILongitutaAttitute } from '../shared/ILongitutaAttitute';
import { TransportClass } from '../../../assets/cargoInterfaces/Cargo';

@Component({
  selector: 'contract-map',
  templateUrl: './contractMap.component.html',
  styleUrls: ['./contractMap.component.scss']
})
export class ContractMapComponent implements OnInit {
  ngOnInit(): void {
  }

  constructor(private ContractService: ContractService) { }



  private _TransportClass: TransportClass;
  public get transportClass(): TransportClass {
    return this._TransportClass;
  }

  @Input()
  public set transportClass(v: TransportClass) {
    this._TransportClass = v;
    this.loadCoordinates();
  }


  public fromCoordinates: ILongitutaAttitute;
  public toCoordinates: ILongitutaAttitute;
  public viaCoordinates: ILongitutaAttitute;

  private loadCoordinates() : void {    
    this.ContractService.getCoordinatsForName(this.transportClass.from).subscribe(coordinates => this.fromCoordinates = coordinates);
    this.ContractService.getCoordinatsForName(this.transportClass.via).subscribe(coordinates => this.toCoordinates = coordinates);
    this.ContractService.getCoordinatsForName(this.transportClass.to).subscribe(coordinates => this.viaCoordinates = coordinates);

  }

}