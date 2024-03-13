import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { MatDialogRef } from "@angular/material/dialog";
import { RequestCreateTranslationJobModel } from "../../../../core/models/translation-job";

@Component({
    selector: 'app-translation-job-create',
    templateUrl: './translation-job-create.component.html',
    styleUrls: ['./translation-job-create.component.scss']
})
export class TranslationJobCreateComponent implements OnInit {

    public createTranslationJobForm!: FormGroup;

    constructor(public dialogRef: MatDialogRef<TranslationJobCreateComponent>) {
    }

    ngOnInit(): void {
        this.initForm();
    }

    public onSubmit(): void {
        if (this.createTranslationJobForm.invalid) {
            Object.keys(this.createTranslationJobForm.controls).forEach(field => {
                const control = this.createTranslationJobForm.get(field);
                control?.markAsTouched({ onlySelf: true });
            });
            return;
        }
        const job: RequestCreateTranslationJobModel = {
            customerName: this.createTranslationJobForm.controls['customerName'].value,
            originalContent: this.createTranslationJobForm.controls['originalContent'].value
        };
        this.dialogRef.close(job);
    }

    public onCancel(): void {
        this.dialogRef.close();
    }

    private initForm(): void {
        this.createTranslationJobForm = new FormGroup({
            customerName: new FormControl('', Validators.required),
            originalContent: new FormControl('', Validators.required)
        });
    }

}