
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import {NgbModule} from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './components/app/app.component';
import { HomeComponent } from './components/home/home.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        NavBarComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        NgbModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
