import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {


  private readonly API_URL = 'https://localhost:7085/';
  readonly options = {
    headers: {
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    }
  }
  constructor(private readonly http: HttpClient) { 
    


  }


  getAllUsers() {
    return this.http.get(`${this.API_URL}user/GetAllAsync`,this.options);
  }

  getById(id: number) {
    return this.http.get(`${this.API_URL}user/GetByIdAsync?id=${id}`);
  }

  createUser(user: any) {
    return this.http.post(`${this.API_URL}user/CreateAsync`, user,this.options);
  }

  updateUser(user: any) {
    return this.http.put(`${this.API_URL}user/UpdateAsync?id=${user.id}`, user);
  }

  deleteUser(id: string) {
    return this.http.delete(`${this.API_URL}user/DeleteAsync?id=${id}`);
  }


}
