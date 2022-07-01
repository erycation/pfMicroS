import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PatronSitesDto } from 'src/app/model/Dtos/mdm-patron/patronSitesDto';
import { AuthToken } from 'src/app/model/loginDto/authToken';
import { SiteDto } from 'src/app/model/loginDto/siteDto';
import { AccountService } from 'src/app/service/account.service';
import { PatronService } from 'src/app/service/mdm-patron/patron.service';
import { SectionUtility } from 'src/app/shared/section-utility';
import { SharedFunction } from 'src/app/shared/shared-function';

@Component({
  selector: 'app-personal-detail',
  templateUrl: './personal-detail.component.html',
  styleUrls: ['./personal-detail.component.css']
})
export class PersonalDetailComponent implements OnInit {

  @Input() tsogosunId: string;
  @Input() patronNumber: string;
  user: AuthToken;
  userSites: SiteDto[] = [];
  patronSites: PatronSitesDto[] = [];
  userCanViewTSG: boolean = false;
  
  constructor(private accountService: AccountService,
              private sharedFunction : SharedFunction,
              private route: ActivatedRoute,
              private patronService : PatronService) {    
                
                  this.user = this.accountService.userValue;
                  this.userSites = this.sharedFunction.getUserSitesBySection(this.user, SectionUtility.personalDetails);
                  this.userCanViewTSG = this.userSites.find(s => s.siteID == 0) != null ? true : false;

               }

  async ngOnInit() {
    
    (await this.patronService.getPatronActiveSitesByUserSites(this.tsogosunId, this.userSites)).subscribe(result => {

      this.patronSites = result;

    });
  }
}
