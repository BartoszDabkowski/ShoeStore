import { ShoeService } from '../../services/shoe.service';
import { Subscription } from 'rxjs/Rx';
import { Brand } from '../../models/brand';
import { SaveShoe } from '../../models/saveShoe';
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
shoe: SaveShoe = {
    name: "",
    brandId: 0,
    styles: [],
    colors: [],
    sizes: []
}

  constructor(private shoeService: ShoeService) { }

  ngOnInit() {
    this.brands = this.shoeService.getBrands().subscribe(brands =>
      this.brands = brands);

    this.styles = this.shoeService.getStyles().subscribe(styles =>
      this.styles = styles);

    this.colors = this.shoeService.getColors().subscribe(colors =>
        this.colors = colors);

    this.shoeService.getSizes().subscribe(sizes =>
        this.shoe.sizes = sizes.map((size: any) => size.id)
    );
  }

  onColorToggle(colorId: number, $event: any) {
      if ($event.target.checked) {
          this.shoe.colors.push(colorId);
      } else {
          const index = this.shoe.colors.indexOf(colorId);
          this.shoe.colors.splice(index, 1);
      }
  }

    onStyleToggle(styleId: number, $event: any) {
        if ($event.target.checked) {
            this.shoe.styles.push(styleId);
        } else {
            const index = this.shoe.styles.indexOf(styleId);
            this.shoe.styles.splice(index, 1);
        }
    }

  submit() {
      this.shoeService.create(this.shoe)
          .subscribe(x => console.log(x));
  }

  private setShoe(s: SaveShoe) {
      this.shoe.name = s.name;
      this.shoe.brandId = s.brandId;
  }
}
