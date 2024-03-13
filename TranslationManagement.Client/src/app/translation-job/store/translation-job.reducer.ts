import { Action, ActionReducer, createReducer, on } from "@ngrx/store";
import { TranslationJobsState } from ".";
import * as translationJobActions from './translation-job.actions';
import { ResponseGetListTranslationJobModel } from "../../core/models/translation-job";

const initialState: TranslationJobsState = {
    translationJobs: undefined
};

export const translationJobsReducer: ActionReducer<TranslationJobsState, Action> =
    createReducer(
        initialState,
        on(
            translationJobActions.getTranslationJobsSuccess,
            (state: TranslationJobsState, data: ResponseGetListTranslationJobModel) => ({
                ...state,
                translationJobs: data
            })
        )
    );

export function TranslationJobReducer(state: TranslationJobsState, action: Action) {
    return translationJobsReducer(state, action);
}
