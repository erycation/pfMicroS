import { Router } from "@angular/router";
import { GMSPipPepStatusDto } from "../model/Dtos/ms-patron-details/gmsPipPepStatusDto";
import { IGTConfirmStatusDto } from "../model/Dtos/ms-patron-details/igtConfirmStatusDto";
import { AuthToken } from "../model/loginDto/authToken";
import { SiteDto } from "../model/loginDto/siteDto";
import { AccountService } from "../service/account.service";
import { SharedFunction } from "./shared-function";

export class ModalResetParams {    
    
    startDate: Date;
    endDate: Date;
    bsValue = new Date;
    todayDate = new Date();
    siteFullName: string;
    startDateTime: string;
    user: AuthToken;
    userSites: SiteDto[] = [];
    loading = false;
    public showNoResultsMessage: boolean | undefined;
    public resultsMessage: string | undefined;
    public showNoResultsMessagePlaceOnHoldTab: boolean | undefined;
    public resultsMessagePlaceOnHoldTab: string | undefined;
    public addressErrorMessage: string | undefined;
    public igtSites = [1, 2, 3, 6, 8, 9]; //sites using igt

    constructor(private accountService: AccountService,
        private sharedFunction: SharedFunction,
        private router: Router,
        sectionName: string) {
        this.user = this.accountService.userValue;
        this.userSites = this.sharedFunction.getUserSitesBySection(this.user, sectionName)
        this.resetValidationFields();
    }

    public goToPageNoParams(pageName: string): void {
        this.router.navigate([pageName]);
    }

    public goToPageOneParams(pageName: string, param1: any): void {
        this.router.navigate([pageName, param1]);
    }

    public goToPageTwoParams(pageName: string, param1: any, param2): void {
        this.router.navigate([pageName, param1, param2]);
    }

    public goToPageThreeParams(pageName: string, param1: any, param2: any, param3: any): void {
        this.router.navigate([pageName, param1, param2, param3]);
    }

    public goToPageFourParams(pageName: string, param1: any, param2: any, param3: any, param4: any): void {
        this.router.navigate([pageName, param1, param2, param3, param4]);
    }

    public canViewPatronDetails(userSites: SiteDto[], siteId: number): Boolean {
        return this.sharedFunction.canViewPatronDetails(userSites,siteId);
    }

    public resetValidationFields(): void {
        this.showNoResultsMessage = false;
        this.resultsMessage = "";
        this.showNoResultsMessagePlaceOnHoldTab = false;
        this.resultsMessagePlaceOnHoldTab = "";
    }

    public displayNoResultsMessage(): void {
        this.resultsMessage = "No results found.";
        this.showNoResultsMessage = true;
    }

    public displayPlaceOnHoldNoResultsMessage(): void {
        this.resultsMessagePlaceOnHoldTab = "No results found.";
        this.showNoResultsMessagePlaceOnHoldTab = true;
    }

    public canRemoveSectionFromUnit(sectionName: string, siteId: number): Boolean {
        return this.sharedFunction.canRemoveSectionUnit(this.user, sectionName, siteId);
    }

    public displayAddressErrorMessage(isAddressCorrect: boolean): void {
        this.addressErrorMessage = !isAddressCorrect ? `*Not found, please correct the data or request data to be added to the gaming system` : ``;
    }

    public getGMSPipPepStatus: GMSPipPepStatusDto[] =
        [{
            pipPepStatusId: 0, pipPepStatusActive: true, pipPepStatusDesc: 'Confirmed Yes'
        },
        {
            pipPepStatusId: 1, pipPepStatusActive: true, pipPepStatusDesc: 'Confirmed No'
        },
        {
            pipPepStatusId: 2, pipPepStatusActive: true, pipPepStatusDesc: 'Unconfirmed'
        }]

    public documentNotExpired()
    {
        var expiredDate = new Date();
        expiredDate.setFullYear(expiredDate.getFullYear() + 2000);
         return expiredDate;
    }

    public getIGTConfirmStatusDto: IGTConfirmStatusDto[] =
    [{
        statusId: 'Y', statusDesc: 'Yes'
    },
    {
        statusId: 'N', statusDesc: 'No'
    }];

    public formatDate(date: Date) : string
    {
        return this.sharedFunction.formatDateExtention(date)
    }

    public getUserSitesBySection(user: AuthToken, sectionName: string): SiteDto[] {
        return this.sharedFunction.getUserSitesBySection(user, sectionName)
    }
}
