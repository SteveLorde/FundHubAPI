import {User} from "./User";

export interface Project {
  id : string
  title : string
  subtitle :string
  description :string
  category : string
  currentfund : number
  totalfundrequired : number
  email? : string
  socialmedia? : string[]
  images? : string[]
  userId? : string
  userowner? : User
}
