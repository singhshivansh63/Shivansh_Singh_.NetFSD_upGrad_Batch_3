 
function getWelcomeMessage(name: string): string {
    return `Welcome ${name}! Glad to have you on board.`;
}
 
function getUserInfo(name: string, age?: number): string {
    if (age !== undefined) {
        return `User ${name} is ${age} years old.`;
    }
    return `User ${name} has not provided age.`;
}

 
function getSubscriptionStatus(name: string, isSubscribed: boolean = false): string {
    if (isSubscribed) {
        return `${name} is subscribed to our services.`;
    }
    return `${name} is not subscribed.`;
}

 
function isEligibleForPremium(age: number): boolean {
    return age > 18;
}

 
const getAccountUpdate = (name: string): string => {
    return `Hello ${name}, your account has been updated successfully.`;
};

 
const notificationService = {
    appName: "NotifyApp",

    sendNotification: (user: string): string => {
     
        return `Hello ${user}, welcome to ${notificationService.appName}`;
    }
};
 

const userName: string = "Shivansh";
const userAge: number = 21;

console.log("---- Notifications ----");

console.log(getWelcomeMessage(userName));

console.log(getUserInfo(userName, userAge));
console.log(getUserInfo(userName));  

console.log(getSubscriptionStatus(userName, true));
console.log(getSubscriptionStatus(userName)); 

console.log(`Eligible for Premium: ${isEligibleForPremium(userAge)}`);

console.log(getAccountUpdate(userName));

console.log(notificationService.sendNotification(userName));