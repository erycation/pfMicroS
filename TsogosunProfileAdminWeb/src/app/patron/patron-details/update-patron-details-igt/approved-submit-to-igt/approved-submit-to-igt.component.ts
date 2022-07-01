import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IGTConfirmedPatronDetailsDto } from 'src/app/model/Dtos/ms-patron-details/igtConfirmedPatronDetailsDto';
import { IGTCountryDto } from 'src/app/model/Dtos/ms-patron-details/igt-config/igtCountryDto';
import { AccountService } from 'src/app/service/account.service';
import { DialogService } from 'src/app/shared/dialog/dialog.service';
import { ModalResetParams } from 'src/app/shared/modal-reset-params';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';
import { ConfirmPlayerToSubmitGamingDto } from 'src/app/model/Dtos/ms-patron-details/confirmPlayerToSubmitGamingDto';
import { MSPatronDetailsService } from 'src/app/service/ms-patron-details/ms-patron-details.service';
import { IGTConfigurationService } from 'src/app/service/profile-admin/igt-configuration.service';
import { RequestAddUpdatePlayerProfile } from 'src/app/model/request/igt-gaming-system/request-add-updatePlayerProfile';
import { PlayerProfile } from 'src/app/model/igt-gaming-system/playerProfile';
import { CardNumber } from 'src/app/model/igt-gaming-system/cardNumber';
import { Email } from 'src/app/model/igt-gaming-system/email';
import { Employment } from 'src/app/model/igt-gaming-system/employment';
import { Identification } from 'src/app/model/igt-gaming-system/identification';
import { Interest } from 'src/app/model/igt-gaming-system/interest';
import { Languages } from 'src/app/model/igt-gaming-system/languages';
import { Name } from 'src/app/model/igt-gaming-system/name';
import { PhoneNumber } from 'src/app/model/igt-gaming-system/phoneNumber';
import { Ranking } from 'src/app/model/igt-gaming-system/ranking';
import { Restriction } from 'src/app/model/igt-gaming-system/restriction';
import { SiteInfo } from 'src/app/model/igt-gaming-system/siteInfo';
import { Status } from 'src/app/model/igt-gaming-system/status';
import { userIGT } from 'src/app/model/igt-gaming-system/userIGT';
import { Address } from 'src/app/model/igt-gaming-system/address';
import { IGTGamingSystemService } from 'src/app/service/igt-gaming-system/igt-gaming-system.service';
import { IGTEnrolmentConfigService } from 'src/app/service/ms-patron-details/igt-enrolmentConfig.service';
import { IGTEnrolmentConfigDto } from 'src/app/model/Dtos/ms-patron-details/igt-config/igtEnrolmentConfigDto';
import { RegisteredOtherSitesDto } from 'src/app/model/Dtos/mdm-patron/registeredOtherSitesDto';
import { PatronService } from 'src/app/service/mdm-patron/patron.service';

@Component({
  selector: 'app-approved-submit-to-igt',
  templateUrl: './approved-submit-to-igt.component.html',
  styleUrls: ['./approved-submit-to-igt.component.css']
})
export class ApprovedSubmitToIgtComponent extends ModalResetParams implements OnInit {

  igtConfirmedPatronDetailsDto = {} as IGTConfirmedPatronDetailsDto;
  igtEnrolmentConfigDto = {} as IGTEnrolmentConfigDto;
  birthDate:string;
  dateRequested:string;
  igtCountryDto = {} as IGTCountryDto;
  confirmPlayerToSubmitGamingDto = {} as ConfirmPlayerToSubmitGamingDto;
  registeredOtherSitesDto = {} as RegisteredOtherSitesDto;
  //Igt    
  requestAddUpdatePlayerProfile = {} as RequestAddUpdatePlayerProfile;
  playerProfile = {} as PlayerProfile;
  ranking = {} as Ranking;
  name = {} as Name;
  enrolledBy = {} as userIGT;
  status = {} as Status;
  employment = {} as Employment;
  languages?: Languages[] = [];
  addresses?: Address[] = [];
  phoneNumbers?: PhoneNumber[] = [];
  identifications?: Identification[] = [];
  emails?: Email[] = [];
  cardNumbers?: CardNumber[] = [];
  playerRestrictions?: Restriction[] = [];
  interests?: Interest[] = [];
  siteParameters?: SiteInfo[] = [];
  showidPassImage: boolean = false;

