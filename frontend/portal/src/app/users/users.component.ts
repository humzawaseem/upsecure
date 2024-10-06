import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { UserService } from 'src/services/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {

  users: any[] = [];
  user: any = {};

  userSelected = {};
  modalShown = false
  saving = false;

  @ViewChild('close') close: ElementRef | undefined;
  constructor(private service: UserService) { }

  ngOnInit(): void {
    this.getAllUsers();
  }

  selectUser(user?: any) {
    this.user = user ?? {};
  }

  getAllUsers() {
    this.service.getAllUsers().subscribe(res => {
      this.users = res as any[];
      console.log(res);
    })
  }

  deleteUser(id: string) {
    this.service.deleteUser(id).subscribe(res => {
      this.getAllUsers();
    })
  }

  createOrUpdateUser() {
    if (!this.user.id) {
      this.service.createUser(this.user).subscribe(res => {
        this.close?.nativeElement.click();
        this.getAllUsers();
      })
    }
    else {

      this.service.updateUser(this.user).subscribe(res => {
        this.close?.nativeElement.click();
        this.getAllUsers();
      })
    }

  }


}
