import { Action, ActionReducer, createReducer, on } from "@ngrx/store";
import { TranslatorState } from ".";
import * as translatorActions from './translator.actions';
import { ResponseGetListTranslatorModel } from "../../../core/models/translator";

const initialState: TranslatorState = {
    translators: undefined
};

export const translatorReducer: ActionReducer<TranslatorState, Action> =
    createReducer(
        initialState,
        on(
            translatorActions.getTranslatorsByStatusSuccess,
            (state: TranslatorState, data: ResponseGetListTranslatorModel) => ({
                ...state,
                translators: data
            })
        )
    );

export function TranslatorReducer(state: TranslatorState, action: Action) {
    return translatorReducer(state, action);
}