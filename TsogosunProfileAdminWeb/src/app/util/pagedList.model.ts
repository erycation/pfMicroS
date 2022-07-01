export interface Page<T> {

  results: T[];
  currentPage: number;
  recordCount: number;
  pageCount: number;
  pageSize: number;

  /*
    results: T[];
    currentPage: number;
    totalPages: number;
    totalCount: number;
    pageSize: number;

    */
  }

