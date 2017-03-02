import { RouterModule } from '@angular/router';
import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NavigationComponent } from './components/navigation/navigation.component';
import { GenericTableComponent } from './components/generic-table/generic-table.component';

import { ArrayIndexPipe } from './pipes/array-index.pipe';

@NgModule({
    imports: [
        CommonModule,
        RouterModule
    ],

    declarations: [
        NavigationComponent,
        GenericTableComponent,
        ArrayIndexPipe
    ],

    exports: [
        NavigationComponent,
        GenericTableComponent,
        ArrayIndexPipe
    ]
})

export class SharedModule { }