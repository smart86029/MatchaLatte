import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { LogService } from './log.service';
import { SignInRoutingModule } from './sign-in/sign-in-routing.module';
import { SignInComponent } from './sign-in/sign-in.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
    SignInRoutingModule
  ],
  providers: [
    LogService
  ],
  declarations: [SignInComponent]
})
export class CoreModule { }