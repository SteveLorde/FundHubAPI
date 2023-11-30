import { Component } from '@angular/core';
import {FormControl, FormGroup, ReactiveFormsModule} from "@angular/forms";
import axios from "axios";

@Component({
  selector: 'app-login-register-page',
  standalone: true,
    imports: [
        ReactiveFormsModule
    ],
  templateUrl: './login-register-page.component.html',
  styleUrl: './login-register-page.component.scss'
})
export class LoginRegisterPageComponent {

  public hideloginform : boolean = false
  public hideregisterform : boolean = true


  loginform = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  })

  registerformm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  })

  Login() {
    let loginrequst = {
      username: this.loginform.value.username,
      password : this.loginform.value.password
    }
    let check = await axios.get('')


  }

  Register() {

  }



}
