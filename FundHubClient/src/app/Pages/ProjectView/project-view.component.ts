import {Component, signal, WritableSignal} from '@angular/core';
import {Project} from "../../Data/Models/Project";
import {ActivatedRoute, Router, RouterLink} from "@angular/router";
import {selectedproject, setSelectedProject} from "../../Services/GlobalMemoryStorage";
import {User} from "../../Data/Models/User";
import {BackendService} from "../../Services/Backend/backend.service";
import {NgForOf} from "@angular/common";
import environment from "../../../environments/environment";

@Component({
  selector: 'app-project-view',
  standalone: true,
  imports: [
    RouterLink,
    NgForOf
  ],
  templateUrl: './project-view.component.html',
  styleUrl: './project-view.component.scss'
})
export class ProjectViewComponent {
  public projectid: string | null = ""
  public project : Project = {category: {id: "", name: ""}, currentfund: 0, description: "", id: "", subtitle: "", title: "", totalfundrequired: 0}
  public projectowner : User = {usertype: "", description: "", password: "", username: "", id: " "}

  constructor(private router : Router,private route: ActivatedRoute, private backend: BackendService) {

  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.projectid = params.get('id')
    })
    if (this.projectid != null) {
      this.SetProject(this.projectid)
    }
    let ownid = "c0c343f3-a9d0-4ae6-93e4-0d1923b04e60"
    this.SetProjectOwner(ownid)
  }



  async SetProject(projectid : string) {
    let projecttoview : Project = await this.backend.GetProject(projectid)
    this.project = projecttoview
  }

  async SetProjectOwner(ownerid : string) {
      let projectowner: User = await this.backend.GetProjectOwnerInfo(ownerid)
      this.projectowner = projectowner
  }

  GoDonate() {
    if (this.projectid != null) {
      this.router.navigate(['/donation', this.projectid])
    }
  }


  protected readonly environment = environment;
}
