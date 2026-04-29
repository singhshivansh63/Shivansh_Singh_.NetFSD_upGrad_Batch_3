import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContactService } from '../../services/contact.service';
import { Contact } from '../../models/contact';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent implements OnInit {

  contacts: Contact[] = [];

  // ✅ Messages
  errorMsg = '';
  successMsg = '';

  // ✅ Form Model
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

  // ✅ GET ALL (API)
  loadContacts() {
    this.contactService.getContacts().subscribe({
      next: (data) => {
        this.contacts = data;
        this.errorMsg = '';
      },
      error: (err) => {
        this.errorMsg = err;
      }
    });
  }

  // ✅ ADD CONTACT (API)
  addContact() {
    if (!this.newContact.name || !this.newContact.email) {
      this.errorMsg = 'Name and Email are required';
      return;
    }

    this.contactService.addContact(this.newContact).subscribe({
      next: () => {
        this.successMsg = 'Contact added successfully!';
        this.errorMsg = '';

        // Reset form
        this.newContact = {
          id: 0,
          name: '',
          email: '',
          phone: '',
          status: true
        };

        this.loadContacts();
      },
      error: () => {
        this.errorMsg = 'Failed to add contact';
      }
    });
  }

  // ✅ DELETE CONTACT (API)
  deleteContact(id: number) {
    this.contactService.deleteContact(id).subscribe({
      next: () => {
        this.successMsg = 'Contact deleted!';
        this.errorMsg = '';
        this.loadContacts();
      },
      error: () => {
        this.errorMsg = 'Failed to delete contact';
      }
    });
  }

  // ✅ VIEW DETAILS (API)
  viewDetails(id: number) {
    this.contactService.getContactById(id).subscribe({
      next: (data) => {
        this.selectedContact = data;
        this.errorMsg = '';
      },
      error: () => {
        this.errorMsg = 'Failed to load contact details';
      }
    });
  }

  // ❌ REMOVED: toggleStatus (not supported by API unless implemented)
}