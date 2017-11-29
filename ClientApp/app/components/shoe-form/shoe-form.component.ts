import { Subscription } from 'rxjs/Rx';
import { Brand } from '../../models/brand';
import { BrandService } from '../../services/brand.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-shoe-form',
  templateUrl: './shoe-form.component.html',
  styleUrls: ['./shoe-form.component.css']
})
export class ShoeFormComponent implements OnInit {
brands: Subscription;
  constructor(private brandService: BrandService) { }

  ngOnInit() {
    this.brands = this.brandService.getBrands().subscribe(brands =>
      this.brands = brands);
  }

}
