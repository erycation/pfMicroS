export interface PatronDrawDto {
    promotionName?: string | undefined;
    drawDate: Date;
    ingenicoTickets: number;
    freeIssueTickets: number;
    freeIssueBonusTickets: number;
    pointsTickets: number;
    pointsTransactionTickets: number;
    pointsToNextTicket: number;
    collectableTickets: number;
    collectedTickets: number;
    dateCollected?: Date | undefined;
    displayOn?: string | undefined;
    promotionsStatus?: string | undefined;
    ticketStatus?: string | undefined;
}
