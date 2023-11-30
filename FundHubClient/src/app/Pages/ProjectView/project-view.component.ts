import {Component, signal, WritableSignal} from '@angular/core';
import {Project} from "../../Data/Models/Project";
import {RouterLink} from "@angular/router";
import {selectedproject, setSelectedProject} from "../../Services/GlobalMemoryStorage";

@Component({
  selector: 'app-project-view',
  standalone: true,
  imports: [
    RouterLink
  ],
  templateUrl: './project-view.component.html',
  styleUrl: './project-view.component.scss'
})
export class ProjectViewComponent {

  public project= signal<Project>({
    email: "", projectId: "", projectdesc: "", projectname: "", socialmedia: []
  })

  constructor() {
  }

  SetProject(projectoview : Project) {
    this.project.set(projectoview)
  }

  GoDonate() {
    setSelectedProject(this.project())
  }



}
