import { Injectable } from '@angular/core';
import {User} from "../../Data/Models/User";
import axios from "axios";
import {AuthRequest} from "./DTO/AuthRequest";

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  isloggedin : boolean = false
  token: string | number = ''
  activeuser : User = {description: "", id: "", password: "", username: ""}



  constructor() { }

  async Login(loginrequest: { password: string | null | undefined; username: string | null | undefined }): Promise<any> {
    try {
      let userinfo : User = await axios.post('http://localhost:5116/Authentication/Login', loginrequest)
      this.activeuser = userinfo
      let check = true
      return check
    }
    catch (err) {
      console.log(err)
    }
  }

  async Register(registerrequest : AuthRequest) : Promise<any> {
    try {
      let check : boolean = await axios.post('http://localhost:5116/Authentication/Register', registerrequest)
      return check
    }
    catch (err) {
      console.log(err)
    }

  }

  async ChecKToken() {

  }



}
