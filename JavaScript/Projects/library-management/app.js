const readline = require("readline");
const library = require("./library");

const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
  prompt: "📖 Library > "
});

console.log("📚 Welcome to the Library CLI!");
rl.prompt();

rl.on("line", (line) => {
  const [command, ...args] = line.trim().split(" ");

  switch (command) {
    case "addBook":
      const [title, author] = args;
      library.addBook(title, author);
      break;

    case "addMember":
      library.addMember(args[0]);
      break;

    case "listBooks":
      library.listBooks();
      break;

    case "borrow":
      const [memberName, bookId] = args;
      const member = library.findMember(memberName);
      const book = library.findBook(bookId);
      if (member && book) {
        member.borrowBook(book);
      } else {
        console.log("❌ Member or Book not found.");
      }
      break;

    case "return":
      const [returnName, returnId] = args;
      const returnMember = library.findMember(returnName);
      if (returnMember) {
        returnMember.returnBook(returnId);
      } else {
        console.log("❌ Member not found.");
      }
      break;

    case "exit":
      rl.close();
      break;

    default:
      console.log("❓ Unknown command.");
  }

  rl.prompt();
});

rl.on("close", () => {
  console.log("👋 Goodbye!");
  process.exit(0);
});
