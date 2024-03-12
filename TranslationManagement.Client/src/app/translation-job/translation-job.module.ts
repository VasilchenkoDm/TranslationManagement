import { NgModule } from "@angular/core";
import { TranslationJobListComponent } from "./list/translation-job-list.component";
import { TranslationJobRoutingModule } from "./translation-job-routing.module";
import { SharedModule } from "../shared/shared.module";

@NgModule({
    imports: [
        SharedModule,
        TranslationJobRoutingModule
    ],
    declarations: [
        TranslationJobListComponent
    ]
})
export class TranslationJobModule { }