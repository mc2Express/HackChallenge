import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

import { Contract } from "assets/cargoInterfaces/Cargo";
import { Http } from "@angular/http";
import { ILongitutaAttitute } from './ILongitutaAttitute';
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { TrainStation } from '../../../assets/cargoInterfaces/Cargo';

@Injectable()
export class ContractService {

    public contract: Contract;

    constructor(private http: Http) { }

    search(): Observable<Contract[]> {
        return this.http
          .get(`/cargo/Index`)
          .map((r: any) => r.json() as Contract[])
          .catch((error: any) => {
              console.error('An friendly error occurred', error);
              return Observable.throw(error.message || error);
          });
    }

    public setCurrentContract(contract: Contract): void {
        this.contract = contract;
    }

    public clearCurrentContract(): void {
        this.contract = undefined;
    }

    public getCoordinatsForName(station: TrainStation): Observable<ILongitutaAttitute> {
        var search = station.name;
        if(station.country.name){
            search = `${search} ${ station.country.name}`;
        }
    return this.http
            .get(`  http://maps.googleapis.com/maps/api/geocode/json?address=${search}`)
            .map((r: any) => r.json().results[0].geometry.location)
            .catch((error: any) => {
                console.error('An friendly error occurred', error);
                return Observable.throw(error.message || error);
            });


    }
}
