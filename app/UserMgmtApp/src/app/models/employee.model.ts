import { Office } from './office.model';
import { Manager } from './manager.model';
import { Status } from './status.model';
import { Occupation } from './occupation.model';


export class Employee {

    public firstName: string;
    public lastName: string;
    public email: string;
    public hiringDate: Date

    public id?: string;
    public photoUri?: string;
    public office?: Office;
    public manager?: Manager;
    public humanResourceManager?: Manager;
    public status?: Status;
    public occupation?: Occupation;
    public accessRights?: string[];
    public leavingDate?: Date;
    public leavingCause?: string;

    constructor(fName: string, lName: string, email: string, hiringDate: Date, id?: string, photoUri?: string, office?: Office, manager?: Manager, humanResourceManager?: Manager,
        status?: Status, occupation?: Occupation, accessRights?: string[], leavingDate?: Date, leavingCause?: string) {

        this.firstName = fName;
        this.lastName = lName;
        this.email = email;
        this.hiringDate = hiringDate;

        this.id = id;
        this.photoUri = photoUri;
        this.office = office;
        this.manager = manager;
        this.humanResourceManager = humanResourceManager;
        this.status = status;
        this.occupation = occupation;
        this.accessRights = accessRights;
        this.leavingDate = leavingDate;
        this.leavingCause = leavingCause;
    }
}
