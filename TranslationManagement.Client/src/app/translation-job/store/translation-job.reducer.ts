import { Action, ActionReducer, createReducer, on } from "@ngrx/store";
import { TranslationJobsState } from ".";
import * as translationJobActions from './translation-job.actions';

const initialState: TranslationJobsState = {
    allTranslationJobs: undefined
};

export const translationJobsReducer: ActionReducer<TranslationJobsState, Action> =
    createReducer(
        initialState,
        on(
            translationJobActions.getTranslationJobs,
            (state: TranslationJobsState, data: any) => ({
                ...state,
                allTranslationJobs: data
            })
        )
    );

export function TranslationJobReducer(state: TranslationJobsState, action: Action) {
    return translationJobsReducer(state, action);
}
