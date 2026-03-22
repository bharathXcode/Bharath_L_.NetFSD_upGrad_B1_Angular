// task.js
class Task {
  constructor(id, title, description, status = "Pending", deadline = null) {
    this.id = id;
    this.title = title;
    this.description = description;
    this.status = status;
    this.deadline = deadline ? new Date(deadline) : null;
  }
}

const TaskFactory = ({ title, description, deadline }) => {
  const id = Date.now().toString();
  return new Task(id, title, description, "Pending", deadline);
};

module.exports = { Task, TaskFactory };
