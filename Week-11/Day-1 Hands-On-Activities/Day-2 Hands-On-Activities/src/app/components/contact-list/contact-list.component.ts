import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContactService } from '../../services/contact.service';
import { Contact } from '../../models/contact';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './contact-list.component.html'
})
export class ContactListComponent {

  contacts: Contact[] = [];

  // ✅ Add status field
  newContact: Contact = {
    id: 0,
    name: '',
    email: '',
    phone: '',
    status: true
  };

  // ✅ Selected contact for detail view
  selectedContact?: Contact;

  constructor(private contactService: ContactService) {}

  ngOnInit() {
    this.loadContacts();
  }

  // ✅ Load contacts from service
  loadContacts() {
    this.contacts = this.contactService.getContacts();
  }

  // ✅ Add Contact
  addContact() {
    if (!this.newContact.name || !this.newContact.email) return;

    this.newContact.id = this.contacts.length + 1;

    this.contactService.addContact({ ...this.newContact });

    // reset form
    this.newContact = {
      id: 0,
      name: '',
      email: '',
      phone: '',
      status: true
    };

    this.loadContacts();
  }

  // ✅ Toggle status via service
  toggleStatus(contact: Contact) {
    this.contactService.toggleStatus(contact.id);
    this.loadContacts();
  }

  // ✅ View details
  viewDetails(id: number) {
    this.selectedContact = this.contactService.getContactById(id);
  }
}