import { createAction, props } from "@ngrx/store";
import { ResponseGetListTranslatorModel } from "../../../core/models/translator";

const GET_TRANSLATORS_BY_STATUS = '[TRANSLATORS] [API] get translators by status';
export const getTranslatorsByStatus = createAction(
    GET_TRANSLATORS_BY_STATUS,
    props<{ status: string }>()
);

const GET_TRANSLATORS_BY_STATUS_SUCCESS = '[TRANSLATORS] [API] get translators by status success';
export const getTranslatorsByStatusSuccess = createAction(
    GET_TRANSLATORS_BY_STATUS_SUCCESS,
    props<ResponseGetListTranslatorModel>()
);