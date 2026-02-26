 
const taskInput = document.getElementById("taskInput");
const addBtn = document.getElementById("addBtn");
const taskList = document.getElementById("taskList");

 
const addTask = () => {

    const taskText = taskInput.value.trim();

    if (!taskText) return;

    const li = document.createElement("li");

    li.innerHTML = `
        <span class="task-text">${taskText}</span>
        <div>
            <button class="complete-btn">✔</button>
            <button class="delete-btn">✖</button>
        </div>
    `;

    taskList.appendChild(li);

    taskInput.value = "";
};

 
const handleTaskActions = (event) => {

    const target = event.target;

    const li = target.closest("li");

    if (!li) return;

    // Delete Task
    if (target.classList.contains("delete-btn")) {
        li.remove();
    }

    // Mark Complete
    if (target.classList.contains("complete-btn")) {
        li.classList.toggle("completed");
    }
};

 
addBtn.addEventListener("click", addTask);

taskInput.addEventListener("keypress", (e) => {
    if (e.key === "Enter") addTask();
});

 
taskList.addEventListener("click", handleTaskActions);