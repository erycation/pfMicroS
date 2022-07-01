

export interface AddessConfirmedStatus  {
    isSuburbCorrect?: boolean | undefined;
    isCityCorrect?: boolean | undefined;
    isProvinceCorrect?: boolean | undefined;
    isCountryCorrect?: boolean | undefined;
    isPostalCodeCorrect?: boolean | undefined;
    isAddressCorrect?: boolean | undefined;
    confirmedPcId:number;
    confirmedTown?: string | undefined;
    confirmedArea?: string | undefined;
    confirmedPostalCode?: string | undefined;
    confirmedCountry?: string | undefined;
    confirmedProvDescription?: string | undefined;
}