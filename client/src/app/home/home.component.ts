import { Component } from '@angular/core';
import { RegisterComponent } from "../accounts/register.component";

@Component({
  selector: 'app-home',
  imports: [RegisterComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  registerMode = false;

  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }
}