  constructor(accountService: AccountService,
    sharedFunction: SharedFunction,
    router: Router,
    private route: ActivatedRoute,
    private dialogService: DialogService,
    private mspatronDetailsService : MSPatronDetailsService,
    private igtConfigurationService: IGTConfigurationService,
    private igtGamingSystemService: IGTGamingSystemService,
    private igtEnrolmentConfigService: IGTEnrolmentConfigService,
    private patronService: PatronService) {
    super(accountService,
      sharedFunction,
      router,
      SectionUtility.patronRegistration);
  }
  formatDateSlash1(date) {
    const d = new Date(date);
    let month = '' + (d.getMonth() + 1);
    let day = '' + d.getDate();
    const year = d.getFullYear();
    if (month.length < 2) month = '0' + month;
    if (day.length < 2) day = '0' + day;
    return [year, month, day].join('/');
  }
  

  async ngOnInit() {

    this.dateRequested = new Date().toISOString().slice(0,10);
    this.igtConfirmedPatronDetailsDto = await this.mspatronDetailsService.getConfirmedPatronDetailsFromIGTByUserId(this.route.snapshot.params.userId); 
    this.birthDate = this.formatDate(this.igtConfirmedPatronDetailsDto.birthDate);
    this.igtEnrolmentConfigDto = await this.igtEnrolmentConfigService.getIGTEnrolmentConfigBySiteId(this.route.snapshot.params.siteId);
    this.igtCountryDto = await this.igtConfigurationService.getIGTCountryByName(this.route.snapshot.params.siteId, this.igtConfirmedPatronDetailsDto.country);  
    this.registeredOtherSitesDto = await this.patronService.patronRegisteredOtherSites(this.igtConfirmedPatronDetailsDto.idpassportNO);  
    this.showidPassImage = SharedFunction.checkUndefinedObjectValue(this.igtConfirmedPatronDetailsDto.formatIdPassImage) ? false : true;
    this.igtConfirmedPatronDetailsDto.idpassImage = this.igtConfirmedPatronDetailsDto.formatIdPassImage;
  }

