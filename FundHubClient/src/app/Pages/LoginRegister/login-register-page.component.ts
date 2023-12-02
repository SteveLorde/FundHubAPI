import { Component } from '@angular/core';
import {FormControl, FormGroup, ReactiveFormsModule} from "@angular/forms";
import axios from "axios";
import {AuthenticationService} from "../../Services/Authentication/authentication.service";
import {Router} from "@angular/router";

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

  constructor(private authservice : AuthenticationService, private router : Router) {
  }


  loginform = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  })

  registerformm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  })

   async Login() {
    let loginrequst = {
      username: this.loginform.value.username,
      password : this.loginform.value.password
    }
    let check = await this.authservice.Login(loginrequst)
     if (check) {
       this.router.navigate(['/profile'])
     }
     else {

     }

  }

  async Register() {

  }



}
