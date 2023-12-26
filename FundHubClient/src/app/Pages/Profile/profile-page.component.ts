import {Component, OnInit} from '@angular/core';
import {BackendService} from "../../Services/Backend/backend.service";
import {AuthenticationService} from "../../Services/Authentication/authentication.service";
import {UserPanelComponent} from "../../Components/UserPanel/user-panel.component";
import {NgIf} from "@angular/common";
import {AdminPanelComponent} from "../../Components/AdminPanel/admin-panel.component";
import {Router} from "@angular/router";
import {User} from "../../Data/Models/User";

@Component({
  selector: 'app-profile-page',
  standalone: true,
  imports: [
    UserPanelComponent,
    NgIf,
    AdminPanelComponent
  ],
  templateUrl: './profile-page.component.html',
  styleUrl: './profile-page.component.scss'
})
export class ProfilePageComponent implements OnInit{
  showuserpanel : boolean = false
  showadminpanel : boolean = false
  usertype: string = "test"
    user = {} as User

  constructor(private router : Router,private backend: BackendService, private auth: AuthenticationService) {

  }

  ngOnInit() {
    this.GetUserType()
  }

  Logout() {
    let check : boolean = this.auth.Logout()
    if (check) {
      this.router.navigate(['/'])
    }
  }

  GetUserType() {
    this.user =  this.auth.GetActiveUser()
    if (this.auth.activeuser.usertype == "user") {
      this.showadminpanel = false
      this.showuserpanel = true
    }
    else if (this.auth.activeuser.usertype == "admin") {
      this.showadminpanel = true
      this.showuserpanel = false
    }
  }

}
