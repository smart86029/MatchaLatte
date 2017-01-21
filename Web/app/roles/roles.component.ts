﻿import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Role } from './role';
import { RoleService } from './role.service';

declare var $: any;

@Component({
  moduleId: module.id,
  selector: 'my-roles',
  templateUrl: 'roles.component.html',
  styleUrls: ['roles.component.css']
})
export class RolesComponent implements OnInit {
  roles: Role[];
  newRole: Role;
  selectedRole: Role;
  errorMessage: string;
  showDialog = false;

  constructor(
    private router: Router,
    private roleService: RoleService) { }

  getRoles(): void {
    this.roleService.getRoles()
      .subscribe(
        roles => this.roles = roles,
        error => this.errorMessage = <any>error);

    this.newRole = new Role();
  }

  ngOnInit(): void {
    this.getRoles();
    $('.modal').modal();
  }

  onSelect(role: Role): void {
    this.selectedRole = role;
  }

  gotoDetail(): void {
    this.router.navigate(['/detail', this.selectedRole.RoleId]);
  }

  submitForm(form: any): void {
    console.log('Form Data: ');
    console.log(form);
  }
}