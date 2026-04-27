import { Pipe, PipeTransform } from '@angular/core';
import { Contact } from '../contact';

@Pipe({
  name: 'searchFilter',
  pure: false
})
export class SearchFilterPipe implements PipeTransform {

  transform(contacts: Contact[], searchText: string): Contact[] {
    if (!contacts) return [];
    if (!searchText) return contacts;

    searchText = searchText.toLowerCase();

    return contacts.filter(contact =>
      contact.name.toLowerCase().includes(searchText) ||
      contact.email.toLowerCase().includes(searchText)
    );
  }
}