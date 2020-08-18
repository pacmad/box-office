import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';
import { Show } from 'src/app/models/show';
import { ShowsService } from 'src/app/services/shows.service';
import { first } from 'rxjs/operators';

@Component({
    selector: 'app-dashborad-show-details',
    templateUrl: './dashboard.show.details.component.html',
    styleUrls: ['./dashboard.show.details.component.scss']
})
export class ShowDetailsComponentComponent implements OnInit {

    private showId?: number;
    private mainForm: FormGroup;
    private isLoading = true;
    private show: Show;

    constructor(private route: ActivatedRoute,
        private formBuilder: FormBuilder,
        private service: ShowsService) {

    }

    ngOnInit(): void {
        this.showId = this.route.snapshot.params.showId;
        this.initForm();

        if (this.showId) {
            this.service.get(this.showId)
                .pipe(first())
                .subscribe(
                    data => {
                        this.fillForm(data);
                    },
                    error => {
                        console.log(error);
                    }
                )
        }


    }

    get form() {
        return this.mainForm;
    }

    get f() {
        return this.form.controls;
    }

    get sessionsFormArray(): FormArray {
        return this.mainForm.get('sessions') as FormArray;
    }

    private initForm() {
        this.mainForm = this.formBuilder.group({
            id: [0],
            name: ['', Validators.required],
            description: ['', Validators.required],
            durationInMinutes: [0, Validators.required],
            minAge: [12, Validators.required],
            sessions: this.formBuilder.array([this.createSession()])

        });

        this.isLoading = false;
    }

    private fillForm(formData: Show) {
        this.f.id.setValue(formData.id);
        this.f.name.setValue(formData.name);
        this.f.description.setValue(formData.description);
        this.f.minAge.setValue(formData.minAge);
        this.f.durationInMinutes.setValue(formData.durationInMinutes);
       
        this.sessionsFormArray.clear();

        formData.sessions.map(x => {
            var session = this.createSession();
            session.get('id').setValue(x.id);
            session.get('showId').setValue(formData.id);
            session.get('startTime').setValue(x.startTime);
            session.get('maxTickets').setValue(x.maxTickets);

            this.sessionsFormArray.push(session);
        });
    }



    createSession(): FormGroup {
        return this.formBuilder.group({
            id: [0],
            showId: [0],
            startTime: ['', Validators.required],
            maxTickets: [0, Validators.required]
        });
    }

    addSession() {
        const sessions = this.form.get('sessions') as FormArray;
        sessions.push(this.createSession());
    }

    submitForm() {
        if (this.form.valid) {
            console.log("submit")
            this.service.add(this.form.value)
                .pipe(first())
                .subscribe(
                    data => {

                    },
                    error => {
                        console.log(error);
                    }
                )
        }
        else {
            console.log(this.form)
        }
    }
}
