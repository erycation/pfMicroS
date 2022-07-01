import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  NgbAccordionModule,
  NgbDatepickerModule,
  NgbDropdownModule,
  NgbModalModule,
  NgbNavModule,
  NgbPaginationModule,
  NgbTimepickerModule,
  NgbModule
} from '@ng-bootstrap/ng-bootstrap';
import { TimepickerModule } from 'ngx-bootstrap/timepicker';
import { DatepickerModule, BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { JwPaginationModule } from 'jw-angular-pagination';
import { NgSelectModule } from '@ng-select/ng-select';
import { MatCardModule } from '@angular/material/card';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatRadioModule } from '@angular/material/radio';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDialogModule } from '@angular/material/dialog';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PaginationComponent } from './util/pagination/pagination.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { PatronDetailComponent } from './patron-detail/patron-detail.component';
import { PersonalDetailComponent } from './patron-detail/personal-detail/personal-detail.component';
import { OffersComponent } from './patron-detail/offers/offers.component';
import { GamingPointsComponent } from './patron-detail/gaming-points/gaming-points.component';
import { GamingKpisComponent } from './patron-detail/gaming-kpis/gaming-kpis.component';
import { VipComponent } from './patron-detail/vip/vip.component';
import { PersonalDetailTsgComponent } from './patron-detail/personal-detail/personal-detail-tsg/personal-detail-tsg.component';
import { PersonalDetailUnitComponent } from './patron-detail/personal-detail/personal-detail-unit/personal-detail-unit.component';
import { PatronListComponent } from './patron-list/patron-list.component';
import { GamingPointsTsgComponent } from './patron-detail/gaming-points/gaming-points-tsg/gaming-points-tsg.component';
import { GamingPointsUnitComponent } from './patron-detail/gaming-points/gaming-points-unit/gaming-points-unit.component';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { AuthInterceptor } from './shared/authconfig.interceptor';
import { DialogService } from './shared/dialog/dialog.service';
import { ConfirmDialogComponent } from './shared/dialog/confirm-dialog/confirm-dialog.component';
import { AlertErrorDialogComponent } from './shared/dialog/alert-error-dialog/alert-error-dialog.component';
import { UserSearchComponent } from './user-search/user-search.component';
import { AddUserComponent } from './user-search/add-user/add-user.component';
import { ModifyUserComponent } from './user-search/modify-user/modify-user.component';
import { UserSummaryComponent } from './user-search/user-summary/user-summary.component';
import { PatronFreePlayComponent } from './patron-detail/offers/patron-free-play/patron-free-play.component';
import { FreePlayPipe } from './shared/pipes/freeplay.pipes';
import { VoucherPipe } from './shared/pipes/voucher.pipes';
import { GamingTermPipe } from './shared/pipes/gamingterm.pipes';
import { DrawPipe } from './shared/pipes/draw.pipes';
import { PatronScratchCardPipe } from './shared/pipes/patronscratchcard.pipes';
import { ScratchCardWinnersPipe } from './shared/pipes/scratch-card-winners.pipes';
import { MenuListItemComponent } from './shared/menu-list-item/menu-list-item.component';
import { SuccessDialogComponent } from './shared/dialog/success-dialog/success-dialog.component';
import { PatronVoucherComponent } from './patron-detail/offers/patron-voucher/patron-voucher.component';
import { VoucherOtpModalComponent } from './patron-detail/offers/patron-voucher/voucher-otp-modal/voucher-otp-modal.component';
import { FreePlayOtpModalComponent } from './patron-detail/offers/patron-free-play/free-play-otp-modal/free-play-otp-modal.component';
import { GamingKpisUnitComponent } from './patron-detail/gaming-kpis/gaming-kpis-unit/gaming-kpis-unit.component';
import { GamingKpisTsgComponent } from './patron-detail/gaming-kpis/gaming-kpis-tsg/gaming-kpis-tsg.component';
import { DatePipe } from '@angular/common';
import { GamingKpisDefinitionComponent } from './patron-detail/gaming-kpis/gaming-kpis-definition/gaming-kpis-definition.component';
import { PatronDrawComponent } from './patron-detail/offers/patron-draw/patron-draw.component';
import { ScratchCardComponent } from './scratch-card/scratch-card.component';
import { AddScratchCardComponent } from './scratch-card/add-scratch-card/add-scratch-card.component';
import { UpdateScratchCardComponent } from './scratch-card/update-scratch-card/update-scratch-card.component';
import { ActiveScratchCardComponent } from './scratch-card/active-scratch-card/active-scratch-card.component';
import { PatronScratchCardComponent } from './scratch-card/patron-scratch-card/patron-scratch-card.component';
import { DashboardScratchCardComponent } from './scratch-card/dashboard-scratch-card/dashboard-scratch-card.component';
import { ConfigurePriceModalComponent } from './scratch-card/update-scratch-card/list-scratch-card-prizes/configure-price-modal/configure-price-modal.component';
import { ScratchCardWinnersComponent } from './scratch-card/scratch-card-winners/scratch-card-winners.component';
import { UpdateConfigurePriceModalComponent } from './scratch-card/update-scratch-card/list-scratch-card-prizes/update-configure-price-modal/update-configure-price-modal.component';
import { ListScratchCardPrizesComponent } from './scratch-card/update-scratch-card/list-scratch-card-prizes/list-scratch-card-prizes.component';
import { ScratchCardActiveTimesComponent } from './scratch-card/update-scratch-card/scratch-card-active-times/scratch-card-active-times.component';
import { AddActiveDateModalComponent } from './scratch-card/update-scratch-card/scratch-card-active-times/add-active-date-modal/add-active-date-modal.component';
import { UpdateActiveDateModalComponent } from './scratch-card/update-scratch-card/scratch-card-active-times/update-active-date-modal/update-active-date-modal.component';
import { MessageSettingsComponent } from './scratch-card/message-settings/message-settings.component';
import { ScratchCardStrapiImagesComponent } from './scratch-card/scratch-card-strapi-images/scratch-card-strapi-images.component';
import { LeaderboardComponent } from './leaderboard/leaderboard.component';
import { LeaderboardPromotionComponent } from './leaderboard/leaderboard-promotion/leaderboard-promotion.component';
import { AddLeaderboardComponent } from './leaderboard/add-leaderboard/add-leaderboard.component';
import { LeaderboardStrapiImagesComponent } from './leaderboard/leaderboard-strapi-images/leaderboard-strapi-images.component';
import { AddGroupLeaderboardComponent } from './leaderboard/add-group-leaderboard/add-group-leaderboard.component';
import { PatronLeaderboardComponent } from './patron-detail/patron-leaderboard/patron-leaderboard.component';
import { UpdateGroupLeaderboardComponent } from './leaderboard/update-group-leaderboard/update-group-leaderboard.component';
import { UpdateLeaderboardComponent } from './leaderboard/update-leaderboard/update-leaderboard.component';
import { PatronDetailScratchCardComponent } from './patron-detail/patron-detail-scratch-card/patron-detail-scratch-card.component';
import { AuditLogsComponent } from './audit-logs/audit-logs.component';
import { ClearLogsComponent } from './audit-logs/clear-logs/clear-logs.component';
import { LosingImagesComponent } from './scratch-card/scratch-card-strapi-images/losing-images/losing-images.component';
import { WinningImagesComponent } from './scratch-card/scratch-card-strapi-images/winning-images/winning-images.component';
import { BackgroundImagesComponent } from './scratch-card/scratch-card-strapi-images/background-images/background-images.component';
import { TileImagesComponent } from './scratch-card/scratch-card-strapi-images/tile-images/tile-images.component';
import { PatronDetailsComponent } from './patron/patron-details/patron-details.component';
import { IgtPatronSearchAddressComponent } from './patron/patron-details/update-patron-details-igt/igt-patron-search-address/igt-patron-search-address.component';
import { UpdatePatronDetailsGamesmartComponent } from './patron/patron-details/update-patron-details-gamesmart/update-patron-details-gamesmart.component';
import { GamesmartPatronSearchAddressComponent } from './patron/patron-details/update-patron-details-gamesmart/gamesmart-patron-search-address/gamesmart-patron-search-address.component';
import { ApprovedSubmitToGamesmartComponent } from './patron/patron-details/update-patron-details-gamesmart/approved-submit-to-gamesmart/approved-submit-to-gamesmart.component';
import { UpdatePatronDetailsIgtComponent } from './patron/patron-details/update-patron-details-igt/update-patron-details-igt.component';
import { ApprovedSubmitToIgtComponent } from './patron/patron-details/update-patron-details-igt/approved-submit-to-igt/approved-submit-to-igt.component';
import { PatronDetailsApprovedComponent } from './patron/patron-details/patron-details-approved/patron-details-approved.component';
import { PatronDetailsNewRecordComponent } from './patron/patron-details/patron-details-new-record/patron-details-new-record.component';
import { PatronDetailsInProgressComponent } from './patron/patron-details/patron-details-in-progress/patron-details-in-progress.component';

