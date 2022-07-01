import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { LeaderBoardStrapi } from 'src/app/model/Dtos/profile-admin/strapiContent/leaderBoardStrapi';
import { LeaderBoardStrapiService } from 'src/app/service/profile-admin/leader-board-strapi.service';

@Component({
  selector: 'app-leaderboard-strapi-images',
  templateUrl: './leaderboard-strapi-images.component.html',
  styleUrls: ['./leaderboard-strapi-images.component.css']
})
export class LeaderboardStrapiImagesComponent implements OnInit {

  modalTitle: string;
  leaderBoardStrapiImages: LeaderBoardStrapi[] = [];
  siteId: string;
  showNoResultsMessage: Boolean = false;
  resultsMessage: string = "";

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    private leaderBoardStrapiService: LeaderBoardStrapiService) {
    this.modalTitle = data.title;
    this.siteId = data.message;
  }

  async ngOnInit() {
    this.showNoResultsMessage = false;
    this.leaderBoardStrapiImages = await this.leaderBoardStrapiService.getLeaderBoardStrapiImagesByUnit(this.siteId);
    if (this.leaderBoardStrapiImages?.length == 0) {
      this.showNoResultsMessage = true;
      this.resultsMessage = "Strapi contents is not configured.";
    }
  }

  async setImage(imgUrl: string) {
    this.data.results = imgUrl;
  }
}

