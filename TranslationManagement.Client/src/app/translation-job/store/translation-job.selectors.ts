import { createFeatureSelector, createSelector } from "@ngrx/store";
import { TranslationJobsState } from './index';
import { ReducerNodesEnum } from "../../store";

const translationJobFeatureSelector = createFeatureSelector<TranslationJobsState>(
    ReducerNodesEnum.translationJobs
);

export const translationJobsData = createSelector(
    translationJobFeatureSelector,
    (state: TranslationJobsState) => state?.translationJobs
);