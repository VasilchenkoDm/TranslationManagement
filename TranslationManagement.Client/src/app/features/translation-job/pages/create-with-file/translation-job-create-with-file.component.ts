import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { MatDialogRef } from "@angular/material/dialog";
import { CommonConstants } from "../../../../core/constants";
import { RequestCreateWithFileTranslationJobModel } from "../../../../core/models/translation-job";

@Component({
    selector: 'app-translation-job-create-with-file',
    templateUrl: './translation-job-create-with-file.component.html',
    styleUrls: ['./translation-job-create-with-file.component.scss']
})
export class TranslationJobCreateWithFileComponent implements OnInit {

    public createTranslationJobForm!: FormGroup;  
    public attachment: File | undefined;
    public isUnsuportedFileType: boolean = false;

    constructor(public dialogRef: MatDialogRef<TranslationJobCreateWithFileComponent>) {
    }

    ngOnInit(): void {
        this.initForm();
    }

    public onSubmit(): void {        
        if (this.createTranslationJobForm.invalid || this.isUnsuportedFileType) {
            Object.keys(this.createTranslationJobForm.controls).forEach(field => {
                const control = this.createTranslationJobForm.get(field);
                control?.markAsTouched({ onlySelf: true });
            });
            return;
        }
        const job: RequestCreateWithFileTranslationJobModel = {
            customerName: this.createTranslationJobForm.controls['customerName'].value,
            file: this.attachment!
        };
        this.dialogRef.close(job);
    }

    public onCancel(): void {
        this.dialogRef.close();
    }

    public fileInputChange(fileInputEvent: any) {        
        const supportedFileTypes: string[]  = CommonConstants.SUPPORTED_FILE_TYPES;
        const file = fileInputEvent.target.files[0];
        if(!supportedFileTypes.includes(file.type)){
            this.isUnsuportedFileType = true;
            this.attachment = undefined;
            return;
        }
        this.isUnsuportedFileType = false;
        this.attachment = file;
    }

    private initForm(): void {
        this.createTranslationJobForm = new FormGroup({
            customerName: new FormControl('')
        });
    }

}