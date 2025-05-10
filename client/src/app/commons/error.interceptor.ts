import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { catchError } from 'rxjs';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const router = inject(Router);
  const toastr = inject(ToastrService);
  return next(req).pipe(
    catchError((error) => {
      if (!error) throw error;
      const { status, error: { errors } } = error;
      switch (status) {
        case 400:
          if (errors) {
            throw Object.values(errors).flat();
          }
          break;
        case 401:
          toastr.error('Unauthorized', status);
          break;
        case 404:
          router.navigateByUrl('/not-found');
          break;
        case 500:
          router.navigateByUrl('/server-error', { state: { error: error.error } });
          break;
        default:
          toastr.error('Something unexpected went wrong');
      }
      throw error;
    })
  );
};
