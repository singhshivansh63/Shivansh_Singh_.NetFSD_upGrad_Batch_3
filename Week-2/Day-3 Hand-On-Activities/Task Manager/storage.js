let tasks = [];

 
export const addTask = (task) => {
    return new Promise((resolve) => {
        setTimeout(() => {
            tasks.push(task);
            resolve(`Task "${task}" added successfully`);
        }, 800);
    });
};

export const deleteTask = (task) => {
    return new Promise((resolve) => {
        setTimeout(() => {
            tasks = tasks.filter(t => t !== task);
            resolve(` Task "${task}" deleted successfully`);
        }, 800);
    });
};

export const listTasks = () => {
    return new Promise((resolve) => {
        setTimeout(() => {
            resolve([...tasks]);
        }, 500);
    });
};