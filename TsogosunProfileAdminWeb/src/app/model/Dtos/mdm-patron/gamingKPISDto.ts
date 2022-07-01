export interface GamingKPISDto {
    lastPlayDate?: Date | undefined;
    slots_Handle: number;
    slots_TheoWin: number;
    slots_ActualWin: number;
    tables_Drop: number;
    tables_TheoWin: number;
    tables_ActualWin: number;
    visits: number;
    total_TheoWin: number;
    total_ActualWin: number;
    avgSpend: number;
    slots_Worth: number;
    tables_Worth: number;
    total_Worth: number;
    visitSegment?: string | undefined;
    spendSegment?: string | undefined;
}