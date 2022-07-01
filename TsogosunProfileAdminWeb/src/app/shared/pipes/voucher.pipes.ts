import { Injectable, Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'voucherpipe',
  // pure: false
})
@Injectable()
export class VoucherPipe implements PipeTransform {
  transform(items: any[], param: string): any {
    // filter items array, items which match and return true will be kept, false will be filtered out
    if (param === 'all') {
      return items;
    }

    if (items) {
      return items.filter((item, index) => item.offerStatus === param);
    }
  }
}
