import { Component } from '@angular/core';
import {FormControl, FormGroup, ReactiveFormsModule} from "@angular/forms";
import axios from "axios";
import {AuthenticationService} from "../../Services/Authentication/authentication.service";
import {Router} from "@angular/router";
import {NgIf} from "@angular/common";

@Component({
  selector: 'app-login-register-page',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    NgIf
  ],
  templateUrl: './login-register-page.component.html',
  styleUrl: './login-register-page.component.scss'
})
export class LoginRegisterPageComponent {

  public Loginform : boolean = true
  public Registerform : boolean = false
  public status : string = "Register"

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

  SwitchForm() {
    if (this.status == "Register") {
      this.status = "Login"
      this.Loginform = false
      this.Registerform = true
    }
    else {
      this.status = "Register"
      this.Loginform = true
      this.Registerform = false
    }
  }

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

  async LoginTest() {
    let check = await this.authservice.LoginTest()
    if (check) {
      this.router.navigate(['/profile'])
    }
    else {

    }

  }

  async Register() {

  }



}
