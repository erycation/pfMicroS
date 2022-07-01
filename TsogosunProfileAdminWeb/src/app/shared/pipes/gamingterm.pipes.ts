import { Injectable, Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'gamingtermpipe',
  // pure: false
})
@Injectable()
export class GamingTermPipe implements PipeTransform {
  transform(items: any[], param: string): any {
    // filter items array, items which match and return true will be kept, false will be filtered out
    if (param === '') {
      return items;
    }

    if (items) {
      return items.filter((item, index) => item.gamingTerm.toLowerCase() === param.toLowerCase());
    }
  }
}
