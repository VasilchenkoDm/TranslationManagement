import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { TranslatorService } from "../../../core/services/translator.service";
import * as translatorActions from './translator.actions';
import * as errorActions from '../../../store/errors/error.actions';
import { catchError, map, of, switchMap } from "rxjs";
import { ResponseGetListTranslatorModel } from "../../../core/models/translator";

@Injectable()
export class TranslatorEffects {
    constructor(
        private actions$: Actions,
        private readonly translatorService: TranslatorService
    ) {
    }

    getTranslatorsByStatus$ = createEffect(() =>
        this.actions$.pipe(
            ofType(translatorActions.getTranslatorsByStatus),

            switchMap((action) => {
                return this.translatorService.getTranslatorsByStatus(action.status).pipe(
                    map((data: ResponseGetListTranslatorModel) => {
                        return translatorActions.getTranslatorsByStatusSuccess(data);
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