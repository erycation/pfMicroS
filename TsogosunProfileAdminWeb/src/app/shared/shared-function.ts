import { Injectable } from "@angular/core";
import { AuthToken } from "../model/loginDto/authToken";
import { SiteDto } from "../model/loginDto/siteDto";

@Injectable({
    providedIn: 'root'
})
export class SharedFunction {

    constructor() { }

    static checkUndefinedObjectValue(objectItem: any) {
        if (objectItem === undefined || objectItem === null || objectItem === 'null' || objectItem === '')
            return false;
        return true;
    }

    static numberOnly(event): boolean {
        const charCode = (event.which) ? event.which : event.keyCode;
        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        }
        return true;

    }

    static parse(value: any): Date | null {
        if ((typeof value === 'string') && (value.includes('/'))) {
            const str = value.split('/');

            const year = Number(str[2]);
            const month = Number(str[1]) - 1;
            const date = Number(str[0]);

            return new Date(year, month, date);
        } else if ((typeof value === 'string') && value === '') {
            return new Date();
        }
        const timestamp = typeof value === 'number' ? value : Date.parse(value);
        return isNaN(timestamp) ? null : new Date(timestamp);
    }

    static formatDateSlash(date) {
        const d = new Date(date);
        let month = '' + (d.getMonth() + 1);
        let day = '' + d.getDate();
        const year = d.getFullYear();
        if (month.length < 2) month = '0' + month;
        if (day.length < 2) day = '0' + day;
        return [year, month, day].join('/');
    }

    static formatDate(date) {
        const d = new Date(date);
        let month = '' + (d.getMonth() + 1);
        let day = '' + d.getDate();
        const year = d.getFullYear();
        if (month.length < 2) month = '0' + month;
        if (day.length < 2) day = '0' + day;
        return [year, month, day].join('-');
    }

    formatDateExtention(date: string | number | Date) : string {
        const d = new Date(date);
        let month = '' + (d.getMonth() + 1);
        let day = '' + d.getDate();
        const year = d.getFullYear();
        if (month.length < 2) month = '0' + month;
        if (day.length < 2) day = '0' + day;
        return [year, month, day].join('-');
    }

    getUserSitesBySection(user: AuthToken, sectionName: string): SiteDto[] {

        let sites: SiteDto[] = [];

        user.applications.forEach(element => {
            var sitesItems = element.sections.find(s => s.sectionName === sectionName)?.sites;
            if (sitesItems != undefined && sitesItems != null) {
                sitesItems.forEach(site => {
                    if (site.siteID != undefined && site.siteID != null) {
                        sites.push(site);
                    }
                })
            }
        })

        return sites;
    };

    canUserAccessTSGSite(user: AuthToken, sectionName: string): Boolean {

        let userRight: Boolean = false;

        user.applications.forEach(element => {
            var sitesItems = element.sections.find(s => s.sectionName === sectionName)?.sites;
            if (sitesItems != undefined && sitesItems != null) {
                sitesItems.forEach(site => {
                    if (site.siteID != undefined && site.siteID != null && site.siteID == 0) {
                        userRight = true;
                        return userRight;
                    }
                })
            }
        })

        return userRight;
    };

    canViewPatronDetails(userSites: SiteDto[], siteId: number): Boolean {

        let userRight: Boolean = false;

        userSites.forEach(site => {
            if (site.siteID != undefined && site.siteID != null && site.siteID == siteId) {
                userRight = true;
                return userRight;
            }
        })

        return userRight;
    };

    canEditItemBySite(sites: SiteDto[], siteId: number): Boolean {

        let userRight: Boolean = false;

        sites.forEach(site => {
            if (site.siteID != undefined && site.siteID != null && site.siteID == siteId) {
                userRight = true;
                return userRight;
            }
        })

        return userRight;
    };

    canRemoveSectionFromUnit(userSites: SiteDto[], siteId: number): Boolean {

        let userRight: Boolean = false;

        userSites.forEach(site => {
            if (site.siteID != undefined && site.siteID != null && site.siteID == siteId) {
                userRight = true;
                return userRight;
            }
        })

        return userRight;
    };

    canRemoveSectionUnit(user: AuthToken, sectionName: string, siteId: number): Boolean {

        let userRight: Boolean = false;

        user.applications.forEach(element => {
            var sitesItems = element.sections.find(s => s.sectionName === sectionName)?.sites;
            if (sitesItems != undefined && sitesItems != null) {
                sitesItems.forEach(site => {
                    if (site.siteID != undefined && site.siteID != null) {
                        if (site.siteID == siteId) {
                            userRight = true;
                            return userRight;
                        }
                    }
                })
            }
        })

        return userRight;
    };

}
