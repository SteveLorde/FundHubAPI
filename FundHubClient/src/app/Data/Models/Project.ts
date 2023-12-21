import {User} from "./User";
import {SocialMedia} from "./SocialMedia";

export interface Project {
  id : string
  title : string
  subtitle :string
  description :string
  category : string
  currentfund : number
  totalfundrequired : number
  email? : string
  socialmedia? : SocialMedia
  images? : string[]
  userId? : string
  userowner? : User
}
