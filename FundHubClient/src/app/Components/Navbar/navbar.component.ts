import {Component, OnInit} from '@angular/core';
import {Router, RouterLink, RouterLinkActive} from "@angular/router";
import {AuthenticationService} from "../../Services/Authentication/authentication.service";

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent implements OnInit {

  authstatus : string = ""

  constructor(private router: Router, private authservice : AuthenticationService) {

  }

  ngOnInit() {
    this.authservice.currentAuthStatus.subscribe(res => this.authstatus = res)
  }

  GoHome() {
    this.router.navigate([''])
  }



}
