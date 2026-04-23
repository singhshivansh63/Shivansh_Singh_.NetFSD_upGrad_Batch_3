"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
// 1. Variable Declaration (Explicit Types)
const userName = "Shivansh Singh";
let age = 21; // using let because we will update it
const email = "shivansh@example.com";
const isSubscribed = true;
// 2. Type Inference (No explicit types)
let country = "India"; // inferred as string
let loginCount = 5; // inferred as number
// 3. Template Literal (User Profile Message)
const userProfileMessage = `Hello ${userName}, you are ${age} years old and your email is ${email}.`;
console.log("User Profile:");
console.log(userProfileMessage);
// 4. Operators
// Increment age by 1
age = age + 1;
// Alternative (shorthand)
// age++;
// Check eligibility for premium plan
const isEligibleForPremium = age > 18 && isSubscribed;
// Comparison Example
const isAdult = age >= 18;
// 5. Output Results
console.log("\nUpdated Details:");
console.log(`Updated Age: ${age}`);
console.log(`Country (Type Inferred): ${country}`);
console.log(`Login Count (Type Inferred): ${loginCount}`);
console.log("\nEligibility Checks:");
console.log(`Is Adult: ${isAdult}`);
console.log(`Eligible for Premium Plan: ${isEligibleForPremium}`);
//# sourceMappingURL=index.js.map