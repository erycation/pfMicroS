import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthToken } from '../model/loginDto/authToken';
import { AccountService } from '../service/account.service';

@Component({
  selector: 'app-scratch-card',
  templateUrl: './scratch-card.component.html',
  styleUrls: ['./scratch-card.component.css']
})
export class ScratchCardComponent implements OnInit {

  user: AuthToken;

  constructor(private accountService: AccountService,
              private router: Router) { 

      this.user = this.accountService.userValue;
    }

  ngOnInit(): void {
  }

  async goToPage(pagename :string)
  {
    await this.router.navigate([pagename]);
  }
}
