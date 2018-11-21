import { Permission } from './permission';

export class Role {
  roleId: number;
  name: string;
  isEnabled: boolean;
  isChecked: boolean;
  Users: any;
  permissions: Permission[];
}