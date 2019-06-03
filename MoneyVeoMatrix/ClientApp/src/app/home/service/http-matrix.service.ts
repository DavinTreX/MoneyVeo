
import {HttpClient, HttpParams, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import { catchError, finalize } from 'rxjs/operators';
import { of } from 'rxjs/observable/of';
import { Injectable } from '@angular/core';

@Injectable()
export class HttpMatrixService {
  public showSpinner: boolean = false;
  private matrixEndPoint = 'https://localhost:44326//api/matrix';

  constructor(private http: HttpClient) { }

  public getMatrixResult(): Observable<Matrix[]> {
    this.showSpinner = true;
    return this.http.get<Matrix[]>(`${this.matrixEndPoint}`).pipe(
      catchError(err => {
        return of(err);
      }),
      finalize(() => this.showSpinner = false )
    );
  }

  public postExportMatrix(data: Matrix[]): Observable<Matrix[]>  {
    const httpOptions = {
      headers: new HttpHeaders({
        'api-version': '2',
      })
    };
    console.log(data);
    return this.http.post(`${this.matrixEndPoint}`, data, httpOptions).pipe(
      catchError(err => {
        return of(err);
      })
    );
  }

  public getGenerateMatrixResult(): Observable<Matrix[]> {
    this.showSpinner = true;
    return this.http.get<Matrix[]>(`${this.matrixEndPoint}/generate`).pipe(
      catchError(err => {
        return of(err);
      }),
      finalize(() => this.showSpinner = false)
    );
  }

  public postRotateMatrixResult(data: Matrix[]): Observable<Matrix[]> {
      const httpOptions = {
        headers: new HttpHeaders({
          'api-version': '2',
        })
      };
      console.log(data);
    return this.http.post(`${this.matrixEndPoint}/rotate`, data, httpOptions).pipe(
        catchError(err => {
          return of(err);
        })
      );
  }

}
