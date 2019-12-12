import { Occupation, Office, Manager, Status } from '@models/index.ts';

export class Employee {

    constructor(public firstName: string, public lastName: string, public email: string, public hiringDate?: Date, public id?: string,
        public photoUri?: string, public office?: Office, public manager?: Manager, public humanResourceManager?: Manager,
        public status?: Status, public occupation?: Occupation, public accessRights?: string[], public leavingDate?: Date, public leavingCause?: string
    ) { }
}
