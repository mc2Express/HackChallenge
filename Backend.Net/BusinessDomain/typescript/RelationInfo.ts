

module Models {  

    export interface RelationInfo { 
        lookupStatus: LookupStatus[];
        werteGereiht: Werteliste[];
        werteFreigegeben: Werteliste[];
        werterKzub: Werteliste[];
        werteUbehVzweNr: Werteliste[];
    } 

    export interface LookupStatus { 
        id: string;
        status: string;
    } 

    export interface Werteliste { 
        wert: string;
        description: string;
    }
}