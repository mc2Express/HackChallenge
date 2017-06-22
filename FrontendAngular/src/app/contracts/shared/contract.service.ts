import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

import { Contract } from "assets/cargoInterfaces/Cargo";
import { Http } from "@angular/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";

@Injectable()
export class ContractService {
    
    public contract: Contract;

    constructor(private http: Http) { }

    search(): Observable<Contract[]> {
        // return Observable.of([
        //     <Contract>{
        //         contractNr: "2000",
        //         creationDate: "Today",
        //         invoices: undefined,
        //         offertDate: "Tomorrow",
        //         offertNr: "2324",
        //         railwayBills: [],
        //         transportClasses: [],
        //         wagons: []
        //     }
        // ])

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
}
