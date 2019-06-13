import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { forkJoin, Observable } from 'rxjs';
import { City } from 'src/app/city/city';
import { CityService } from 'src/app/city/city.service';
import { District } from 'src/app/city/district';
import { Guid } from 'src/app/shared/guid';

import { SaveMode } from '../../shared/save-mode/save-mode.enum';
import { Product } from '../product';
import { ProductCategory } from '../product-category';
import { ProductDetailDialogComponent } from '../product-detail-dialog/product-detail-dialog.component';
import { Store } from '../store';
import { StoreService } from '../store.service';

@Component({
  selector: 'app-store-detail',
  templateUrl: './store-detail.component.html',
  styleUrls: ['./store-detail.component.scss']
})
export class StoreDetailComponent implements OnInit {
  isLoading = false;
  saveMode = SaveMode.Create;
  displayedColumns = ['name', 'price', 'action'];
  store = new Store();
  cities: City[];
  selectedCity = new City();
  selectedDistrict: District;

  formGroup: FormGroup;
  storeFormGroup: FormGroup;
  secondFormGroup: FormGroup;

  constructor(
    private storeService: StoreService,
    private cityService: CityService,
    private route: ActivatedRoute,
    private location: Location,
    private dialog: MatDialog,
    private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    let store$: Observable<Store>;
    const id = this.route.snapshot.paramMap.get('id');
    if (Guid.isGuid(id)) {
      this.saveMode = SaveMode.Update;
      this.isLoading = true;
      store$ = this.storeService.getStore(new Guid(id));
    } else {
      store$ = this.storeService.getNewStore();
    }

    forkJoin([this.cityService.getCities(), store$]).subscribe({
      next: result => {
        const cities = result[0];
        const store = result[1];
        this.cities = cities;
        this.store = store;
        this.selectedCity = cities.find(city => city.name === store.address.city) || this.cities[0];
        this.selectedDistrict =
          this.selectedCity.districts.find(district => district.name === store.address.district) || this.selectedCity.districts[0];
      },
      complete: () => this.isLoading = false
    });

    this.formGroup = new FormGroup({
      storeFormGroup: this.formBuilder.group({
        firstCtrl: ['', Validators.required]
      }),
      secondFormGroup: this.formBuilder.group({
        secondCtrl: ['', Validators.required]
      })
    });
  }

  save(): void {
    this.store.address.city = this.selectedCity.name;
    this.store.address.district = this.selectedDistrict.name;
    switch (this.saveMode) {
      case SaveMode.Create:
        this.create();
        break;
      case SaveMode.Update:
        this.update();
        break;
    }
  }

  back(): void {
    this.location.back();
  }

  createProductCategory(): void {
    this.store.productCategories.push(new ProductCategory());
  }

  deleteProductCategory(category: ProductCategory): void {
    const index = this.store.productCategories.indexOf(category);
    this.store.productCategories.splice(index, 1);
  }

  createProduct(category: ProductCategory): void {
    const dialogRef = this.dialog.open(ProductDetailDialogComponent, {
      data: {}
    });
    dialogRef.afterClosed().subscribe(data => {
      if (data) {
        category.products.push(data);
      }
    });
  }

  updateProduct(product: Product): void {
    const dialogRef = this.dialog.open(ProductDetailDialogComponent, {
      data: JSON.parse(JSON.stringify(product))
    });
    dialogRef.afterClosed().subscribe(value => {
      if (!value) {
        return;
      }

      product.name = value.name.trim();
      product.productItems = value.productItems;
      product.productItems.forEach(item => {
        item.name = item.name.trim();
      });
    });
  }

  deleteProduct(product: Product, category: ProductCategory): void {
    const index = category.products.indexOf(product);
    category.products.splice(index, 1);
  }

  drop(event: CdkDragDrop<string[]>) {
    moveItemInArray(event.container.data, event.previousIndex, event.currentIndex);
  }

  private create(): void {
    this.storeService
      .createStore(this.store)
      .subscribe(store => this.location.back());
  }

  private update(): void {
    this.storeService
      .updateStore(this.store)
      .subscribe(store => this.location.back());
  }
}
