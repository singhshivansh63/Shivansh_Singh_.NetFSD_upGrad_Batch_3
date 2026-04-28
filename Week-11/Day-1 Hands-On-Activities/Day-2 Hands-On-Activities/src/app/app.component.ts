import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule, TitleCasePipe, LowerCasePipe } from '@angular/common';
import { RouterModule } from '@angular/router';

import { PhoneFormatPipe } from './pipes/phone-format-pipe';
import { StatusPipe } from './pipes/status-pipe';
import { SearchFilterPipe } from './pipes/search-filter-pipe';

import { ContactService } from './services/contact.service';
import { Contact } from './models/contact';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule,
    RouterModule,   // ✅ ADD THIS
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
  contacts: Contact[] = [];

  newContact: Contact = {
    id: 0,
    name: '',
    email: '',
    phone: '',
    status: true
  };

  selectedContact?: Contact;

  constructor(private contactService: ContactService) {}

  ngOnInit() {
    this.contacts = this.contactService.getContacts();
  }

  addContact() {
    if (!this.newContact.name) return;

    this.newContact.id = this.contacts.length + 1;

    this.contactService.addContact({ ...this.newContact });

    this.newContact = {
      id: 0,
      name: '',
      email: '',
      phone: '',
      status: true
    };

    this.contacts = this.contactService.getContacts();
  }

  toggleStatus(contact: Contact) {
    this.contactService.toggleStatus(contact.id);
  }

  viewDetails(id: number) {
    this.selectedContact = this.contactService.getContactById(id);
  }
}