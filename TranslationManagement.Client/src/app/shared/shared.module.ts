import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { LayoutComponent } from "./layout/layout.component";
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatListModule } from '@angular/material/list';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatTableModule } from "@angular/material/table";
import { MatSortModule } from "@angular/material/sort";

@NgModule({
    imports: [
        RouterModule,
        MatSidenavModule,
        MatToolbarModule,
        MatIconModule,
        MatMenuModule,
        MatListModule,
        MatExpansionModule,
        MatButtonModule,
        MatTableModule,
        MatSortModule
    ],
    declarations: [
        LayoutComponent
    ],
    exports: [
        MatSidenavModule,
        MatToolbarModule,
        MatIconModule,
        MatMenuModule,
        MatListModule,
        MatExpansionModule,
        MatButtonModule,
        MatTableModule,
        MatSortModule
    ]
})
export class SharedModule { 
}