// ================= COMMON UTILITY FUNCTIONS =================

// Navigates user back to the home (index) page
function goBack() {
    window.location.href = "index.html";
}


// Displays a temporary alert message at the top-center of the screen
function showAlert(msg, type = "success") {

    // Create alert div using jQuery
    let div = $("<div>")
        .addClass(
            "alert alert-" + (type === "error" ? "danger" : "success")
        )
        .css({
            position: "fixed",
            top: "20px",
            left: "50%",
            transform: "translateX(-50%)",
            zIndex: "9999",
            minWidth: "300px",
            textAlign: "center"
        })
        .text(msg);

    // Append alert to body
    $("body").append(div);

    // Automatically remove alert after 2 seconds
    setTimeout(() => {
        div.fadeOut(300, () => div.remove());
    }, 2000);
}