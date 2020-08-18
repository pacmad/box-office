import { Component } from '@angular/core';
import { ShowsService } from '../services/shows.service';
import { first } from 'rxjs/operators';
import { Show } from '../models/show';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  private shows: Show[]

  constructor(private service: ShowsService) {

  }

  ngOnInit(): void {
    this.service.getAll()
      .pipe(first())
      .subscribe(
        data => { this.shows = data; },
        error => { console.log(error); }
      )

  }

  get showsList(){
    return this.shows;
  }
}
