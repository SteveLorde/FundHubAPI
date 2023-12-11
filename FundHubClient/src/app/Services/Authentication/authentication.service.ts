import { Injectable } from '@angular/core';
import {User} from "../../Data/Models/User";
import axios from "axios";
import {AuthRequest} from "./DTO/AuthRequest";

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  isloggedin : boolean = false
  activetoken: string | number = ''
  activeuser : User = {description: "", id: "", password: "", username: ""}



  constructor() { }

  async Login(loginrequest: { password: string | null | undefined, username: string | null | undefined }): Promise<any> {
    try {
      let response = await axios.post('http://localhost:5116/Authentication/Login', loginrequest)
      this.activetoken = response.data
      return true
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

  async SetActiveUser(userid : string) {
    let user : User = await axios.post('http://localhost:5116/Authentication/GetUser', userid)
    this.activeuser = user
  }

  async GetActiveUser() {
    return this.activeuser
  }



}
