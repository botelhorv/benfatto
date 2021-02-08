import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';
import { Logs } from './logs';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json;','Access-Control-Allow-Origin':'*', 'Access-Control-Allow-Headers':'Content-Type' })
  
};
const apiUrl = 'https://localhost:44319/api/log';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
  
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
  
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  getLogs(): Observable<Logs[]> {
    return this.http.get<Logs[]>(`${apiUrl}`)
      .pipe(
        tap(logs => console.log('fetched logs')),
        catchError(this.handleError('getLogs', []))
      );
  }

  getLogsById(id: number): Observable<Logs> {
    const url = `${apiUrl}/${id}`;
    return this.http.get<Logs>(url).pipe(
      tap(_ => console.log(`fetched logs id=${id}`)),
      catchError(this.handleError<Logs>(`getLogsById id=${id}`))
    );
  }

  addLogs(logs: Logs): Observable<Logs> {
    return this.http.post<Logs>(apiUrl, logs, httpOptions).pipe(
      tap((c: Logs) => console.log(`added logs w/ id=${c.id}`)),
      catchError(this.handleError<Logs>('addLogs'))
    );
  }

  updateLogs(logs: Logs): Observable<Logs> {
    return this.http.put<Logs>(apiUrl, logs, httpOptions).pipe(
      tap((c: Logs) => console.log(`added logs w/ id=${c.id}`)),
      catchError(this.handleError<Logs>('addLogs'))
    );
  }

  deleteLogs(id: number): Observable<Logs> {
    const url = `${apiUrl}/${id}`;
    return this.http.delete<Logs>(url, httpOptions).pipe(
      tap(_ => console.log(`deleted logs id=${id}`)),
      catchError(this.handleError<Logs>('deleteLogs'))
    );
  }

}

