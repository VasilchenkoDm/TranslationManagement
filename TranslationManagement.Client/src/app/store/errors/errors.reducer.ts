import { Action, ActionReducer, createReducer, on } from "@ngrx/store";
import { ErrorState } from ".";
import * as actions from './error.actions';

const initialState: ErrorState = {
    error: undefined,
    isApiError: undefined
};

export const errorsReducer: ActionReducer<ErrorState, Action> =
    createReducer(
        initialState,
        on(
            actions.errorAction,
            (state: ErrorState, { error, isApiError }) => {
                return ({ ...state, error, isApiError });
            }
        ),
        on(
            actions.clearErrorAction,
            (state: ErrorState) =>
                ({ ...state, ...initialState })
        )
    );

export function ErrorsReducer(state: ErrorState, action: Action) {
    return errorsReducer(state, action);
}