import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';

@Injectable()
export class ShoeService {

  constructor(private http: Http) { }

  getShoes(){
    return this.http.get('api/shoes')
      .map(res => res.json());
  }

  getStyles(){
    return this.http.get('api/styles')
      .map(res => res.json());
  }

  getBrands(){
    return this.http.get('api/brands')
      .map(res => res.json());
  }

}
