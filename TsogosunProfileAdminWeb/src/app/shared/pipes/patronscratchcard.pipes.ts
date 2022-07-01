import { Injectable, Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'patronscratchcardpipe',
  // pure: false
})
@Injectable()
export class PatronScratchCardPipe implements PipeTransform {
  transform(items: any[], param: string): any {
    // filter items array, items which match and return true will be kept, false will be filtered out
    if (param === 'all') {
      return items;
    }

    if (items) {
      return items.filter((item, index) => item.winnerStatus.toLowerCase()   === param.toLowerCase());
    }
  }
}
