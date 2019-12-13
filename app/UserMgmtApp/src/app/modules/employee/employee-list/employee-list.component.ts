import { Component, OnInit } from '@angular/core';
import { Employee } from '@models/index.ts';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {

  public baseUrl: string = `assets/img/`;
  public employeeDisplayList: Employee[] = [
    {
      'firstName': 'Tiffany',
      'lastName': 'Berry',
      'email': '',
      'photoUri': 'user1.png',
      'office': {
        'id': '1',
        'name': 'Nantes'
      }
    },
    {
      'firstName': 'Danielle',
      'lastName': 'Evans',
      'email': '',
      'photoUri': 'user1.png',
      'office': {
        'id': '1',
        'name': 'Nantes'
      }
    },
    {
      'firstName': 'Anna',
      'lastName': 'Barrett',
      'email': '',
      'photoUri': 'user1.png',
      'office': {
        'id': '2',
        'name': 'Rennes'
      }
    },
    {
      'firstName': 'Alice',
      'lastName': 'Davidson',
      'email': '',
      'photoUri': 'user1.png',
      'office': {
        'id': '2',
        'name': 'Rennes'
      }
    },
    {
      'firstName': 'Tiffany',
      'lastName': 'Berry',
      'email': '',
      'photoUri': 'user1.png',
      'office': {
        'id': '1',
        'name': 'Nantes'
      }
    },
    {
      'firstName': 'Danielle',
      'lastName': 'Evans',
      'email': '',
      'photoUri': 'user1.png',
      'office': {
        'id': '1',
        'name': 'Nantes'
      }
    },
    {
      'firstName': 'Anna',
      'lastName': 'Barrett',
      'email': '',
      'photoUri': 'user1.png',
      'office': {
        'id': '2',
        'name': 'Rennes'
      }
    },
    {
      'firstName': 'Alice',
      'lastName': 'Davidson',
      'email': '',
      'photoUri': 'user1.png',
      'office': {
        'id': '2',
        'name': 'Rennes'
      }
    }
  ];

  constructor() { }

  ngOnInit() {


  }

}
