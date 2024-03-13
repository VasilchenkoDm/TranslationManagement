import { NgModule } from "@angular/core";
import { TranslationJobListComponent } from "./pages/list/translation-job-list.component";
import { TranslationJobRoutingModule } from "./translation-job-routing.module";
import { SharedModule } from "../../shared/shared.module";
import { TranslationJobCreateComponent } from "./pages/create/translation-job-create.component";
import { TranslationJobAssignComponent } from "./pages/assign-to/translation-job-assign.component";
import { TranslationJobCreateWithFileComponent } from "./pages/create-with-file/translation-job-create-with-file.component";

@NgModule({
    imports: [
        SharedModule,
        TranslationJobRoutingModule
    ],
    declarations: [
        TranslationJobListComponent,
        TranslationJobCreateComponent,
        TranslationJobAssignComponent,
        TranslationJobCreateWithFileComponent
    ]
})
export class TranslationJobModule { }