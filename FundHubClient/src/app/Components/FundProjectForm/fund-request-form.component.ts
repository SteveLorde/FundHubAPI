import { Component } from '@angular/core';
import {NgForOf} from "@angular/common";
import {FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators} from "@angular/forms";
import {Project} from "../../Data/Models/Project";
import {User} from "../../Data/Models/User";
import {AuthenticationService} from "../../Services/Authentication/authentication.service";
import {BackendService} from "../../Services/Backend/backend.service";
import {Category} from "../../Data/Models/Category";

@Component({
  selector: 'app-fund-request-form',
  standalone: true,
  imports: [
    NgForOf,
    FormsModule,
    ReactiveFormsModule
  ],
  templateUrl: './fund-request-form.component.html',
  styleUrl: './fund-request-form.component.scss'
})
export class FundRequestFormComponent {

  imagestoupload : File[] = []
  imagesurls : string[] = []
  categories: Category[] = []

  constructor(private auth: AuthenticationService, private backend: BackendService) {
  }

  newprojectform = new FormGroup({
    title: new FormControl('', Validators.required),
    description: new FormControl('', Validators.required),
    totalfundrequired: new FormControl(0, Validators.required),
    category: new FormControl( null, Validators.required),
    instagram: new FormControl(''),
    facebook: new FormControl(''),
    x: new FormControl(''),
    email: new FormControl(''),
  });

  async SubmitNewProject() {
    //1-create project object and add in back
    let newproject : Project = {} as Project
    let formvalues = this.newprojectform.value
    {
      newproject.title = formvalues.title as string
      newproject.totalfundrequired = formvalues.totalfundrequired as number
      newproject.user = await this.auth.GetActiveUser()
      if (formvalues.category != undefined) {
        newproject.category = formvalues.category
      }
      newproject.email = formvalues.email as string
      for (let i = 0; i < this.imagestoupload.length; i++) {
        newproject.images?.push(this.imagestoupload[i].name)
      }

    }
    let projectid = this.backend.AddProjectRequest(newproject, this.imagestoupload)

    //3-return true
    return true
  }

  onFileChange(event: any) {
    const fileList: FileList = event.target.files;
    if (fileList.length > 0) {
      for (let i = 0; i < fileList.length; i++) {
        const file: File = fileList[i];
        this.imagestoupload.push(file)
        this.readImageFile(file)
      }
    }
  }

  readImageFile(file: File) {
    const reader = new FileReader()
    reader.readAsDataURL(file);
    reader.onload = (e: any) => {
      this.imagesurls.push(e.target.result)
    }
  }



}
