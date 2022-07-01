import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ScratchCardStrapi } from 'src/app/model/Dtos/profile-admin/strapiContent/scratchCardStrapi';
import { ScratchCardStrapiService } from 'src/app/service/profile-admin/scratch-card-strapi.service';

@Component({
  selector: 'app-scratch-card-strapi-images',
  templateUrl: './scratch-card-strapi-images.component.html',
  styleUrls: ['./scratch-card-strapi-images.component.css']
})
export class ScratchCardStrapiImagesComponent implements OnInit {

  modalTitle: string;  
  siteId: string;
  showNoResultsMessage: Boolean = false;
  resultsMessage: string = "";
  scratchCardStrapiImages: ScratchCardStrapi[] = [];

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    private scratchCardStrapiService: ScratchCardStrapiService) {

    this.modalTitle = data.title;
    this.siteId = data.message;

  }

  async ngOnInit() {

    this.showNoResultsMessage = false;
    this.scratchCardStrapiImages = await this.scratchCardStrapiService.getScratchCardStrapiImagesByUnit(this.siteId);
    if (this.scratchCardStrapiImages?.length == 0) {
      this.showNoResultsMessage = true;
      this.resultsMessage = "Strapi contents is not configured.";
    }
  }

  async setImage(imgUrl: string) {

    this.data.results = imgUrl;

  }
}
