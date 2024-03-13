import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { TranslationJobService } from "../../core/services/translation-job.service";
import { catchError, map, of, switchMap } from "rxjs";
import * as translationJobActions from './translation-job.actions';
import * as errorActions from '../../store/errors/error.actions';

@Injectable()
export class TranslationJobEffects {
    constructor(
        private actions$: Actions,
        private readonly translationJobService: TranslationJobService
    ) {
    }

    searchLocations$ = createEffect(() =>
        this.actions$.pipe(
            ofType(translationJobActions.getTranslationJobs),

            switchMap(() => {
                return this.translationJobService.getJobs().pipe(
                    map((data: any) => {

                        if (!data.isSuccessful)
                            return errorActions.errorAction({
                                error: data.message,
                                isApiError: true
                            });

                        return translationJobActions.getTranslationJobsSuccess(data);
                    }),
                    catchError((error) => {
                        return of(
                            errorActions.errorAction({
                                error: JSON.stringify(error),
                                isApiError: true
                            })
                        );
                    })
                );
            })
        )
    );

}