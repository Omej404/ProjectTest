import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CandidatService {

  private baseUrl: string = "https://localhost:7109/api/"
  constructor(private http: HttpClient) { }

  register(candidatObj: any) {
    return this.http.post<any>(`${this.baseUrl}registerC`, candidatObj)
  }
}
