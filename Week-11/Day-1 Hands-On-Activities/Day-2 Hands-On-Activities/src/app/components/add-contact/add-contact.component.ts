import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ContactService } from '../../services/contact.service';
import { Router } from '@angular/router';
import { Contact } from '../../models/contact';

@Component({
  selector: 'app-add-contact',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add-contact.component.html'
})
export class AddContactComponent {

  newContact: Contact = {
    id: 0,
    name: '',
    email: '',
    phone: '',
    status: true
  };

  constructor(
    private contactService: ContactService,
    private router: Router
  ) {}

  addContact() {
    if (!this.newContact.name) return;

    this.newContact.id = Date.now();

    this.contactService.addContact(this.newContact);

    this.router.navigate(['/contacts']); // redirect
  }
}