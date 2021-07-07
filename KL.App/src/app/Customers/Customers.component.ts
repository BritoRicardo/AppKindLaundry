import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalService } from 'ngx-bootstrap/modal';
import { Customers } from '../_models/Customers';
import { CustomersService } from '../_services/Customers.service';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { defineLocale } from 'ngx-bootstrap/chronos';
import { ptBrLocale } from 'ngx-bootstrap/locale';
import { DateTimeFormatPipe } from '../_helpers/DateTimeFormat.pipe';
defineLocale('pt-br', ptBrLocale);

@Component({
  selector: 'app-Customer',
  templateUrl: './Customers.component.html',
  styleUrls: ['./Customers.component.css'],
  providers: [DateTimeFormatPipe]
})
export class CustomersComponent implements OnInit {

  customersFiltered: Customers[] = [];
  customers: Customers[] = [];
  customer: Customers;
  registerForm: FormGroup;
  saveMode = 'post';
  bodyDeleteCustomer = '';

  _filtered: string = '';
  get filtered() {
    return this._filtered;
  }
  set filtered(value: string) {
    this._filtered = value;
    this.customersFiltered = this.filtered ? this.toFilterCustomers(this.filtered) : this.customers;
  }

  constructor(
    private CustomersService: CustomersService
   ,private modalService: BsModalService
   ,private fb: FormBuilder
   ,private localService: BsLocaleService
   ,private datePipe: DateTimeFormatPipe
   ) { 
    this.localService.use('pt-br');     
  } 

  ngOnInit() {
    this.validation();
    this.getCustomers();
  }

  editCustomer(customer: Customers, template: any) {
    this.saveMode = 'put';
    this.openModal(template);
    this.customer = customer;
    this.registerForm.patchValue(customer);
  }

  newCustomer(template: any) {
    this.saveMode = 'post';
    this.openModal(template);
  }

  delCustomer(customer: Customers, template: any) {
    this.openModal(template);
    this.customer = customer;
    this.bodyDeleteCustomer = `Are you sure you want to delete the customer: ${customer.name}, Id: ${customer.id}`;
  }

  confirmDelete(template: any) {
    this.CustomersService.deleteCustomer(this.customer.id).subscribe(
      () => {
          template.hide();
          this.getCustomers();
        }, error => {
          console.log(error);
        }
    );
  }

  openModal(template: any) {
    //Open modal and first reset form  
    this.registerForm.reset();   
    template.show();
  }


  validation() {
    // With FormBuilder
    this.registerForm = this.fb.group({     
      name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(150)]],
      birthDate: ['', Validators.required],
      codArea1: [''],
      codArea2: [''],
      phoneNumber1: ['', Validators.required],
      phoneNumber2: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      adress: ['', Validators.required],
      number: ['',[Validators.required, Validators.maxLength(10)]],
      neighborhood: ['',[Validators.required, Validators.maxLength(100)]],
      city: ['', Validators.required],
      alphaCode: ['', Validators.required]     
    });
  }

  salvarAlteracao(template: any) {
    if (this.registerForm.valid) {
      //Copy content form to object    
     
      if (this.saveMode === 'post') {
        this.customer = Object.assign({}, this.registerForm.value);
        this.customer.phoneNumber1 = Number(this.customer.phoneNumber1);
        this.customer.phoneNumber2 = Number(this.customer.phoneNumber2);
        this.customer.codArea1 = 71;
        this.customer.codArea2 = 71;
        this.customer.updateDate = new Date();

        this.CustomersService.postCustomer(this.customer).subscribe(
          (newCustormer: Customers) => {
            console.log(newCustormer);
            template.hide();
            this.getCustomers();
          }, error => {
            console.log(error);
          }
        )
      } else {
        // Keeping the id of object setted in the method editCustomer
        this.customer = Object.assign({id: this.customer.id}, this.registerForm.value);
        this.customer.phoneNumber1 = Number(this.customer.phoneNumber1);
        this.customer.phoneNumber2 = Number(this.customer.phoneNumber2);
        this.customer.codArea1 = 71;
        this.customer.codArea2 = 71;
        this.customer.updateDate = new Date(); 

        this.CustomersService.putCustomer(this.customer).subscribe(
          (newCustormer: Customers) => {
            console.log(newCustormer);
            template.hide();
            this.getCustomers();
          }, error => {
            console.log(error);
          }
        )
      }      
    }
  }

  toFilterCustomers(filterBy: string): any {
    filterBy = filterBy.toLocaleLowerCase();
    return this.customers.filter(
      client => client.name.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  getCustomers() {
    this.CustomersService.getAllCustomers().subscribe(
      (_Customers: Customers[]) => {
        this.customers = _Customers;
        this.customersFiltered = this.customers;
    }, error => {
      console.log(error);
    });
  }

  getCustomersById(id: number) {
    this.CustomersService.getCustomerById(id).subscribe(
      (_Customer: Customers) => {
        debugger;
        this.registerForm.setValue(_Customer);
       }, error => {
      console.log(error);
    });
  }
}
