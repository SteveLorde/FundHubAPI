import {Component, signal} from '@angular/core';
import {NgIf} from "@angular/common";
import {Project} from "../../Data/Models/Project";
import {User} from "../../Data/Models/User";

@Component({
  selector: 'app-user-panel',
  standalone: true,
  imports: [
    NgIf
  ],
  templateUrl: './user-panel.component.html',
  styleUrl: './user-panel.component.scss'
})
export class UserPanelComponent {
  userownsproject : boolean = false;

  public project= signal<Project>({
    currentfund: 0, images: [], subtitle: "", totalfundrequired: 0, userowner: {} as User,
    email: "", id: "", description: "", title: ""
  })

  constructor() {

  }

  ngOnInit() { }

}
