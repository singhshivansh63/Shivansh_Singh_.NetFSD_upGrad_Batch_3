import { Injectable } from '@angular/core';
import { Contact } from '../models/contact';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  private contacts: Contact[] = [
    { id: 1, name: 'john doe', email: 'john@gmail.com', phone: '9876543210', status: true },
    { id: 2, name: 'jane smith', email: 'jane@gmail.com', phone: '9123456780', status: false },
    { id: 3, name: 'alex ray', email: 'alex@gmail.com', phone: '9988776655', status: true }
  ];

  getContacts(): Contact[] {
    return this.contacts;
  }

  addContact(contact: Contact): void {
    this.contacts.push(contact);
  }

  getContactById(id: number): Contact | undefined {
    return this.contacts.find(c => c.id === id);
  }

  toggleStatus(id: number) {
    const contact = this.getContactById(id);
    if (contact) contact.status = !contact.status;
  }
}