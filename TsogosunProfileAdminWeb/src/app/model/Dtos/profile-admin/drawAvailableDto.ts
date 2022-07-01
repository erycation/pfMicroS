
export interface DrawAvailableDto {
    promotionName?: string | undefined;
    drawDate: Date;
    ingenicoTickets: number;
    freeIssueTickets: number;
    freeIssueBonusTickets: number;
    pointsTickets: number;
    pointsTransactionTickets: number;
    pointsToNextTicket: number;
    totalTickets: number;
    displayOn?: string | undefined;
}