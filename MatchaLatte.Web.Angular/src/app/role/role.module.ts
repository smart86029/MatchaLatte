import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { RoleDetailComponent } from './role-detail/role-detail.component';
import { RoleListComponent } from './role-list/role-list.component';
import { RoleRoutingModule } from './role-routing.module';

@NgModule({
  declarations: [
    RoleDetailComponent,
    RoleListComponent
  ],
  imports: [
    SharedModule,
    RoleRoutingModule
  ]
})
export class RoleModule { }