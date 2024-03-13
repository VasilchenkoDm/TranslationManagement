import { createAction, props } from "@ngrx/store";
import { ErrorState } from ".";

const ERROR = '[APP] Error';
export const errorAction = createAction(ERROR, props<ErrorState>());

const CLEAR_ERROR = '[APP] Error clear';
export const clearErrorAction = createAction(CLEAR_ERROR);