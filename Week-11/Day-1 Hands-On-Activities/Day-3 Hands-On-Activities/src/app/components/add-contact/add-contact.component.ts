import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ContactService } from '../../services/contact.service';
import { Router } from '@angular/router';
import { Contact } from '../../models/contact';

@Component({
  selector: 'app-add-contact',
  standalone: true,
  imports: [CommonModule, FormsModule],
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

  errorMsg = '';
  successMsg = '';

  constructor(
    private contactService: ContactService,
    private router: Router
  ) {}

  addContact() {
    if (!this.newContact.name || !this.newContact.email) {
      this.errorMsg = 'Name and Email are required';
      return;
    }

    // ✅ API CALL
    this.contactService.addContact(this.newContact).subscribe({
      next: () => {
        this.successMsg = 'Contact added successfully!';
        this.errorMsg = '';

        // Redirect after short delay
        setTimeout(() => {
          this.router.navigate(['/']);
        }, 1000);
      },
      error: () => {
        this.errorMsg = 'Failed to add contact';
      }
    });
  }
}