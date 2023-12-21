import { Component } from '@angular/core';
import {Project} from "../../Data/Models/Project";
import {BackendService} from "../../Services/Backend/backend.service";
import {CurrencyPipe, NgForOf, NgSwitch, NgSwitchCase} from "@angular/common";
import {Router, RouterLink, RouterLinkActive} from "@angular/router";
import environment from "../../../environments/environment";

@Component({
  selector: 'app-projects-page',
  standalone: true,
  imports: [
    NgForOf,
    RouterLink,
    RouterLinkActive,
    CurrencyPipe,
    NgSwitch,
    NgSwitchCase
  ],
  templateUrl: './projects-page.component.html',
  styleUrl: './projects-page.component.scss'
})
export class ProjectsPageComponent {

  public projects : Project[] = []

  constructor(private backend : BackendService, private router : Router) {

  }

  ngOnInit() {
    this.GetProjects()
  }

  async GetProjects() {
    let projectz = await this.backend.GetProjects()
    this.projects = projectz
  }

  ViewProject(projectid : string) {
    this.router.navigate(['/viewproject', projectid])
  }


  protected readonly environment = environment;
}
