import { ChangeDetectorRef, Component, OnInit } from "@angular/core";
import { MatTableDataSource } from "@angular/material/table";
import { Store } from "@ngrx/store";
import { AppState } from "../../store";
import * as translationJobSelector from '../store/translation-job.selectors';
import { GetListTranslationJobModelItem } from "../../core/models/translation-job";

@Component({
    selector: 'app-translation-job-list',
    templateUrl: './translation-job-list.component.html',
    styleUrls: ['./translation-job-list.component.scss']
})
export class TranslationJobListComponent implements OnInit {

    public dataSource!: MatTableDataSource<GetListTranslationJobModelItem>;
    public displayedColumns: string[] = ['id', 'customerName', 'status', 'price', 'translatorName'];

    constructor(private store$: Store<AppState>, private detector: ChangeDetectorRef) {
    }

    ngOnInit(): void {
        this.getTranslationJobs();
    }

    public createJob(): void {
    }

    public selectJob(event: MouseEvent, job: GetListTranslationJobModelItem): void {

    }

    private getTranslationJobs(): void {
        this.store$.select(translationJobSelector.translationJobsData).subscribe((res) => {
            this.dataSource = new MatTableDataSource<GetListTranslationJobModelItem>(res?.items);
            this.detector.detectChanges();
        });
    }

}