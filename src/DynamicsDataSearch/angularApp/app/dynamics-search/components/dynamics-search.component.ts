import { Component } from '@angular/core';

import { DynamicsSearchService } from '../services/dynamics-search.service';
import { DynamicsSearch } from '../models/dynamics-search';

@Component({
    selector: 'dynamics-search-component',
    templateUrl: 'dynamics-search.component.html'
})
export class DynamicsSearchComponent {
    private searching = false;

    entityOptions = [
        { value: 'contacts', display: 'Contacts' },
        { value: 'accounts', display: 'Accounts' }
    ];
    model = new DynamicsSearch(this.entityOptions[0].value, null, null, null);
    entities: any[];

    constructor(private searchService: DynamicsSearchService) { }

    onSubmit() {
        this.searching = true;
        this.searchService.search(this.model)
            .then(results => {
                this.entities = results;
                this.searching = false;
            });
    }

    formValid(): boolean {
        const idField = <HTMLInputElement>document.getElementById('id');
        const filterField = <HTMLInputElement>document.getElementById('filter');

        return (idField.value && idField.value.length > 0) || (filterField.value && filterField.value.length > 0);
    }
}
