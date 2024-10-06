import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private readonly API_URL = 'https://localhost:7085/';
  constructor(private readonly http: HttpClient) { }


  getAllProducts() {
    return this.http.get(`${this.API_URL}Product/GetAllAsync`);
  }

  getById(id: number) {
    return this.http.get(`${this.API_URL}Product/GetByIdAsync?id=${id}`);
  }

  createProduct(product: any) {
    return this.http.post(`${this.API_URL}Product/CreateAsync`, product);
  }

  updateProduct(product: any) {
    return this.http.put(`${this.API_URL}Product/UpdateAsync?id=${product.id}`, product);
  }

  deleteProduct(id: string) {
    return this.http.delete(`${this.API_URL}Product/DeleteAsync?id=${id}`);
  }

}
