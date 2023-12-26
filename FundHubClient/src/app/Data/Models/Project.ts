import {User} from "./User";
import {SocialMedia} from "./SocialMedia";
import {Category} from "./Category";

export interface Project {
  id : string
  title : string
  subtitle :string
  description :string
  category : Category
  currentfund : number
  totalfundrequired : number
  email : string
  images : string[]
  userId : string
  user : User
}
