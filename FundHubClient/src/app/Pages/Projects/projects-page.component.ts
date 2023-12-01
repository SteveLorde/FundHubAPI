import { Component } from '@angular/core';
import {Project} from "../../Data/Models/Project";
import {BackendService} from "../../Services/Backend/backend.service";
import {NgForOf} from "@angular/common";
import {Router, RouterLink, RouterLinkActive} from "@angular/router";

@Component({
  selector: 'app-projects-page',
  standalone: true,
  imports: [
    NgForOf,
    RouterLink,
    RouterLinkActive
  ],
  templateUrl: './projects-page.component.html',
  styleUrl: './projects-page.component.scss'
})
export class ProjectsPageComponent {

  public projects : Project[] = []

  constructor(private backend : BackendService, private router : Router) {

  }

  async GetProjects() {
    let projectz = await this.backend.GetProjects()
    this.projects = projectz
  }

  ViewProject(project : Project) {

  }


}
