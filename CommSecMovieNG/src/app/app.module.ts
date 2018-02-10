import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { MovieMainComponent } from './movie-main/movie-main.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './app.routing';
import { AppDataService } from './services/app-data.service';
import { MovieDetailComponent } from './movie-detail/movie-detail.component';
import { FwModule } from '../fw/fw.module';
import { StorageService } from './services/storage.service';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    MovieMainComponent,
    MovieDetailComponent,
  ],
  imports: [
    HttpClientModule, FwModule, RouterModule.forRoot(appRoutes), BrowserModule, FormsModule
  ],
  providers: [AppDataService, StorageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
