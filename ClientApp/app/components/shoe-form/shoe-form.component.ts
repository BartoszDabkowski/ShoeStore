import { ShoeService } from '../../services/shoe.service';
import { Subscription } from 'rxjs/Rx';
import { Brand } from '../../models/brand';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-shoe-form',
  templateUrl: './shoe-form.component.html',
  styleUrls: ['./shoe-form.component.css']
})
export class ShoeFormComponent implements OnInit {
brands: Subscription;
styles: Subscription;
colors: Subscription;

  constructor(private shoeService: ShoeService) { }

  ngOnInit() {
    this.brands = this.shoeService.getBrands().subscribe(brands =>
      this.brands = brands);

    this.styles = this.shoeService.getStyles().subscribe(styles =>
      this.styles = styles);

    this.colors = this.shoeService.getColors().subscribe(colors =>
      this.colors = colors);
  }
}
