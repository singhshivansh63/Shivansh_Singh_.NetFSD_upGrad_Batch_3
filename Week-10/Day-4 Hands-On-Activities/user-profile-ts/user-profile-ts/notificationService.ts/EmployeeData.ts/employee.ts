 
class Employee {
    public id: number;
    protected name: string;
    private salary: number;

    constructor(id: number, name: string, salary: number) {
        this.id = id;
        this.name = name;
        this.salary = salary;
    }

    // Getter
    public getSalary(): number {
        return this.salary;
    }

    // Setter with validation
    public setSalary(value: number): void {
        if (value > 0) {
            this.salary = value;
        } else {
            console.log("Salary must be greater than 0");
        }
    }

    // Method
    public displayDetails(): void {
        console.log(`Employee ID: ${this.id}`);
        console.log(`Employee Name: ${this.name}`);
        console.log(`Salary: ${this.salary}`);
    }
}

 
class Manager extends Employee {
    private teamSize: number;

    constructor(id: number, name: string, salary: number, teamSize: number) {
        super(id, name, salary);  
        this.teamSize = teamSize;
    }

    // Method Overriding
    public displayDetails(): void {
        super.displayDetails(); // call parent method
        console.log(`Team Size: ${this.teamSize}`);
    }
}

 

// Employee Object
const emp1 = new Employee(1, "Shivansh", 30000);
emp1.displayDetails();

console.log("\nUpdating Salary...");
emp1.setSalary(35000);
console.log(`Updated Salary: ${emp1.getSalary()}`);

 
console.log("\nManager Details:");
const manager1 = new Manager(2, "Rahul", 60000, 5);
manager1.displayDetails();