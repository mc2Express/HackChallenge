import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

import { Contract } from "assets/cargoInterfaces/Cargo";
import { Http } from "@angular/http";
import { ILongitutaAttitute } from './ILongitutaAttitute';
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { TrainStation, Country } from '../../../assets/cargoInterfaces/Cargo';

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

    public getCountryById(id: string): Country {
        if (id === "81") {
            return <Country>{
                countryCode: id,
                name: "Österreich"
            }
        } else if (id === "83") {
            return <Country>{
                countryCode: id,
                name: "Italien"
            }
        } else {
            return <Country>{
                countryCode: id,
                name: "Unbekannt"
            }
        }
    }

    public getStatusById(id: string): string {
        switch (id) {
            case "1": return "Abgefahren";
            case "2": return "Angekommen";
            case "3": return "Beigestellt";
            case "4": return "Abgeholt";
            case "6": return "Streckenbeigestellt";
            case "7": return "Rueckgegeben";
            case "8": return "Streckenrueckgegeben";
            case "9": return "Streckenabgeholt";
            case "10": return "UBH-Beigestellt";
            case "11": return "UBH-Abgeholt";
            case "12": return "im Ausgangszug";
            case "14": return "Übergabe an EVU";
            case "15": return "Grenzaustritt";
            case "16": return "Grenzeintritt";
            case "20": return "Mitgeschlepptes TF";
            case "22": return "LTPA";
            case "24": return "Übernahme von EVU";
        }
    }

    public getCoordinatsForName(station: TrainStation): Observable<ILongitutaAttitute> {
        var search = station.name;
        if (station.country.name) {
            search = `${search} ${station.country.name}`;
        }
        return this.http
            .get(`  http://maps.googleapis.com/maps/api/geocode/json?address=${search}`)
            .map((r: any) => r.json().results[0].geometry.location)
            .map((r: any) => <ILongitutaAttitute>{
                lat: r.lat,
                lng: r.lng,
                description: station.name
            })
            .catch((error: any) => {
                console.error('An friendly error occurred', error);
                return Observable.throw(error.message || error);
            });


    }
}
