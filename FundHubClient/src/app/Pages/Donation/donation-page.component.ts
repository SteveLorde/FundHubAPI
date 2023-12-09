import {Component, signal} from '@angular/core';
import {Project} from "../../Data/Models/Project";
import {selectedproject} from "../../Services/GlobalMemoryStorage";
import {FormControl, FormGroup, ReactiveFormsModule} from "@angular/forms";


@Component({
  selector: 'app-donation-page',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './donation-page.component.html',
  styleUrl: './donation-page.component.scss'
})
export class DonationPageComponent {

  public project = signal<Project>({
    currentfund: 0,
    subtitle: "",
    totalfundrequired: 0,
    email: "", id: "", description: "", title: "", socialmedia: []})
  public donationreceiptnumber : string = ''
  public donationamountview : number = 0

  constructor() {
    this.GetSelectedProject()
  }

  ngOnInit() {
    this.donationreceiptnumber = this.GenerateDonationNumber()
  }

  donationform = new FormGroup({
    paymenttype: new FormControl(''),
    donationamount: new FormControl(''),
  })

  GetSelectedProject() {
    this.project.set(selectedproject)
  }

  SubmitDonation() {

  }

  GenerateDonationNumber() {
    const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    let result = '';

    for (let i = 0; i < 50; i++) {
      const randomIndex = Math.floor(Math.random() * characters.length);
      result += characters.charAt(randomIndex);
    }
    return result;
  }

}
