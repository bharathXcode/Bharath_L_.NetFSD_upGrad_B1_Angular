// ================= TEXT DATA =================

// Titles to be displayed in typing animation
const titleTexts = [
    "Smart Healthcare System",
    "AI Powered Healthcare",
    "Manage Patients Easily"
];

// Paragraphs corresponding to each title
const paragraphTexts = [
    "A modern solution to manage patients, doctors, and appointments efficiently.",
    "Automate scheduling and reduce conflicts with smart technology.",
    "Track, manage, and improve healthcare delivery seamlessly."
];


// ================= STATE VARIABLES =================

// Current index of title/paragraph
let titleIndex = 0;

// Character index for title typing
let charIndex = 0;

// Character index for paragraph typing
let paraCharIndex = 0;


// ================= SPEED CONFIG =================

// Typing speed for characters
let typingSpeed = 70;

// Deleting speed for characters
let deletingSpeed = 40;

// Pause before deleting starts
let pauseTime = 1200;


// ================= DOM ELEMENTS =================

// Target elements where text will be rendered
const titleElement = document.getElementById("typing-title");
const paraElement = document.getElementById("typing-text");


// ================= TYPING FUNCTIONS =================

// Types title text character by character
function typeTitle() {
    if (charIndex < titleTexts[titleIndex].length) {

        titleElement.innerHTML += titleTexts[titleIndex].charAt(charIndex);
        charIndex++;

        setTimeout(typeTitle, typingSpeed);

    } else {
        // Once title is complete, start paragraph typing
        setTimeout(typeParagraph, 300);
    }
}


// Types paragraph text character by character
function typeParagraph() {
    if (paraCharIndex < paragraphTexts[titleIndex].length) {

        paraElement.innerHTML += paragraphTexts[titleIndex].charAt(paraCharIndex);
        paraCharIndex++;

        setTimeout(typeParagraph, typingSpeed);

    } else {
        // Pause before starting deletion
        setTimeout(deleteText, pauseTime);
    }
}


// Deletes paragraph first, then title
function deleteText() {

    // Delete paragraph text
    if (paraCharIndex > 0) {

        paraElement.innerHTML =
            paragraphTexts[titleIndex].substring(0, paraCharIndex - 1);

        paraCharIndex--;
        setTimeout(deleteText, deletingSpeed);

    }

    // Then delete title text
    else if (charIndex > 0) {

        titleElement.innerHTML =
            titleTexts[titleIndex].substring(0, charIndex - 1);

        charIndex--;
        setTimeout(deleteText, deletingSpeed);

    }

    // Move to next title and restart typing
    else {

        titleIndex = (titleIndex + 1) % titleTexts.length;

        setTimeout(typeTitle, 300);
    }
}


// ================= INITIALIZATION =================

// Start animation after DOM is fully loaded
document.addEventListener("DOMContentLoaded", () => {
    typeTitle();
});