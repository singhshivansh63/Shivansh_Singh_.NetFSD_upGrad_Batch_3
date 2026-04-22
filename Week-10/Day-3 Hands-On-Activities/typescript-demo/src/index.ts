// Basic Types
let name: string = "Scott";
let age: number = 22;
let isDeveloper: boolean = true;

// Function
function greet(user: string): string {
    return `Hello, ${user}! Welcome to TypeScript demo.`;
}

console.log(greet(name));

// Interface
interface User {
    id: number;
    name: string;
}

const user: User = {
    id: 1,
    name: "Scott"
};

console.log(user);