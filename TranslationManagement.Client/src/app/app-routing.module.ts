import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const appRoutes: Routes = [
    {
        path: 'translation-job',
        loadChildren: () => import('./translation-job/translation-job.module').then(module => module.TranslationJobModule)
    },
    {
        path: '**',
        redirectTo: 'translation-job/list',
        pathMatch: 'full'
    }
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule {
}
