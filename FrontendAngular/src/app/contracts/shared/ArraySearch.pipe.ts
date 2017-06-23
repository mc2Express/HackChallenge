import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'arraySearch',
  pure: false
})
export class ArraySearchPipe implements PipeTransform {

  transform(items: any, term: any): any {
    if (term === undefined) return items;

    return items.filter(function(item) {
      for(let property in item){
        if (item[property] === null){
          continue;
        }
        if(item[property].toString().toLowerCase().includes(term.toLowerCase())){
          return true;
        }
      }
      return false;
    });
  }
}