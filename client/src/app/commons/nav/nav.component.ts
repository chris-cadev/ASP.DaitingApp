import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../accounts/account.service';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [FormsModule, BsDropdownModule],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.scss'
})
export class NavComponent {
  accountService = inject(AccountService);
  model: any = {};
  login() {
    this.accountService.login(this.model).subscribe({
      next: response => {
        console.log(response)
      },
      error: console.log
    });
  }

  logout() {
    this.accountService.logout();
  }
}
