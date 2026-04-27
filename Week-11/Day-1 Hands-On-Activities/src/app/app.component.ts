import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule, TitleCasePipe, LowerCasePipe } from '@angular/common';

 
import { PhoneFormatPipe } from './pipes/phone-format-pipe';
import { StatusPipe } from './pipes/status-pipe';
import { SearchFilterPipe } from './pipes/search-filter-pipe';

@Component({
  selector: 'app-root',
  standalone: true,

  
  imports: [
    FormsModule,
    CommonModule,         
    TitleCasePipe,
    LowerCasePipe,
    PhoneFormatPipe,
    StatusPipe,
    SearchFilterPipe
  ],

  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  searchText: string = '';

  contacts = [
    { name: 'john doe', email: 'john@gmail.com', phone: '9876543210', status: true },
    { name: 'jane smith', email: 'jane@gmail.com', phone: '9123456780', status: false },
    { name: 'alex ray', email: 'alex@gmail.com', phone: '9988776655', status: true },
    { name: 'sam wilson', email: 'sam@gmail.com', phone: '9090909090', status: false },
    { name: 'tony stark', email: 'tony@gmail.com', phone: '8888888888', status: true },
    { name: 'bruce wayne', email: 'bruce@gmail.com', phone: '7777777777', status: false },
    { name: 'clark kent', email: 'clark@gmail.com', phone: '6666666666', status: true },
    { name: 'peter parker', email: 'peter@gmail.com', phone: '5555555555', status: true },
    { name: 'natasha', email: 'nat@gmail.com', phone: '4444444444', status: false },
    { name: 'wanda', email: 'wanda@gmail.com', phone: '3333333333', status: true }
  ];

  toggleStatus(contact: any) {
    contact.status = !contact.status;
  }
}