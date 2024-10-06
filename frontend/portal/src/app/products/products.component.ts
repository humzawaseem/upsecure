import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ProductService } from 'src/services/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  products: any[] = [];
  product: any = {};

  productSelected = {};
  modalShown = false
  saving = false;
  @ViewChild('close') close: ElementRef | undefined;
  constructor(private service: ProductService) { }


  ngOnInit(): void {
    this.getAllProducts();
  }

  selectProduct(product?: any) {
    this.product = product ?? {};
  }

  getAllProducts() {
    this.service.getAllProducts().subscribe(res => {
      this.products = res as any[];
      console.log(res);
    })
  }

  deleteProduct(id: string) {
    this.service.deleteProduct(id).subscribe(res => {
      this.getAllProducts();
    })
  }

  createOrUpdateProduct() {
    if (!this.product.id) {
      this.service.createProduct(this.product).subscribe(res => {
        this.close?.nativeElement.click();
        this.getAllProducts();
      })
    }
    else {

      this.service.updateProduct(this.product).subscribe(res => {
        this.close?.nativeElement.click();
        this.getAllProducts();
      })
    }

  }


}
