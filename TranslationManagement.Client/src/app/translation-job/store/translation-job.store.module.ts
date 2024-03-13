import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { StoreModule } from "@ngrx/store";
import { EffectsModule } from '@ngrx/effects';
import { ReducerNodesEnum } from "../../store";
import { TranslationJobReducer } from "./translation-job.reducer";
import { TranslationJobEffects } from "./translation-job.effect";

@NgModule({
    imports: [
      CommonModule,
      StoreModule.forFeature(ReducerNodesEnum.translationJobs, TranslationJobReducer),
      EffectsModule.forFeature([TranslationJobEffects])
    ]
  })
  export class TranslationJobStoreModule {}