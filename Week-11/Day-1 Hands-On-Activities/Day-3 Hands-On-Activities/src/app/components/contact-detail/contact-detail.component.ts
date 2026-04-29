import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { ContactService } from '../../services/contact.service';
import { Contact } from '../../models/contact';

@Component({
  selector: 'app-contact-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './contact-detail.component.html'
})
export class ContactDetailComponent implements OnInit {

  contact?: Contact;
  errorMsg = '';

  constructor(
    private route: ActivatedRoute,
    private contactService: ContactService
  ) {}

  ngOnInit(): void {
    // ✅ Get ID from URL
    const id = Number(this.route.snapshot.paramMap.get('id'));

    if (!id) {
      this.errorMsg = 'Invalid contact ID';
      return;
    }

    // ✅ API CALL
    this.contactService.getContactById(id).subscribe({
      next: (data) => {
        this.contact = data;
        this.errorMsg = '';
      },
      error: () => {
        this.errorMsg = 'Failed to load contact';
      }
    });
  }
}
