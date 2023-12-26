import { Component } from '@angular/core';
import {Router, RouterLink, RouterLinkActive} from "@angular/router";
import {AuthenticationService} from "../../Services/Authentication/authentication.service";

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {

  authstatus : string = this.authservice.authstatus

  constructor(private router: Router, private authservice : AuthenticationService) {

  }

  ngOnInit() {
    this.authstatus = this.authservice.authstatus
  }

  GoHome() {
    this.router.navigate([''])
  }



}
