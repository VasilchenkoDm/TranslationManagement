import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from "./app-routing.module";
import { SharedModule } from "./shared/shared.module";
import { StoreModule } from '@ngrx/store';
import { TranslationJobStoreModule } from "./features/translation-job/store/translation-job.store.module";
import { reducers } from './store/app-meta.reducer';
import { EffectsModule } from "@ngrx/effects";
import { HttpClientModule } from "@angular/common/http";
import { TranslatorStoreModule } from "./features/translator/store/translators.store.module";

const STORE = [
    TranslationJobStoreModule,
    TranslatorStoreModule,

    StoreModule.forRoot(reducers),
    EffectsModule.forRoot([])
];

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        STORE,
        BrowserModule,
        BrowserAnimationsModule,
        SharedModule,
        AppRoutingModule,
        HttpClientModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule {
}