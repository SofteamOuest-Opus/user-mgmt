import { Injectable } from '@angular/core';
import { Employee } from '../models/employee.model';
import { Office } from '../models/office.model';
import { Manager } from '../models/manager.model';
import { Status } from '../models/status.model';
import { Occupation } from '../models/occupation.model';

@Injectable({
  providedIn: 'root'
})
export class UserContextService {

  private _currentUser: Employee | Manager;

  constructor() {

  }

  public getCurrentUserInfos(): Employee {
    let currentUserOffice: Office = new Office('1', 'NANTES');
    let currentUserManager: Manager = new Manager('1', 'Simon', 'ROBERT');
    let currentUserHRManager: Manager = new Manager('1', 'Simon', 'ROBERT');
    let currentUserStatus: Status = new Status('1', 'Internship');
    let currentUserOccupation: Occupation = new Occupation('1', 'Developper');
    let currentUserAccessRights: string[] = ['Employee'];
    let currentUser: Employee = new Employee('BERRY', 'Tiffany', 'tiffany.berry@softeam.fr', '1', '', currentUserOffice,
      currentUserManager, currentUserHRManager, currentUserStatus, currentUserOccupation, currentUserAccessRights);
    return currentUser;
  }


}
