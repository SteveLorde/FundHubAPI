import {Project} from "./Project";

export interface User {
  userId : string | number
  username : string
  password : string
  description : string
  phonenumber? : string
  email? : string
  socialmedia? : string[]
  projects? : Project[]

}
