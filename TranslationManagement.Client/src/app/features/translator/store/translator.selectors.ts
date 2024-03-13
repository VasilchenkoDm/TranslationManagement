import { createFeatureSelector, createSelector } from "@ngrx/store";
import { TranslatorState } from ".";
import { ReducerNodesEnum } from "../../../store";

const translatorFeatureSelector = createFeatureSelector<TranslatorState>(
    ReducerNodesEnum.translator
);

export const translatorsData = createSelector(
    translatorFeatureSelector,
    (state: TranslatorState) => state?.translators
);