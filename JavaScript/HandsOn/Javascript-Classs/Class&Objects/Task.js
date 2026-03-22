class Task {
  constructor(id, title, status = "Pending") {
    this.id = id;
    this.title = title;
    this.status = status;
  }

  markCompleted() {
    this.status = "Completed";
  }

  show() {
    console.log(`🆔 ${this.id} | 📌 ${this.title} | ✅ ${this.status}`);
  }
}

const task = new Task(1, "Build CLI app");
task.markCompleted();
task.show(); // Output: 🆔 1 | 📌 Build CLI app | ✅ Completed
