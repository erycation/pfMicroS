import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpRequest, HttpHandler } from "@angular/common/http";
import { AccountService } from "../service/account.service";


@Injectable()

export class AuthInterceptor implements HttpInterceptor {
    
    constructor(private accountService: AccountService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler) {

        const authToken = this.accountService?.userValue?.token;
        const userSessionId = this.accountService?.userValue?.userSessionId;

        if (authToken != null) {
            req = req.clone({
                setHeaders: {
                    Authorization: "Bearer " + authToken
                }
            });
        }

        if (userSessionId != null) {

            req = req.clone({headers: req.headers.set('userSessionId', userSessionId)});

        }

        return next.handle(req);
    }
}