import { createAction, props } from "@ngrx/store";
import { ResponseGetListTranslationJobModel } from "../../core/models/translation-job";

const GET_JOBS = '[TRANSLATION_JOBS] [API] get translation jobs';
export const getTranslationJobs = createAction(
    GET_JOBS
);

const GET_JOBS_SUCCESS = '[TRANSLATION_JOBS] [API] get translation jobs success';
export const getTranslationJobsSuccess = createAction(
    GET_JOBS_SUCCESS,
    props<ResponseGetListTranslationJobModel>()
);