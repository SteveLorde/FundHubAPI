import {Component, ElementRef, QueryList, ViewChild, ViewChildren} from '@angular/core';
import {News} from "../../Data/Models/News";
import axios from "axios";
import {NgForOf} from "@angular/common";
import {BackendService} from "../../Services/Backend/backend.service";
import {Project} from "../../Data/Models/Project";
import {RouterLink, RouterLinkActive} from "@angular/router";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-home-page',
  standalone: true,
  imports: [
    NgForOf,
    RouterLink,
    RouterLinkActive
  ],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.scss'
})
export class HomePageComponent {

  public allnews : News[] = []
  // @ts-ignore
  @ViewChildren('newsimage') imageElements: QueryList<ElementRef>;
  fallbackImageUrl: string = 'assets/nullimage.png'

  constructor(private backend: BackendService) {
    this.GetNews()
  }

  ngoninit() {
    this.GetNews()
  }

  async GetNews() {
    let news : News[] = await this.backend.GetNews()
    this.allnews = news
  }

  handleImageError(news : News): void {
    const targetImageElement = this.imageElements.find((el: { nativeElement: { id: string; }; }) => el.nativeElement.id === `image-${news.id}`);
    if (targetImageElement) {
      targetImageElement.nativeElement.src = this.fallbackImageUrl;
    }
  }

}
