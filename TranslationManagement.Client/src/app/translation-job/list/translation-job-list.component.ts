import { Component, ViewChild } from "@angular/core";
import { MatSort } from "@angular/material/sort";
import { MatTableDataSource } from "@angular/material/table";

@Component({
    selector: 'app-translation-job-list',
    templateUrl: './translation-job-list.component.html',
    styleUrls: ['./translation-job-list.component.scss']
})
export class TranslationJobListComponent{
    @ViewChild(MatSort, { static: false }) sort!: MatSort;
    
    public translationJobs: Array<any> = [{ name: 'test 1'}, { name: 'test 2'}, { name: 'test 3'}];
    public dataSource: MatTableDataSource<any> = new MatTableDataSource(this.translationJobs);
    public displayedColumns: string[] = ['Name'];

    constructor(){

    }

    public createJob(): void {       
    }

    public selectJob(event: MouseEvent, job: any): void {

    }

    public sortJobData(): void {
        
    }

}