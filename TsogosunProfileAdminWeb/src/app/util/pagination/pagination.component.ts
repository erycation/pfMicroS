import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Pager } from './pager';

@Component({
  selector: 'app-pagination',
  template: `
    <ngb-pagination
      [maxSize]="pager.maxSize"
      [collectionSize]="pager.recordCount"
      [pageSize]="pager.pageSize"
      [(page)]="pager.currentPage"
      (pageChange)="pageChanged.emit()"
      [boundaryLinks]="true"
      [rotate]="false">
    </ngb-pagination>
  `
})
export class PaginationComponent {

  @Input() pager!: Pager;
  @Output() pageChanged = new EventEmitter<void>();

}