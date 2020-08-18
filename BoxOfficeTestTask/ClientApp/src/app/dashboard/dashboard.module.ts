import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { DashboardShowsGridComponent } from './components/dashboard/dashboadrd-shows-grid/dashboadr.shows.grid.component';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { JwtInterceptor } from '../helpers/jwt.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { DashboardService } from '../services/dashboard.service';
import { ShowDetailsComponentComponent } from './components/dashboard/dashboard-show-details/dashboard.show.details.component';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import {
  NgxMatDatetimePickerModule,
  NgxMatNativeDateModule,
  NgxMatTimepickerModule
} from '@angular-material-components/datetime-picker';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { ShowsService } from '../services/shows.service';
import { RouterModule } from '@angular/router';
import { ErrorInterceptor } from '../helpers/error.interceptor';

@NgModule({
  declarations: [
    DashboardComponent,
    DashboardShowsGridComponent,
    ShowDetailsComponentComponent],
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatInputModule,
    MatCardModule,
    FormsModule,
    NgxMatDatetimePickerModule,
    NgxMatTimepickerModule,
    NgxMatNativeDateModule,
    MatDatepickerModule,
    RouterModule
  ],
  providers: [
    DashboardService,
    ShowsService,
    {
      provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true

    },
    {
      provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true
    }
  ]
})
export class DashboardModule { }
