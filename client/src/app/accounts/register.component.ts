import { Component, inject, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from './account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  private accountService = inject(AccountService);
  private toastr = inject(ToastrService);
  cancel = output<boolean>();
  model: any = {};

  handleSubmit() {
    this.accountService.register(this.model).subscribe({
      next: response => {
        console.log(response);
        this.cancel.emit(false)
      },
      error: ({ error }) => this.toastr.error(error.title),
    });
  }

  handleCancel() {
    this.cancel.emit(false);
  }
}
