import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { StoreModule } from "@ngrx/store";
import { ReducerNodesEnum } from "../../../store";
import { TranslatorReducer } from "./translator.reducer";
import { EffectsModule } from "@ngrx/effects";
import { TranslatorEffects } from "./translator.effect";

@NgModule({
    imports: [
        CommonModule,
        StoreModule.forFeature(ReducerNodesEnum.translator, TranslatorReducer),
        EffectsModule.forFeature([TranslatorEffects])
    ]
})
export class TranslatorStoreModule { }