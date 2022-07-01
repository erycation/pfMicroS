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
  selector: 'app-gaming-points',
  templateUrl: './gaming-points.component.html',
  styleUrls: ['./gaming-points.component.css']
})
export class GamingPointsComponent implements OnInit {

  @Input() tsogosunId: string;
  @Input() patronNumber: string;
  user: AuthToken;
  userSites: SiteDto[] = [];
  patronSites: PatronSitesDto[] = [];
  
  constructor(private accountService: AccountService,
              private sharedFunction : SharedFunction,
              private route: ActivatedRoute,
              private patronService : PatronService) {    
                
                  this.user = this.accountService.userValue;
                  this.userSites = this.sharedFunction.getUserSitesBySection(this.user, SectionUtility.personalDetails);

               }

  async ngOnInit() {

    (await this.patronService.getPatronActiveSitesByUserSites(this.tsogosunId, this.userSites)).subscribe(result => {

      this.patronSites = result;

    });
  }
}
