import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthToken } from './model/loginDto/authToken';
import { AccountService } from './service/account.service';
import { BackendService } from './util/backend.service';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title = 'TsogosunProfileAdmin';
  user: AuthToken;
  appVersion = environment.version;

  constructor(private router: Router,
    private backend: BackendService,
    private accountService: AccountService) {

      this.accountService.user.subscribe(x => this.user = x);
  }

  get busy() {
    return this.backend.busy;
  }

  goToPage(routeName) {
    this.router.navigate([routeName]);
  }

  logout() {
    this.accountService.logout();
  }
}
