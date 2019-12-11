

export class EmployeeSearch {
    public id: string;
    public firstName: string;
    public lastName: string;
    public email: string;

    constructor(id: string, fName: string, lName: string, email: string) {
        this.id = id,
        this.firstName = fName,
        this.lastName = lName,
        this.email = email
    }
}
