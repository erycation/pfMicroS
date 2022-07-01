import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { PatronListComponent } from './patron-list/patron-list.component';
import { PatronDetailComponent } from './patron-detail/patron-detail.component';
import { AuthGuard } from './_guards/auth.guard';
import { UserSearchComponent } from './user-search/user-search.component';
import { AddUserComponent } from './user-search/add-user/add-user.component';
import { ModifyUserComponent } from './user-search/modify-user/modify-user.component';
import { ScratchCardComponent } from './scratch-card/scratch-card.component';
import { UpdateScratchCardComponent } from './scratch-card/update-scratch-card/update-scratch-card.component';
import { AddScratchCardComponent } from './scratch-card/add-scratch-card/add-scratch-card.component';
import { DashboardScratchCardComponent } from './scratch-card/dashboard-scratch-card/dashboard-scratch-card.component';
import { LeaderboardComponent } from './leaderboard/leaderboard.component';
import { AddLeaderboardComponent } from './leaderboard/add-leaderboard/add-leaderboard.component';
import { AddGroupLeaderboardComponent } from './leaderboard/add-group-leaderboard/add-group-leaderboard.component';
import { UpdateLeaderboardComponent } from './leaderboard/update-leaderboard/update-leaderboard.component';
import { UpdateGroupLeaderboardComponent } from './leaderboard/update-group-leaderboard/update-group-leaderboard.component';
import { AuditLogsComponent } from './audit-logs/audit-logs.component';
import { PatronDetailsComponent } from './patron/patron-details/patron-details.component';
import { UpdatePatronDetailsGamesmartComponent } from './patron/patron-details/update-patron-details-gamesmart/update-patron-details-gamesmart.component';
import { ApprovedSubmitToGamesmartComponent } from './patron/patron-details/update-patron-details-gamesmart/approved-submit-to-gamesmart/approved-submit-to-gamesmart.component';
import { UpdatePatronDetailsIgtComponent } from './patron/patron-details/update-patron-details-igt/update-patron-details-igt.component';
import { ApprovedSubmitToIgtComponent } from './patron/patron-details/update-patron-details-igt/approved-submit-to-igt/approved-submit-to-igt.component';

const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'patron-list', component: PatronListComponent, canActivate: [AuthGuard] },  
  { path: 'patron-detail/:tsogosunId', component: PatronDetailComponent, canActivate: [AuthGuard] },
  { path: 'user-search', component: UserSearchComponent, canActivate: [AuthGuard] },
  { path: 'add-user', component: AddUserComponent, canActivate: [AuthGuard] },
  { path: 'modify-user/:userId', component: ModifyUserComponent, canActivate: [AuthGuard] },
  { path: 'scratch-card', component: ScratchCardComponent, canActivate: [AuthGuard] },
  { path: 'add-scratch-card', component: AddScratchCardComponent, canActivate: [AuthGuard] },  
  { path: 'modify-scratch-card/:siteId/:scratchCardId', component: UpdateScratchCardComponent, canActivate: [AuthGuard] },
  { path: 'dashboard-scratch-card', component: DashboardScratchCardComponent, canActivate: [AuthGuard] },
  { path: 'leaderboard', component: LeaderboardComponent, canActivate: [AuthGuard] },
  { path: 'add-leaderboard', component: AddLeaderboardComponent, canActivate: [AuthGuard] },
  { path: 'add-group-leaderboard', component: AddGroupLeaderboardComponent, canActivate: [AuthGuard] },
  { path: 'modify-leaderboard/:siteId/:promotionId', component: UpdateLeaderboardComponent, canActivate: [AuthGuard] },
  { path: 'modify-group-leaderboard/:siteId/:promotionId', component: UpdateGroupLeaderboardComponent, canActivate: [AuthGuard] },
  { path: 'audit-logs', component: AuditLogsComponent, canActivate: [AuthGuard] },
  { path: 'patron-details', component: PatronDetailsComponent, canActivate: [AuthGuard] },  
  { path: 'update-patron-details-igt/:siteId/:userId', component: UpdatePatronDetailsIgtComponent, canActivate: [AuthGuard] },
  { path: 'update-patron-details-gamesmart/:siteId/:userId', component: UpdatePatronDetailsGamesmartComponent, canActivate: [AuthGuard] },
  { path: 'approved-submit-gamesmart/:siteId/:userId', component: ApprovedSubmitToGamesmartComponent, canActivate: [AuthGuard] },
  { path: 'approved-submit-igt/:siteId/:userId', component: ApprovedSubmitToIgtComponent, canActivate: [AuthGuard] },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
