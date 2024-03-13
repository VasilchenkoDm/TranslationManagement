import { createAction, props } from "@ngrx/store";
import { RequestCreateTranslationJobModel, ResponseGetListTranslationJobModel } from "../../core/models/translation-job";

const GET_JOBS = '[TRANSLATION_JOBS] [API] get translation jobs';
export const getTranslationJobs = createAction(
    GET_JOBS
);

const GET_JOBS_SUCCESS = '[TRANSLATION_JOBS] [API] get translation jobs success';
export const getTranslationJobsSuccess = createAction(
    GET_JOBS_SUCCESS,
    props<ResponseGetListTranslationJobModel>()
);

const CREATE_JOB = '[TRANSLATION_JOBS] [API] translation job create';
export const translationJobCreate = createAction(
    CREATE_JOB,
    props<RequestCreateTranslationJobModel>()
);

const CREATE_JOB_SUCCESS = '[TRANSLATION_JOBS] [API] translation job create success';
export const translationJobCreateSuccess = createAction(
    CREATE_JOB_SUCCESS
);