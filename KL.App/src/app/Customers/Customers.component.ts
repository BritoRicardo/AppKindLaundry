import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Customers } from '../_models/Customers';
import { CustomersService } from '../_services/Customers.service';

@Component({
  selector: 'app-Customer',
  templateUrl: './Customers.component.html',
  styleUrls: ['./Customers.component.css']
})
export class CustomersComponent implements OnInit {

  CustomersFiltered: Customers[] = [];
  Customers: Customers[] = [];
  modalRef: BsModalRef;

  _filtered: string = '';
  get filtered() {
    return this._filtered;
  }
  set filtered(value: string) {
    this._filtered = value;
    this.CustomersFiltered = this.filtered ? this.toFilterCustomers(this.filtered) : this.Customers;
  }

  constructor(
    private CustomersService: CustomersService
   ,private modalService: BsModalService
   ) { 
    this.modalRef = new BsModalRef();
  } 

  ngOnInit() {
    this.getCustomers();
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  toFilterCustomers(filterBy: string): any {
    filterBy = filterBy.toLocaleLowerCase();
    return this.Customers.filter(
      client => client.name.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  getCustomers() {
    this.CustomersService.getAllCustomers().subscribe(
      (_Customers: Customers[]) => {
        this.Customers = _Customers;
        this.CustomersFiltered = this.Customers;
    }, error => {
      console.log(error);
    });
  }
}
