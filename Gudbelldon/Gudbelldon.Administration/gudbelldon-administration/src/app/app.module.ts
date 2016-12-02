import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';
import { MaterialModule } from '@angular/material';

import { AppComponent } from './app.component';
import { EventsComponent } from './events/events.component';
import { KnittingComponent } from './knitting/knitting.component';


const appRoutes: Routes = [
  { path: '', component: EventsComponent },
  { path: 'events', component: EventsComponent },
  { path: 'knitting', component: KnittingComponent }
]

@NgModule({
  declarations: [
    AppComponent,
    EventsComponent,
    KnittingComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    MaterialModule.forRoot(),
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
