import { createAction, props } from "@ngrx/store";
import { ResponseGetListTranslatorModel } from "../../../core/models/translator";

const GET_TRANSLATORS = '[TRANSLATORS] [API] get translators';
export const getTranslators = createAction(
    GET_TRANSLATORS
);

const GET_TRANSLATORS_SUCCESS = '[TRANSLATORS] [API] get translators success';
export const getTranslatorsSuccess = createAction(
    GET_TRANSLATORS_SUCCESS,
    props<ResponseGetListTranslatorModel>()
);