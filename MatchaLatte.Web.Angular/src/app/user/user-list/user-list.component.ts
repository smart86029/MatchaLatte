import { Component, OnInit, ViewChild, ComponentFactoryResolver } from '@angular/core';
import { MatPaginator, MatTableDataSource } from '@angular/material';
import { UserService } from '../user.service';
import { User } from '../user';
import { PaginationResult } from 'src/app/shared/pagination-result';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {
  isLoading: boolean;
  displayedColumns = ['id', 'userName', 'isEnabled', 'action'];
  dataSource = new MatTableDataSource<User>();
  users = new PaginationResult<User>();

  @ViewChild(MatPaginator)
  paginator: MatPaginator;

  constructor(private userService: UserService, private resolver: ComponentFactoryResolver) { }

  ngOnInit(): void {
    this.getUsers(0, this.users.pageSize);
  }

  private getUsers(pageIndex: number, pageSize: number): void {
    this.isLoading = true;
    this.userService.getUsers(pageIndex, pageSize)
      .subscribe(result => {
        this.dataSource.data = result.items;
        this.users = result;
      }, () => { }, () => this.isLoading = false);
  }
}