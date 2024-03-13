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

    getTranslators$ = createEffect(() =>
        this.actions$.pipe(
            ofType(translatorActions.getTranslators),

            switchMap(() => {
                return this.translatorService.getTranslators().pipe(
                    map((data: ResponseGetListTranslatorModel) => {
                        return translatorActions.getTranslatorsSuccess(data);
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