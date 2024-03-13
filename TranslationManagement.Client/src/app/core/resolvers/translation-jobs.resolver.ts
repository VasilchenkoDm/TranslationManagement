import { Injectable } from "@angular/core";
import { Resolve } from "@angular/router";
import { Store } from "@ngrx/store";
import { AppState } from "../../store";
import { Observable, filter, take } from "rxjs";
import * as translationJobAction from '../../translation-job/store/translation-job.actions';
import * as translationJobSelector from '../../translation-job/store/translation-job.selectors';
import { ResponseGetListTranslationJobModel } from "../models/translation-job";

@Injectable({
    providedIn: 'root'
})
export class TranslationJobsResolver implements Resolve<ResponseGetListTranslationJobModel | undefined> {
    constructor(private store$: Store<AppState>) { }

    resolve(): Observable<ResponseGetListTranslationJobModel | undefined> {
        this.store$.dispatch(translationJobAction.getTranslationJobs());

        const translationJobsData$: Observable<ResponseGetListTranslationJobModel | undefined> =
            this.store$.select(translationJobSelector.translationJobsData);

        return translationJobsData$.pipe(
            filter((data) => {
                return Boolean(data);
            }),
            take(1)
        );
    }
}
