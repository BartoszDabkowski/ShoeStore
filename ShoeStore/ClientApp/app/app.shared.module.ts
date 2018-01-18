
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { ToastyModule } from 'ng2-toasty';

import {NgbModule} from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './components/app/app.component';
import { HomeComponent } from './components/home/home.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { ShoeFormComponent } from './components/shoe-form/shoe-form.component';
import { ShoeService } from './services/shoe.service';
import { BrandService } from './services/brand.service';

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        NavBarComponent,
        ShoeFormComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ToastyModule.forRoot(),
        NgbModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'shoe/new', component: ShoeFormComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [ShoeService, BrandService]
})
export class AppModuleShared {
}
