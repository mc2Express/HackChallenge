

module App { 
    export class RelationInfo { 
        public lookupStatus: LookupStatus[];
        public werteGereiht: Werteliste[];
        public werteFreigegeben: Werteliste[];
        public werterKzub: Werteliste[];
        public werteUbehVzweNr: Werteliste[];
    }
    export class LookupStatus { 
        public id: string;
        public status: string;
    }
    export class Werteliste { 
        public wert: string;
        public description: string;
    }
} 