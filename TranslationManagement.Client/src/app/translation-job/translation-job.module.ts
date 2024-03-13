import { NgModule } from "@angular/core";
import { TranslationJobListComponent } from "./pages/list/translation-job-list.component";
import { TranslationJobRoutingModule } from "./translation-job-routing.module";
import { SharedModule } from "../shared/shared.module";
import { TranslationJobCreateComponent } from "./pages/create/translation-job-create.component";

@NgModule({
    imports: [
        SharedModule,
        TranslationJobRoutingModule
    ],
    declarations: [
        TranslationJobListComponent,
        TranslationJobCreateComponent
    ]
})
export class TranslationJobModule { }