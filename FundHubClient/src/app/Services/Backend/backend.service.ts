import { Injectable } from '@angular/core';
import axios from "axios";
import {Project} from "../../Data/Models/Project";
import {News} from "../../Data/Models/News";

@Injectable({
  providedIn: 'root'
})
export class BackendService {

  constructor() { }

  async GetProjects() {
    let projects : Project[] = await axios.get('http://localhost:5116')
    return projects
  }

  async GetProject(projectid : string) {
    let project : Project = await axios.get(`http://localhost:5116/Projects/GetProject/${projectid}`)
    return project
  }

  async GetNews() {
    let data = await axios.get(`http://localhost:5116/News/GetNews`)
    let parsednews : News[] = data.data
    return parsednews
  }

  async AddProjectRequest(projecttoadd : Project) {
    let responsecheck = await axios.post('http://localhost:5116/Projects/AddProject', projecttoadd)
    return responsecheck
  }









}
