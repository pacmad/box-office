import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

    private mainForm: FormGroup;
    private returnUrl: string;

    constructor(private auth: AuthenticationService,
        private formBuilder: FormBuilder,
        private router: Router,
        private route: ActivatedRoute) { }


    ngOnInit(): void {

        if (this.auth.CurrentUserValue) { 
            this.router.navigate(['/']);
        }

        this.mainForm = this.formBuilder.group({
            login: ['', Validators.compose([Validators.required, Validators.email])],
            password: ['', Validators.required]
        });

        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
    }

    public get form() {
        return this.mainForm;
    }

    public get f() {
        return this.form.controls;
    }

    submitForm(event) {
        if (this.form.valid) {
            this.auth.login(this.f.login.value, this.f.password.value)
                .pipe(first())
                .subscribe(
                    data => {
                        this.router.navigate([this.returnUrl]);
                    },
                    error => {
                        console.log(error);
                    });
        }
    }
}
