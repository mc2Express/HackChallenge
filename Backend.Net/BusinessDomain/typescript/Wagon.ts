

module Models {  

    export interface Wagon { 
        wagonNumber: string;
        info: string;
        totalWeight: string;
        cargo: Cargo;
    }
}