import { Component } from '@angular/core';
import {Router, RouterLink, RouterLinkActive} from "@angular/router";

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {

  public authstatus : string = 'LoginRegister/Register'

  constructor(private router: Router) {
  }


  GoHome() {
    this.router.navigate([''])
  }

}
