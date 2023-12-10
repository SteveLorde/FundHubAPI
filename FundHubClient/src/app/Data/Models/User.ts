import {Project} from "./Project";

export interface User {
  id : string | number
  username : string
  password : string
  description : string
  phonenumber? : string
  email? : string
  facebook? : string
  x_socialmedia? : string
  instagram? : string
  project? : Project

}
