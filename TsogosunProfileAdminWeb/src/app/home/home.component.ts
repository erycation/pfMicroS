import { Component, OnInit } from '@angular/core';
import { AuthToken } from '../model/loginDto/authToken';
import { AccountService } from '../service/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  user: AuthToken;

  constructor(private accountService: AccountService) {

        this.user = this.accountService.userValue;
   }

  ngOnInit(): void {
  }

}
