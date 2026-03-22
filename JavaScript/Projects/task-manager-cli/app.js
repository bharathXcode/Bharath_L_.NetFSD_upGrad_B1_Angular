// app.js
const readline = require("readline");
const taskManager = require("./taskManager");

(async () => {
    await taskManager.loadTasks();

    const rl = readline.createInterface({
        input: process.stdin,
        output: process.stdout,
        prompt: "📝 TaskManager > "
    });

    console.log("🚀 Welcome to Task Manager CLI!");
    rl.prompt();

    rl.on("line", async (line) => {
        const [command, ...args] = line.trim().split(" ");

        try {
            switch (command) {
                case "add":
                    const [title, description, deadline] = args;
                    taskManager.addTask({ title, description, deadline });
                    break;
                case "list":
                    taskManager.listTasks();
                    break;
                case "update":
                    const [id, field, ...value] = args;
                    taskManager.updateTask(id, { [field]: value.join(" ") });
                    break;
                case "delete":
                    taskManager.deleteTask(args[0]);
                    break;
                case "search":
                    taskManager.searchTasks(args.join(" "));
                    break;
                case "filter":
                    taskManager.filterByStatus(args[0]);
                    break;
                case "sort":
                    taskManager.sortByDeadline();
                    break;
                case "exit":
                    rl.close();
                    break;
                default:
                    console.log("❓ Unknown command.");
            }
        } catch (err) {
            console.error("⚠️ Error:", err.message);
        }

        rl.prompt();
    });

    rl.on("close", () => {
        console.log("👋 Goodbye!");
        process.exit(0);
    });
})();
