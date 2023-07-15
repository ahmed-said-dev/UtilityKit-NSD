import { Injectable } from '@angular/core';
import Swal, { SweetAlertIcon } from 'sweetalert2';

@Injectable({
  providedIn: 'root',
})
export class SwalService {
  constructor() {}

  deleteConfirmation(objectName: string, callback: () => void) {
    this.confirmation(
      '',
      `Are you sure you want to delete (${objectName})?`,
      callback
    );
  }

  confirmation(
    title: string,
    text: string,
    callback: () => void,
    icon?: SweetAlertIcon
  ) {
    const swalWithBootstrapButtons = Swal.mixin({
      customClass: {
        confirmButton: 'btn btn-info',
        cancelButton: 'btn btn-danger',
        popup: 'bg-body',
      },
      buttonsStyling: false,
    });
    swalWithBootstrapButtons
      .fire({
        showCloseButton: false,
        title: title,
        text: text,
        icon: icon ? icon : 'error',

        showCancelButton: true,
        confirmButtonText: 'Yes',
        cancelButtonText: 'No',
        reverseButtons: false,
      })
      .then((result) => {
        if (result.value) {
          callback();
          return;
        }
      });
  }

  async dataConfirmation(title: string, callback: (data: string) => void) {
    const { value: formValue } = await Swal.fire({
      customClass: {
        popup: 'bg-body',
      },
      title: title,
      html: '<input id="swal-input1" class="swal2-input">',
      showConfirmButton: true,
      showCancelButton: true,
      confirmButtonText: 'Confirm',
      cancelButtonText: 'Cancel',
      focusConfirm: false,
      preConfirm: () => {
        return (document.getElementById('swal-input1') as HTMLInputElement)
          .value;
      },
    });

    if (formValue) {
      callback(formValue);
    }
  }
}
