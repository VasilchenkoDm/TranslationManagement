import { ResponseGetListTranslationJobModel } from "../../../core/models/translation-job";

export interface TranslationJobsState {
    translationJobs: ResponseGetListTranslationJobModel | undefined;
}
