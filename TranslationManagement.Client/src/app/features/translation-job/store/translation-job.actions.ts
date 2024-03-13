import { createAction, props } from "@ngrx/store";
import { RequestAssignTranslationJobModel, RequestCreateTranslationJobModel, RequestCreateWithFileTranslationJobModel, ResponseGetListTranslationJobModel } from "../../../core/models/translation-job";

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

const CREATE_JOB_WITH_FILE = '[TRANSLATION_JOBS] [API] translation job create with file';
export const translationJobCreateWithFile = createAction(
    CREATE_JOB_WITH_FILE,
    props<RequestCreateWithFileTranslationJobModel>()
);

const CREATE_JOB_WITH_FILE_SUCCESS = '[TRANSLATION_JOBS] [API] translation job create  with file success';
export const translationJobCreateWithFileSuccess = createAction(
    CREATE_JOB_WITH_FILE_SUCCESS
);

const ASSIGN_JOB = '[TRANSLATION_JOBS] [API] translation job assign';
export const translationJobAssign = createAction(
    ASSIGN_JOB,
    props<RequestAssignTranslationJobModel>()
);

const ASSIGN_JOB_SUCCESS = '[TRANSLATION_JOBS] [API] translation job assign success';
export const translationJobAssignSuccess = createAction(
    ASSIGN_JOB_SUCCESS
);
