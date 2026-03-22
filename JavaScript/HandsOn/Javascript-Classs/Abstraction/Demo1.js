//Abstraction means hiding internal details and showing only 
// essential features.
class EmailService {
    sendEmail(to, message) {
        this.#connectSMTP();
        console.log(`📧 Sending email to ${to}: ${message}`);
    }

    #connectSMTP() {
        console.log("🔌 Connecting to SMTP server...");
    }
}

const email = new EmailService();
email.sendEmail("santosh@example.com", "Hello!");
