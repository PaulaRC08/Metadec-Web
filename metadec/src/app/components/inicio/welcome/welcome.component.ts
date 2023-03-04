import { Component, ViewChild } from '@angular/core';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.scss'],

})
export class WelcomeComponent {


  public descarga(): void{
    console.log("holaxd");
    window.open("https://mailunicundiedu-my.sharepoint.com/:f:/g/personal/parodriguezcuervo_ucundinamarca_edu_co/ErVOrMs6y0xCtNorU4pc7BEBKgUiS0ixb00Lay6XYiMWbQ?e=WjDoqV", '_blank');
  }
}
