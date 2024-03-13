import { ChangeDetectorRef, Component, OnInit } from "@angular/core";
import { MatTableDataSource } from "@angular/material/table";
import { MatDialog } from '@angular/material/dialog';
import { Store } from "@ngrx/store";
import { AppState } from "../../../store";
import * as translationJobSelector from '../../store/translation-job.selectors';
import * as translationJobAction from '../../store/translation-job.actions';
import { GetListTranslationJobModelItem, RequestCreateTranslationJobModel } from "../../../core/models/translation-job";
import { TranslationJobCreateComponent } from "../create/translation-job-create.component";

@Component({
    selector: 'app-translation-job-list',
    templateUrl: './translation-job-list.component.html',
    styleUrls: ['./translation-job-list.component.scss']
})
export class TranslationJobListComponent implements OnInit {

    public dataSource!: MatTableDataSource<GetListTranslationJobModelItem>;
    public displayedColumns: string[] = ['id', 'customerName', 'status', 'price', 'translatorName'];

    constructor(private store$: Store<AppState>, private detector: ChangeDetectorRef,
        private dialog: MatDialog) {
    }

    ngOnInit(): void {
        this.getTranslationJobs();
    }

    public createJob(): void {
        const dialogRef = this.dialog.open(TranslationJobCreateComponent, {
            width: '60%'
        });
        dialogRef.afterClosed().subscribe((result: RequestCreateTranslationJobModel) => {            
            if (!result){
                return;
            }      
            this.store$.dispatch(translationJobAction.translationJobCreate(result));
          });
    }

    private getTranslationJobs(): void {
        this.store$.select(translationJobSelector.translationJobsData).subscribe((res) => {
            this.dataSource = new MatTableDataSource<GetListTranslationJobModelItem>(res?.items);
            this.detector.detectChanges();
        });
    }

}