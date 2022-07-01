import { HttpClient, HttpErrorResponse, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { DialogService } from '../shared/dialog/dialog.service';
import { first, map } from 'rxjs/operators';

export interface BackendOptions {
  headers?: { [header: string]: string | string[]; };
  params?: { [param: string]: string | string[]; };
}

@Injectable({ providedIn: 'root' })
export class BackendService {

  busyCount = 0;

  constructor(private http: HttpClient,
    private router: Router,
    public dialogService: DialogService) {
  }

  get busy() {
    return this.busyCount > 0;
  }

  public async get<T>(path: string, params?: { [param: string]: string | string[]; }) {

    await this.incrementBusyCount();

    try {
      return await this.http.get<T>(environment.apiUrl + path, { params }).toPromise();
    } catch (e) {
      this.handleError(e);
    } finally {
      await this.decrementBusyCount();
    }
  }

 async postResults<T>(path: string, body: any, options?: BackendOptions) : Promise<any> {
     this.postInternal<T>(environment.apiUrl + path, body, options).pipe(first()).subscribe(results => {
      return results;
    },
      error => {
        this.handleError(error);
      });
  }

  public  postInternal<T>(path: string, body: any, options?: BackendOptions) {
     return this.http.post<T>(path, body, options).pipe(map(results => {
      return results;
    }));
  }

  public postResponse<T>(path: string, body: any, options?: BackendOptions): Observable<any> {
    this.incrementBusyCount();

    try {
      return this.http.post(environment.apiUrl + path, body);
    }
    catch (e) {
      this.handleError(e);
    } finally {
      this.decrementBusyCount();
    }
  }

  public updateResponse<T>(path: string, body: any, options?: BackendOptions): Observable<any> {
    this.incrementBusyCount();

    try {
      return this.http.put(environment.apiUrl + path, body);
    }
    catch (e) {
      this.handleError(e);
    } finally {
      this.decrementBusyCount();
    }
  }

  public async postWithResponse<T>(path: string, body: any, options?: BackendOptions
  ) {
    await this.incrementBusyCount();

    try {
      const response = await this.http.post<T>(
        environment.apiUrl + path, body, options
      ).toPromise();

      //if (response) {
        //this.displayResult(response);
      //}
      return response;
    } catch (e) {
      this.handleError(e);
    } finally {
      await this.decrementBusyCount();
    }
  }

  private async incrementBusyCount() {
    await Promise.resolve(); // prevent ExpressionChangedAfterItHasBeenCheckedError
    this.busyCount++;
  }

  private async decrementBusyCount() {
    await Promise.resolve(); // prevent ExpressionChangedAfterItHasBeenCheckedError
    this.busyCount--;
  }

  public async download<T>(path: string, params?: { [param: string]: string | string[]; }) {
    await this.incrementBusyCount();

    try {
      const response = await this.http.get(
        environment.apiUrl + path,
        { params, responseType: 'blob' }
      ).toPromise();

      
      this.openPdf(response)
    } catch (e) {
      this.handleError(e);
    } finally {
      await this.decrementBusyCount();
    }
  }

  public async downloadFilePDF<T>(path: string, params?: { [param: string]: string | string[]; }) {
    await this.incrementBusyCount();

    try {
      const response = await this.http.get(
        environment.apiUrl + path,
        { params, responseType: 'blob' }
      ).toPromise();

      this.openPdf(response)
    } catch (e) {
      this.handleError(e);
    } finally {
      await this.decrementBusyCount();
    }
  }

  public async downloadFileExcel<T>(path: string, params?: { [param: string]: string | string[]; }) {
    await this.incrementBusyCount();

    try {
      const response = await this.http.get(
        environment.apiUrl + path,
        { params, responseType: 'blob' }
      ).toPromise();
      
      this.openExcel(response)
    } catch (e) {
      this.handleError(e);
    } finally {
      await this.decrementBusyCount();
    }
  }

  private openPdf(response: Blob, fileName?: string) {
    const newBlob = new Blob([response], { type: "application/pdf" });

    var a = document.createElement("a");
    document.body.appendChild(a);
    var csvUrl = URL.createObjectURL(newBlob);
    a.href = csvUrl;
    a.target = "_blank";

    if (fileName !== null)
      a.download = fileName;

    a.click();
    URL.revokeObjectURL(a.href)
    a.remove();
  }


  private openExcel(response: Blob, fileName?: string) {
    const newBlob = new Blob([response], { type: "application/vnd.ms-excel" });

    var a = document.createElement("a");
    document.body.appendChild(a);
    var csvUrl = URL.createObjectURL(newBlob);
    a.href = csvUrl;
    a.target = "_blank";

    if (fileName !== null)
      a.download = fileName;

    a.click();
    URL.revokeObjectURL(a.href)
    a.remove();
  }

  private handleError(error: any) {
    
    switch (error.status) {

      case 400:
        this.dialogService.openAlertModal("Alert", `${error.error.message}`, () => { });
        break;

      case 401:
        this.dialogService.openAlertModal("Alert", "UnAuthorized, System will automatically logout.", () => { });
        this.router.navigateByUrl("/login");
        break;

      case 403:
        this.dialogService.openAlertModal("Alert", "forbidden, System will automatically logout.", () => { });
        this.router.navigateByUrl("/login");
        break;

      case 500:
        this.dialogService.openAlertModal("Alert", `${error.error.message}`, () => { });
        break;

      default:
        this.dialogService.openAlertModal("Alert", `Status Error Code : ${error.error.message} .Contact system administrator`, () => { });
        this.router.navigateByUrl("/login");
        break;
    }
  }
}