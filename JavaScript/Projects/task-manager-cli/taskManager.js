// taskManager.js
const { TaskFactory } = require("./task");
const fs = require("fs").promises;
const path = require("path");
const DATA_FILE = path.join(__dirname, "tasks.json");

class TaskManager {
    constructor() {
        if (TaskManager.instance) return TaskManager.instance;
        this.tasks = [];
        TaskManager.instance = this;
    }

    async loadTasks() {
        try {
            const data = await fs.readFile(DATA_FILE, "utf-8");
            this.tasks = JSON.parse(data);
        } catch {
            this.tasks = [];
        }
    }

    async saveTasks() {
        try {
            await fs.writeFile(DATA_FILE, JSON.stringify(this.tasks, null, 2));
        } catch (err) {
            console.error("❌ Error saving tasks:", err.message);
        }
    }

    addTask(taskData) {
        const task = TaskFactory(taskData);
        this.tasks.push(task);
        this.saveTasks();
    }

    listTasks() {
        if (this.tasks.length === 0) return console.log("📭 No tasks found.");
        this.tasks.forEach(({ id, title, status, deadline }) => {
            console.log(`🆔 ${id}\n📌 ${title}\n✅ ${status}\n📅 ${deadline || "No deadline"}\n---`);
        });
    }

    updateTask(id, updates) {
        const task = this.tasks.find(t => t.id === id);
        if (!task) return console.log("❌ Task not found.");
        Object.assign(task, updates);
        this.saveTasks();
    }

    deleteTask(id) {
        this.tasks = this.tasks.filter(t => t.id !== id);
        this.saveTasks();
    }

    searchTasks(keyword) {
        const results = this.tasks.filter(t =>
            t.title.includes(keyword) || t.description.includes(keyword)
        );
        results.forEach(({ id, title, status }) =>
            console.log(`🆔 ${id} | 📌 ${title} | ✅ ${status}`)
        );
    }

    filterByStatus(status) {
        const filtered = this.tasks.filter(t => t.status === status);
        filtered.forEach(({ id, title }) =>
            console.log(`🆔 ${id} | 📌 ${title}`)
        );
    }

    sortByDeadline() {
        const sorted = [...this.tasks].sort((a, b) => new Date(a.deadline) - new Date(b.deadline));
        sorted.forEach(({ id, title, deadline }) =>
            console.log(`🆔 ${id} | 📌 ${title} | 📅 ${deadline}`)
        );
    }
}

module.exports = new TaskManager(); // Singleton
