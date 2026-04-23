 
const userName: string = "Shivansh Singh";
let age: number = 21;  
const email: string = "shivansh@example.com";
const isSubscribed: boolean = true;
let country = "India";         
let loginCount = 5;          

const userProfileMessage: string = `Hello ${userName}, you are ${age} years old and your email is ${email}.`;

console.log("User Profile:");
console.log(userProfileMessage); 
age = age + 1;
const isEligibleForPremium: boolean = age > 18 && isSubscribed;
const isAdult: boolean = age >= 18;
 
console.log("\nUpdated Details:");
console.log(`Updated Age: ${age}`);
console.log(`Country (Type Inferred): ${country}`);
console.log(`Login Count (Type Inferred): ${loginCount}`);

console.log("\nEligibility Checks:");
console.log(`Is Adult: ${isAdult}`);
console.log(`Eligible for Premium Plan: ${isEligibleForPremium}`);