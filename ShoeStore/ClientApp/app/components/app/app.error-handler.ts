import { ErrorHandler, Inject, NgZone } from "@angular/core";
import { ToastyService } from "ng2-toasty";

export class AppErrorHandler implements ErrorHandler {

    constructor(
        @Inject(NgZone) private ngZone: NgZone,
        @Inject(ToastyService) private toastyService: ToastyService) {
    }

    handleError(error: any): void {
        this.ngZone.run(() => {
            if (typeof (window) !== 'undefined') {
                console.log(error);
                this.toastyService.error({
                    title: 'Error',
                    msg: error,//'An unexpected error happened.',
                    theme: 'bootstrap',
                    showClose: true,
                    timeout: 5000
                });
            }
        });

    }
}