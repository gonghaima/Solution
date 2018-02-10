import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { DynamicFormComponent } from './dynamic-forms/dynamic-form/dynamic-form.component';
import { DynamicFieldComponent } from './dynamic-forms/dynamic-field/dynamic-field.component';
import { FilterPipe } from './common/filter.pipe';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule
  ],
  declarations: [
    DynamicFormComponent,
    DynamicFieldComponent,
    FilterPipe
  ],
  providers: [],
  exports: [
    DynamicFormComponent,
    FilterPipe
  ]
})
export class FwModule { }
