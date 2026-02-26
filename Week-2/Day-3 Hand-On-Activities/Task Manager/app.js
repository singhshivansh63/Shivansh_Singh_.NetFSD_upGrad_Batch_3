import { addTask, deleteTask, listTasks } from './storage.js';

const taskInput = document.getElementById("taskInput");
const messageDiv = document.getElementById("message");
const taskListDiv = document.getElementById("taskList");

 
const handleAddTask = async () => {
    const task = taskInput.value.trim();

    if (!task) {
        messageDiv.textContent = "⚠ Please enter a task!";
        return;
    }

    const msg = await addTask(task);
    messageDiv.textContent = msg;

    taskInput.value = "";
    renderTasks();
};

 
const handleDeleteTask = async (task) => {
    const msg = await deleteTask(task);
    messageDiv.textContent = msg;
    renderTasks();
};
 
const renderTasks = async () => {
    const tasks = await listTasks();

    if (tasks.length === 0) {
        taskListDiv.innerHTML = "<p>No tasks available.</p>";
        return;
    }

    taskListDiv.innerHTML = `
        <ul>
            ${tasks.map(task => `
                <li>
                    ${task}
                    <button onclick="deleteTaskUI('${task}')">Delete</button>
                </li>
            `).join("")}
        </ul>
    `;
};

 
window.deleteTaskUI = handleDeleteTask;
window.addTaskUI = handleAddTask;