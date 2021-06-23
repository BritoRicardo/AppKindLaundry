import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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
  registerForm: FormGroup;

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
    this.registerForm = new FormGroup({
      name: new FormControl('', 
        [Validators.required, Validators.minLength(3), Validators.maxLength(150)]),
      birthDate: new FormControl('', Validators.required),
      phoneNumber1: new FormControl('', Validators.required),
      phoneNumber2: new FormControl('', Validators.required),
      email: new FormControl('', 
        [Validators.required, Validators.email]),
      adress: new FormControl('', Validators.required),
      number: new FormControl('', 
        [Validators.required, Validators.maxLength(10)]),
      neighborhood: new FormControl('', 
        [Validators.required, Validators.maxLength(100)]),
      city: new FormControl('', 
        [Validators.required, Validators.maxLength(100)]),
      alphaCode: new FormControl('', Validators.required)
    });
  } 

  ngOnInit() {
    this.validation();
    this.getCustomers();
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  validation() {
    this.registerForm = new FormGroup({
      name: new FormControl('', 
        [Validators.required, Validators.minLength(3), Validators.maxLength(150)]),
      birthDate: new FormControl('', Validators.required),
      phoneNumber1: new FormControl('', Validators.required),
      phoneNumber2: new FormControl('', Validators.required),
      email: new FormControl('', 
        [Validators.required, Validators.email]),
      adress: new FormControl('', Validators.required),
      number: new FormControl('', 
        [Validators.required, Validators.maxLength(10)]),
      neighborhood: new FormControl('', 
        [Validators.required, Validators.maxLength(100)]),
      city: new FormControl('', Validators.required),
      alphaCode: new FormControl('', Validators.required)
    });
  }

  salvarAlteracao() {

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
