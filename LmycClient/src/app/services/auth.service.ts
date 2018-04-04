import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class AuthService {

  private BASE_URL: string = 'http://localhost:61831';
  private headers: Headers = new Headers({'Content-Type': 'application/json'});

  constructor(private http: Http) { }

  login(username, password): Promise<any> {
    let url: string = this.BASE_URL + '/connect/token';
    console.log(url);
    return this.http.post(url, JSON.stringify({username, password}), {headers: this.headers}).toPromise();
  }

}
