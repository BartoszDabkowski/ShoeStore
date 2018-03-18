
import * as Raven from 'raven-js';

import { NgModule, ErrorHandler } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { ToastyModule } from 'ng2-toasty';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './components/app/app.component';
import { HomeComponent } from './components/home/home.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { ShoeFormComponent } from './components/shoe-form/shoe-form.component';
import { ShoeService } from './services/shoe.service';
import { BrandService } from './services/brand.service';
import { AppErrorHandler } from "./components/app/app.error-handler";
import { ShoeListComponent } from './components/shoe-list/shoe-list.component';
import { PaginationComponent } from './components/pagination/pagination.component';
import { ViewShoeComponent } from './components/view-shoe/view-shoe.component';

Raven.config('https://21356003fef14752a7981418bc98037b@sentry.io/274247').install();

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        NavBarComponent,
        ShoeFormComponent,
        ShoeListComponent,
        PaginationComponent,
        ViewShoeComponent
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
            { path: 'shoes/new', component: ShoeFormComponent },
            { path: 'shoes/edit/:id', component: ShoeFormComponent },
            { path: 'shoes/:id', component: ViewShoeComponent },
            { path: 'shoes', component: ShoeListComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        {provide: ErrorHandler, useClass: AppErrorHandler},
        ShoeService, BrandService
    ]
})
export class AppModuleShared {
}
