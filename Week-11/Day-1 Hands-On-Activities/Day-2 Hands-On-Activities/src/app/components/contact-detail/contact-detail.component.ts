import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContactService } from '../../services/contact.service';
import { Contact } from '../../models/contact';

@Component({
  selector: 'app-contact-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './contact-detail.component.html'
})
export class ContactDetailComponent {

  contact?: Contact;

  constructor(private contactService: ContactService) {}

  ngOnInit() {
    const id = 1; // ✅ Hardcoded for Level-1
    this.contact = this.contactService.getContactById(id);
  }
}
