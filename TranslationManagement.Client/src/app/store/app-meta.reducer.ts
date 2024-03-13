import { ActionReducerMap } from "@ngrx/store";
import { AppState } from ".";
import { ErrorsReducer } from './errors/errors.reducer';

export const reducers: ActionReducerMap<AppState> = {
    appErrors: ErrorsReducer
};