  async createProfileToIGT()
  {    
    if(this.igtCountryDto.countryId == 0)
    {
      this.dialogService.openAlertModal("Alert", `Country ${this.igtConfirmedPatronDetailsDto.country} Not Found in IGT`, () => { });
      return;
    }

    else if (!SharedFunction.checkUndefinedObjectValue(this.igtEnrolmentConfigDto)) {
      this.dialogService.openAlertModal("Alert", "Enrollment not configured, please contact system administrator ", () => { });
      return;
    }

    this.name.firstName = this.igtConfirmedPatronDetailsDto?.firstName;
    this.name.lastName = this.igtConfirmedPatronDetailsDto?.lastName;
    this.name.title = this.igtConfirmedPatronDetailsDto?.title;
    this.name.preferredName = this.igtConfirmedPatronDetailsDto?.firstName;
    this.employment.position = this.igtConfirmedPatronDetailsDto?.occupation;
    this.employment.company = '';
    this.enrolledBy.userID = this.igtEnrolmentConfigDto?.enrolIGTUserID.toString();
    this.enrolledBy.loginName = this.igtEnrolmentConfigDto?.enrolIGTLoginName;
    this.enrolledBy.firstName = this.igtEnrolmentConfigDto?.enrolIGTFirstName;
    this.enrolledBy.lastName = this.igtEnrolmentConfigDto?.enrolIGTLastName;
    this.enrolledBy.license = this.igtEnrolmentConfigDto?.enrolIGTLicense;
    this.status.description = `Active`;
    this.status.text = `A`;
    this.languages.push({language: ''});
    this.identifications.push({
        idNumber: this.igtConfirmedPatronDetailsDto?.idpassportNO,
        type: `SSN`,//to be pull from stored procedure
        country: this.igtConfirmedPatronDetailsDto?.idPassCountry
      });

      this.phoneNumbers.push({
        number: this.igtConfirmedPatronDetailsDto?.mobileNumber,
        location: 'Cell',
        preferred: this.igtConfirmedPatronDetailsDto.preferredPhoneCall ? "true" : "false"
      });  
  
      this.addresses.push({
        address1: this.igtConfirmedPatronDetailsDto?.address1,
        city: this.igtConfirmedPatronDetailsDto?.town,
        stateProvince: this.igtConfirmedPatronDetailsDto?.provDescription,
        suburb: this.igtConfirmedPatronDetailsDto?.area,
        country: this.igtCountryDto.countryId.toString(),
        location: 'Residential',
        deliverable: 'true',
        postalCode: this.igtConfirmedPatronDetailsDto?.postalCode,
        preferred: this.igtConfirmedPatronDetailsDto.preferredPost ? "true" : "false",
        creditAddress: 'Y'
      });
  
      this.emails.push({ 
        address: this.igtConfirmedPatronDetailsDto?.emailAddress,
        location: 'Main Email'
      });
  
      this.ranking.text = this.igtConfirmedPatronDetailsDto.rating.toString();
      this.siteParameters.push({
        siteID: this.route.snapshot.params.siteId,
        ranking: this.ranking
      });

      this.playerProfile.affiliation = '';
      this.playerProfile.exempt = '';
      this.playerProfile.attraction = '';
      this.playerProfile.pipPep = '';
      this.playerProfile.pINLocked = '';
      this.playerProfile.webEnabled = '';
      this.playerProfile.dateEnrolled = new Date().toISOString().slice(0,10);
      this.playerProfile.dateofBirth = SharedFunction.formatDate(this.igtConfirmedPatronDetailsDto.birthDate);
      this.playerProfile.name = this.name;
      this.playerProfile.status = this.status;
      this.playerProfile.gender = this.igtConfirmedPatronDetailsDto?.gender.toLocaleLowerCase() == 'male' ? 'M' : 'F';
      this.playerProfile.nationality = this.igtConfirmedPatronDetailsDto.nationality;
      this.playerProfile.enrolledBy = this.enrolledBy;
      this.playerProfile.employment = this.employment;
      this.playerProfile.identifications = this.identifications;
      this.playerProfile.phoneNumbers = this.phoneNumbers;
      this.playerProfile.addresses = this.addresses;
      this.playerProfile.emails = this.emails;
      this.playerProfile.siteParameters = this.siteParameters;
      this.requestAddUpdatePlayerProfile.siteId = this.route.snapshot.params.siteId;
      this.requestAddUpdatePlayerProfile.playerProfile = this.playerProfile;
      this.loading = true;
    (await this.igtGamingSystemService.createIGTProfileAccount(this.requestAddUpdatePlayerProfile)).subscribe(result => {
      this.dialogService.openSuccessModal("Success", `${result.message}`, () => { });
      this.confirmPlayerToSubmitGaming(Number(this.route.snapshot.params.userId), this.igtConfirmedPatronDetailsDto.confirmedBy);
      this.goToPageNoParams('patron-details');
    },
      error => {
        this.dialogService.openAlertModal("Alert", `${error.error.message}`, () => { });
        this.loading = false;
      });

  }

  async confirmPlayerToSubmitGaming(userDetailId: number, confirmedBy?: string)
  {
    this.confirmPlayerToSubmitGamingDto.userDetailId = userDetailId;
    this.confirmPlayerToSubmitGamingDto.confirmedBy = confirmedBy;
    (await this.mspatronDetailsService.confirmPlayerStatusAfterSubmitGaming(this.confirmPlayerToSubmitGamingDto)).subscribe(result => {
      //this.dialogService.openSuccessModal("Success", `${result.message}`, () => { });
      this.loading = false;
    },
      error => {
        this.dialogService.openAlertModal("Alert", `${error.error.message}`, () => { });
        this.loading = false;
      });
  }

  async redirectToPage(page: string) {
    this.goToPageNoParams(page);
  }
}

