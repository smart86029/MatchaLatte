import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthGuard } from '../auth/auth.guard';
import { AdminIndexComponent } from './admin-index/admin-index.component';

const routes: Routes = [
  {
    path: '',
    component: AdminIndexComponent,
    canActivate: [AuthGuard],
    children: [
      // { path: '', component: AdminDashboardComponent },
      { path: 'users', loadChildren: '../user/user.module#UserModule' },
      // { path: 'roles', loadChildren: 'app/role/role.module#RoleModule' },
      // { path: 'permissions', loadChildren: 'app/permission/permission.module#PermissionModule' },
      { path: 'stores', loadChildren: '../store/store.module#StoreModule' }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }