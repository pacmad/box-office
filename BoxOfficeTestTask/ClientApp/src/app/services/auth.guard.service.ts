import { Injectable } from '@angular/core';
import { CanActivate, RouterStateSnapshot, ActivatedRouteSnapshot, Router } from '@angular/router';
import { AuthenticationService } from './authentication.service';

@Injectable({ providedIn: 'root' })
export class AuthGuardService implements CanActivate {

    constructor(private router: Router,
        private auth: AuthenticationService) {

    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const currentUser = this.auth.CurrentUserValue;

        if (currentUser)
            return true;

        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
        return false;
    }
}