import {Component, OnInit, signal} from '@angular/core';
import {NgForOf, NgIf} from "@angular/common";
import {Project} from "../../Data/Models/Project";
import {User} from "../../Data/Models/User";
import {BackendService} from "../../Services/Backend/backend.service";
import {AuthenticationService} from "../../Services/Authentication/authentication.service";
import {FormControl, FormGroup, ReactiveFormsModule} from "@angular/forms";
import {FundRequestFormComponent} from "../FundProjectForm/fund-request-form.component";
import {Donation} from "../../Data/Models/Donation";

@Component({
  selector: 'app-user-panel',
  standalone: true,
  imports: [
    NgIf,
    ReactiveFormsModule,
    NgForOf,
    FundRequestFormComponent
  ],
  templateUrl: './user-panel.component.html',
  styleUrl: './user-panel.component.scss'
})
export class UserPanelComponent implements OnInit{
  userownsproject : boolean = false;

  public project : Project = {
    category: {id: "", name: ""},
    currentfund: 0, description: "", id: "", subtitle: "", title: "", totalfundrequired: 0}
  public user : User = {usertype: "", description: "", id: "", password: "", username: ""}
  edituserinfo : boolean = false
  editprojectinfo : boolean = false
  openprojectform : boolean = false
  userdonations : Donation[] = []

  constructor(private auth : AuthenticationService, private backend : BackendService) {

  }

  ngOnInit() {
    this.SetUser()
    this.SetProject()
  }

  userform = new FormGroup({
    username: new FormControl(''),
    description: new FormControl(''),
    facebook: new FormControl(''),
    instagram: new FormControl(''),
    phonenumber: new FormControl(''),
    email: new FormControl(''),
  });

  projectform = new FormGroup({
    projectname: new FormControl(''),
    description: new FormControl(''),
    facebook: new FormControl(''),
    instagram: new FormControl(''),
    phonenumber: new FormControl(''),
    email: new FormControl(''),
  });

  OpenFundForm() {
    this.openprojectform = true
  }

  RemoveProject() {
    this.backend.RemoveProject(this.project.id)
  }

  async SetUser() {
    this.user = await this.auth.GetActiveUser()
  }

  SetProject() {
    if (this.user.project != null) {
      this.project = this.user.project
    }
  }

  onFileSelected(e : any) {

  }

}
