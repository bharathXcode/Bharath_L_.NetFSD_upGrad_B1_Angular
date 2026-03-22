// storage.js
const fs = require("fs").promises;
const path = require("path");
const DATA_FILE = path.join(__dirname, "tasks.json");

async function exportTasks(tasks) {
    await fs.writeFile(DATA_FILE, JSON.stringify(tasks, null, 2));
}

async function importTasks() {
    const data = await fs.readFile(DATA_FILE, "utf-8");
    return JSON.parse(data);
}

module.exports = { exportTasks, importTasks };
