import { Injectable } from '@angular/core';
import { BackendService } from 'src/app/util/backend.service';


@Injectable({
    providedIn: 'root'
})
export class OTPService {

    constructor(private backend: BackendService) {

    }

    async canAuditUserViewOTPNumber(otpNumber : number) {
        return await this.backend.get<Boolean>(`Audit/Otp/${otpNumber}`);
    } 
  
}

