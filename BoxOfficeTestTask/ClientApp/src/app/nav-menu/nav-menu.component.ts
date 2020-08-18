import { Component } from '@angular/core';
import { AuthenticationService } from '../services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  constructor(private auth: AuthenticationService,
    private router: Router) {

  }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  get canSeeDashboard() {
    return this.auth.CurrentUserValue != null;
  }

  logout() {
    this.auth.logout();
    this.router.navigate(['/']);
  }
}
