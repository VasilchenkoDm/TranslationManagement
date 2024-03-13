import { Component, OnInit, ViewChild } from "@angular/core";
import { MatSort } from "@angular/material/sort";
import { MatTableDataSource } from "@angular/material/table";
import { Store } from "@ngrx/store";
import { AppState } from "../../store";
import * as translationJobSelector from '../store/translation-job.selectors';

@Component({
    selector: 'app-translation-job-list',
    templateUrl: './translation-job-list.component.html',
    styleUrls: ['./translation-job-list.component.scss']
})
export class TranslationJobListComponent implements OnInit {
    @ViewChild(MatSort, { static: false }) sort!: MatSort;

    public translationJobs: Array<any> = [{ name: 'test 1' }, { name: 'test 2' }, { name: 'test 3' }];
    public dataSource: MatTableDataSource<any> = new MatTableDataSource(this.translationJobs);
    public displayedColumns: string[] = ['Name'];

    constructor(private store$: Store<AppState>) {

    }

    ngOnInit(): void {
        this.getTranslationJobs();
    }

    public createJob(): void {
    }

    public selectJob(event: MouseEvent, job: any): void {

    }

    public sortJobData(): void {

    }

    private getTranslationJobs(): void {
        this.store$.select(translationJobSelector.translationJobsData).subscribe((res) => {
            debugger
            // if (res?.isSuccessful) {
            //   this.dataSource =
            //     new MatTableDataSource<ResponseSearchLocationModelItem>(res.items);
            //   this.totalPages = res.total;
            //   this.detector.detectChanges();
            // }
          });
    }

}