import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AccountService } from './account.service';
import { ToastrService } from 'ngx-toastr';
import { isNil } from '../commons/common.utils';

export const authGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountService);
  if (isNil(accountService.user)) {
    const toastr = inject(ToastrService);
    toastr.error('You shall not pass!');
  }
  return Boolean(accountService.user);
};
