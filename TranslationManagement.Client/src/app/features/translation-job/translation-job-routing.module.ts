import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { TranslationJobListComponent } from "./pages/list/translation-job-list.component";
import { LayoutComponent } from "../../shared/layout/layout.component";

const routes: Routes = [
    {
        path: 'list',
        component: LayoutComponent,
        children: [
            { path: '', component: TranslationJobListComponent }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class TranslationJobRoutingModule { 
}