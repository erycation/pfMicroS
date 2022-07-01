export class Pager {

    recordCount = 0;
    currentPage = 1;
    pageSize = 15;
    maxSize = 10;
  
    constructor(itemsPerPage?: number) {
      if (itemsPerPage) {
        this.pageSize = itemsPerPage;
      }
    }
  
    restParams() {
      return {
        currentPage: (this.currentPage).toString(),
        pageSize: (this.pageSize).toString()
      };
    }
  }