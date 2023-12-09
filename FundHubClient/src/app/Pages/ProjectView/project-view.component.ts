import {Component, signal, WritableSignal} from '@angular/core';
import {Project} from "../../Data/Models/Project";
import {RouterLink} from "@angular/router";
import {selectedproject, setSelectedProject} from "../../Services/GlobalMemoryStorage";
import {User} from "../../Data/Models/User";

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
    currentfund: 0, images: [], subtitle: "", totalfundrequired: 0, userowner: {} as User,
    email: "", id: "", description: "", title: "", socialmedia: []
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
