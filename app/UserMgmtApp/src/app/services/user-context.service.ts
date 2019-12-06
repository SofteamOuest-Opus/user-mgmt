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

    let currentUserOffice = new Office('1', 'Nantes');
    let currentUserManager: Manager = new Manager('1', 'Andrea', 'Porter');
    let currentUserHRManager: Manager = new Manager('2', 'Allan', 'Nichols');
    let currentUserStatus: Status = new Status('1', 'Interne');
    let currentUserOccupation: Occupation = new Occupation('1', 'Développeur');
    let currentUserAccessRights: string[] = ['Employee', 'Manager'];

    return new Employee('Tiffany', 'Berry', 'tiffany.berry@softeam.fr', new Date('2010-01-17'), '1', '', currentUserOffice,
      currentUserManager, currentUserHRManager, currentUserStatus, currentUserOccupation, currentUserAccessRights);
  }

}
