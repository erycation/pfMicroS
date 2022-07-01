export class ModalValidationParams {

    public successMessage: string;
    public errorMessage: string;
    public showErrorMessage: boolean;
    public showSuccessMessage: boolean;
    loading = false;

    constructor(){

        this.resetValidationFields();
     }

     public resetValidationFields() : void{
        this.showSuccessMessage = false;
        this.showErrorMessage = false;
        this.successMessage = "";
        this.errorMessage = "";
     }

     public displayDivErrorMessage(errorMessage : string) : void{ 
      this.showSuccessMessage = false;
      this.errorMessage = errorMessage;  
      this.showErrorMessage = true;
     }

     public displayDivSuccessMessage(successMessage : string) : void{ 
      this.showErrorMessage = false;
      this.showSuccessMessage = true;
      this.successMessage = successMessage;        
     }
}