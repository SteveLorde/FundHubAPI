import {Component, signal, WritableSignal} from '@angular/core';
import {Project} from "../../Data/Models/Project";
import {ActivatedRoute, Router, RouterLink} from "@angular/router";
import {selectedproject, setSelectedProject} from "../../Services/GlobalMemoryStorage";
import {User} from "../../Data/Models/User";
import {BackendService} from "../../Services/Backend/backend.service";

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
  public projectid: string | null = ""
  public project= signal<Project>({
    currentfund: 0, images: [], subtitle: "", totalfundrequired: 0, userowner: {} as User,
    email: "", id: "", description: "", title: "", socialmedia: []
  })

  constructor(private router : Router,private route: ActivatedRoute, private backend: BackendService) {

  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.projectid = params.get('id')
    })
    if (this.projectid != null) {
      this.SetProject(this.projectid)
    }
  }

  async SetProject(projectid : string) {
    let projecttoview = await this.backend.GetProject(projectid)
    this.project.set(projecttoview)
  }

  GoDonate() {
    if (this.projectid != null) {
      this.router.navigate(['/donation', this.projectid])
    }
  }



}
