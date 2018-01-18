import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import { SaveShoe } from "../models/saveShoe";

@Injectable()
export class ShoeService {

  constructor(private http: Http) { }

  getShoes(){
    return this.http.get('api/shoes')
      .map(res => res.json());
  }

  getStyles(){
    return this.http.get('api/shoes/styles')
      .map(res => res.json());
  }

  getColors(){
    return this.http.get('api/shoes/colors')
      .map(res => res.json());
  }

  getBrands(){
    return this.http.get('api/brands')
      .map(res => res.json());
  }

  getSizes() {
    return this.http.get('api/shoes/sizes')
        .map(res => res.json());
  }

  create(shoe: SaveShoe) {
      return this.http.post('api/shoes', shoe)
          .map(res => res.json());
  }
}
