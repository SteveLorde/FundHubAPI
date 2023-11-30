import { Component } from '@angular/core';
import {Project} from "../../Data/Models/Project";
import {BackendService} from "../../Services/Backend/backend.service";

@Component({
  selector: 'app-projects-page',
  standalone: true,
  imports: [],
  templateUrl: './projects-page.component.html',
  styleUrl: './projects-page.component.scss'
})
export class ProjectsPageComponent {

  public projects : Project[] = []

  constructor(private backend : BackendService) {

  }

  async GetProjects() {
    let projectz = await this.backend.GetProjects()
  }

}