@NgModule({
  declarations: [
    AppComponent,
    FreePlayPipe,
    VoucherPipe,
    GamingTermPipe,
    DrawPipe,
    PatronScratchCardPipe,
    ScratchCardWinnersPipe,
    PaginationComponent,
    LoginComponent,
    HomeComponent,
    PatronDetailComponent,    
    PersonalDetailComponent,
    OffersComponent,
    GamingPointsComponent,
    GamingKpisComponent,
    VipComponent,
    PersonalDetailTsgComponent,
    PersonalDetailUnitComponent,
    PersonalDetailTsgComponent,
    PersonalDetailUnitComponent,
    PatronListComponent,
    GamingPointsTsgComponent,
    GamingPointsUnitComponent,
    ConfirmDialogComponent,
    AlertErrorDialogComponent,
    UserSearchComponent,
    AddUserComponent,
    ModifyUserComponent,
    UserSummaryComponent,
    PatronFreePlayComponent,
    MenuListItemComponent,
    SuccessDialogComponent,
    PatronVoucherComponent,
    VoucherOtpModalComponent,
    FreePlayOtpModalComponent,
    GamingKpisUnitComponent,
    GamingKpisTsgComponent,
    GamingKpisDefinitionComponent,
    PatronDrawComponent,
    ScratchCardComponent,
    AddScratchCardComponent,
    UpdateScratchCardComponent,
    ActiveScratchCardComponent,
    PatronScratchCardComponent,
    DashboardScratchCardComponent,
    ConfigurePriceModalComponent,
    ScratchCardWinnersComponent,
    UpdateConfigurePriceModalComponent,    
    ListScratchCardPrizesComponent, 
    ScratchCardActiveTimesComponent, 
    AddActiveDateModalComponent, 
    UpdateActiveDateModalComponent,
    MessageSettingsComponent, 
    ScratchCardStrapiImagesComponent,
    LeaderboardComponent,
    LeaderboardPromotionComponent,
    AddLeaderboardComponent,
    LeaderboardStrapiImagesComponent,
    AddGroupLeaderboardComponent,
    PatronLeaderboardComponent,
    UpdateGroupLeaderboardComponent,
    UpdateLeaderboardComponent,
    PatronDetailScratchCardComponent,
    AuditLogsComponent,
    ClearLogsComponent,
    TileImagesComponent,
    LosingImagesComponent,
    WinningImagesComponent,
    BackgroundImagesComponent,
    PatronDetailsComponent,
    IgtPatronSearchAddressComponent,
    GamesmartPatronSearchAddressComponent,
    UpdatePatronDetailsGamesmartComponent,
    ApprovedSubmitToGamesmartComponent,
    UpdatePatronDetailsIgtComponent,
    ApprovedSubmitToIgtComponent,
    PatronDetailsApprovedComponent,
    PatronDetailsNewRecordComponent,
    PatronDetailsInProgressComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,    
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgbAccordionModule,    
    NgbDatepickerModule,
    NgbDropdownModule,
    NgbModalModule,
    NgbNavModule,
    NgbPaginationModule,
    NgbTimepickerModule,   
    NgbModule,
    NoopAnimationsModule,
    JwPaginationModule,
    NgSelectModule,
    MatExpansionModule,
    MatCardModule,
    MatListModule,
    MatSidenavModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule,
    MatButtonModule,
    MatRadioModule,
    MatCheckboxModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatDialogModule,
    BsDatepickerModule.forRoot(),
    DatepickerModule.forRoot(),
    TimepickerModule.forRoot() 
  ],
  exports: [
            MatExpansionModule, MatCardModule, MatListModule, 
            MatSidenavModule, MatIconModule, MatInputModule, MatFormFieldModule, 
            MatButtonModule, MatRadioModule, MatDatepickerModule, MatNativeDateModule,
            MatDialogModule
          ],
  providers: [ 
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
    DialogService,
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
