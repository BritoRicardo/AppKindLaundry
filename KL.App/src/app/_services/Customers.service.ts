import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customers } from '../_models/Customers';

@Injectable({
  providedIn: 'root'
})
export class CustomersService {
  baseUrl = 'http://localhost:5000/api/customers';

  constructor(private http: HttpClient) { }

  public getAllCustomers() : Observable<Customers[]> {
    return this.http.get<Customers[]>(this.baseUrl);
  }

  public getClientByName(name : string) : Observable<Customers> {
    // url using template string
    return this.http.get<Customers>(`${this.baseUrl}/getByName/${name}`);
  }

  public getClientById(id : number) : Observable<Customers> {
    return this.http.get<Customers>(`${this.baseUrl}/${id}`);
  }
}
