import { Component, Inject, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";
import { Store } from "@ngrx/store";
import * as translatorAction from '../../../translator/store/translator.actions';
import * as translatorSelector from '../../../translator/store/translator.selectors';
import { filter } from "rxjs";
import { BaseDropdownModelItem } from "../../../../core/models/base";
import { GetListTranslatorModelItem } from "../../../../core/models/translator";
import { RequestAssignTranslationJobModel } from "../../../../core/models/translation-job";

@Component({
    selector: 'app-translation-job-assign',
    templateUrl: './translation-job-assign.component.html',
    styleUrls: ['./translation-job-assign.component.scss']
})
export class TranslationJobAssignComponent implements OnInit {
    public assignTranslationJobForm!: FormGroup;
    public translatorsDropDownData: BaseDropdownModelItem<number>[] | undefined;

    constructor(@Inject(MAT_DIALOG_DATA) private jobId: number,
        public dialogRef: MatDialogRef<TranslationJobAssignComponent>, private store$: Store) {
    }

    ngOnInit(): void {
        this.initForm();
        this.getTranslators();
    }

    public onSubmit(): void {
        if (this.assignTranslationJobForm.invalid) {
            Object.keys(this.assignTranslationJobForm.controls).forEach(field => {
                const control = this.assignTranslationJobForm.get(field);
                control?.markAsTouched({ onlySelf: true });
            });
            return;
        }        
        const job: RequestAssignTranslationJobModel = {
            id: this.jobId,
            translatorId: this.assignTranslationJobForm.controls['translatorId'].value
        };
        this.dialogRef.close(job);
    }

    public onCancel(): void {
        this.dialogRef.close(false);
    }

    private initForm(): void {
        this.assignTranslationJobForm = new FormGroup({
            translatorId: new FormControl(undefined, Validators.required)
        });
    }

    private getTranslators(): void { 
        this.store$.dispatch(translatorAction.getTranslators());
        const translators$ = this.store$.select(translatorSelector.translatorsData);
        translators$.pipe(filter((res) => res !== undefined)).subscribe((res) => {            
            this.translatorsDropDownData = res?.items?.map((val: GetListTranslatorModelItem): BaseDropdownModelItem<number> => ({
                id: val.id,
                label: val.name
            }));
        });
    }


}