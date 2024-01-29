import { Injectable } from '@angular/core';
import axios from "axios";
import {Project} from "../../Data/Models/Project";
import {News} from "../../Data/Models/News";
import {User} from "../../Data/Models/User";
import environment from "../../../environments/environment";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class BackendService {

  constructor(private http : HttpClient) { }

  GetProjects() {
    return this.http.get(environment.backendurl + `/Projects/GetProject/GetProjects`)
  }

  async GetProject(projectid : string) {
    let response = await axios.get(environment.backendurl + `/Projects/GetProject/${projectid}`)
    let project : Project = response.data
    return project
  }

  async GetProjectOwnerInfo(ownerid : string) {
    let response = await axios.get(environment.backendurl +  `/Authentication/GetUser/${ownerid}`)
    let user : User = response.data
    return user
  }

  async GetNews() {
    let data = await axios.get(environment.backendurl +  `/News/GetNews`)
    let parsednews : News[] = data.data
    return parsednews
  }

  async AddProjectRequest(projecttoadd : Project, imagestoupload : File[]) {
    let responsecheck = await axios.post(environment.backendurl + '/Projects/AddProject', projecttoadd)

    return responsecheck
  }

  async RemoveProject(projectid : string) {
    let response = await axios.post(environment.backendurl + '/Projects/RemoveProject', projectid)
    if (response.data == true) {
      return true
    }
    else {
      return false
    }
  }









}
