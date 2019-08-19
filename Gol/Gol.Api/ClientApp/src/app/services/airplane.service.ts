import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Airplane } from '../models/airplane-model';

@Injectable({
  providedIn: 'root'
})
export class AirplaneService {

  private BASE_URL: string = 'https://localhost:5001/v1/airplane';

  constructor(private http: Http) { }

  obterTodos(): Observable<Airplane[]> {
    return this.http.get(this.BASE_URL)
      .pipe(map((res: Response) => res.json()));
  }

  obterPorId(id: string): Observable<Airplane> {
    return this.http.get(`${this.BASE_URL}/${id}`)
      .pipe(map((res: Response) => res.json()));
  }

  delete(id:string) {
    return this.http.delete(`${this.BASE_URL}/${id}`)
      .pipe(map((res: Response) => res.json()));
  }

  salvar(airplane: Airplane) {
    return this.http.post(this.BASE_URL, airplane)
      .pipe(map((res: Response) => res.json()));
  }

  atualizar(airplane: Airplane) {
    return this.http.put(this.BASE_URL, airplane)
      .pipe(map((res: Response) => res.json()));
  }
}
