import {User} from "./User";

export interface Project {
  projectId : string
  projectname : string
  projectdesc :string
  email : string
  socialmedia : string[]
  userowner? : User
}
