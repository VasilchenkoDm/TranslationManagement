import { NgModule } from "@angular/core";
import { LayoutComponent } from "./layout/layout.component";
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatListModule } from '@angular/material/list';
import { MatExpansionModule } from '@angular/material/expansion';
import { RouterModule } from "@angular/router";

@NgModule({
    imports: [
        RouterModule,
        MatSidenavModule,
        MatToolbarModule,
        MatIconModule,
        MatMenuModule,
        MatListModule,
        MatExpansionModule,
        MatButtonModule
    ],
    declarations: [
        LayoutComponent
    ]
})
export class SharedModule { 
}