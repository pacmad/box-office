import { Component, OnInit } from '@angular/core';
import { Show } from 'src/app/models/show';
import { DashboardService } from 'src/app/services/dashboard.service';
import { first } from 'rxjs/operators';

@Component({
    selector: 'app-dashboard-shows-grid',
    templateUrl: './dashboadr.shows.grid.component.html',
    styleUrls: ['./dashboadr.shows.grid.component.scss']
})
export class DashboardShowsGridComponent implements OnInit {
    constructor(private service: DashboardService) { }

    private shows: Show[];

    ngOnInit(): void {
        this.service.getShows()
            .pipe(first())
            .subscribe(
                data => {
                    this.shows = data;
                },
                error => {
                    console.log(error);
                });
    }

    displayedColumns: string[] = ['id', 'name', 'description', 'minAge', 'delete'];

    get dataSource() {
        return this.shows;
    }
}
