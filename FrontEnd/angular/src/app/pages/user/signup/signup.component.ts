import {Component, OnInit} from '@angular/core';
import {NgForm} from "@angular/forms";
import {Store} from "@ngrx/store";
import {AppState} from "../../../core/store/app-store";
import {delay, Observable} from "rxjs";
import {EmailService} from "../../../core/account/services/email-service";
import {UserRequestedToSignUp} from "../../../core/store/user/actions";

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  isEmailExist$: Observable<boolean>

  constructor(
    private store: Store<AppState>,
    private emailService: EmailService
  ) {
  }

  ngOnInit(): void {
  }

  signUp(form: NgForm, event: SubmitEvent) {
    // @ts-ignore
    window.files = event.target.files;
    this.store.dispatch(new UserRequestedToSignUp(form.value));
  }

  checkChanges(value: string) {
    this.isEmailExist$ = this.emailService.isEmailExists(value).pipe(delay(500));
  }
}
