// ================= INITIAL DATA =================

// Load patients from localStorage
let patients = getData("patients");

// Tracks edit mode (which patient is being edited)
let editId = null;

// Flag to control view-only mode
let viewMode = false;


// Seed default data if storage is empty
if (patients.length === 0) {
    patients = [
        {
            id: 1,
            name: "John",
            age: 25,
            gender: "Male",
            phone: "9876543210",
            email: "john@gmail.com",
            notes: ""
        },
        {
            id: 2,
            name: "Sara",
            age: 30,
            gender: "Female",
            phone: "9123456780",
            email: "sara@gmail.com",
            notes: ""
        }
    ];

    setData("patients", patients);
}


// ================= FORM UTILITIES =================

// Clear all validation error messages
function clearErrors() {
    $("#nameErr,#ageErr,#genderErr,#phoneErr,#emailErr").text("");
}


// Enable / disable form fields + Save button
function toggleForm(disable) {
    $("#name,#age,#gender,#phone,#email,#notes")
        .prop("disabled", disable);

    // Disable save button in view mode
    $("#saveBtn").prop("disabled", disable);
}


// Reset form to default state
function resetForm() {
    $("input, textarea").val("");
    $("#gender").val("");

    toggleForm(false);

    viewMode = false;
    editId = null;
}


// ================= ID GENERATION =================

// Generate next unique ID
function getNextId() {
    if (patients.length === 0) return 1;

    return Math.max(...patients.map(p => p.id)) + 1;
}


// ================= VALIDATION =================

function validate() {

    // Prevent editing in view mode
    if (viewMode) return false;

    clearErrors();
    let valid = true;

    let name = $("#name").val().trim();
    let age = $("#age").val().trim();
    let gender = $("#gender").val();
    let phone = $("#phone").val().trim();
    let email = $("#email").val().trim();

    // Name validation
    if (name === "") {
        $("#nameErr").text("Name required");
        valid = false;
    }

    // Age validation
    if (age === "" || isNaN(age)) {
        $("#ageErr").text("Valid age required");
        valid = false;
    }

    // Gender validation
    if (gender === "") {
        $("#genderErr").text("Select gender");
        valid = false;
    }

    // Phone validation
    if (!/^\d{10}$/.test(phone)) {
        $("#phoneErr").text("Enter 10 digit phone");
        valid = false;
    }

    // Email validation
    if (!email.includes("@")) {
        $("#emailErr").text("Invalid email");
        valid = false;
    }

    // Duplicate phone check
    if (patients.some(p => p.phone === phone && p.id !== editId)) {
        $("#phoneErr").text("Phone already exists");
        valid = false;
    }

    // Duplicate email check
    if (patients.some(p => p.email === email && p.id !== editId)) {
        $("#emailErr").text("Email already exists");
        valid = false;
    }

    return valid;
}


// ================= ADD / UPDATE =================

function addPatient() {

    // Prevent action in view mode
    if (viewMode) {
        showAlert("View mode enabled", "error");
        return;
    }

    // Validate before proceeding
    if (!validate()) return;

    // Update existing patient
    if (editId !== null) {

        let p = patients.find(x => x.id === editId);

        p.name = $("#name").val();
        p.age = $("#age").val();
        p.gender = $("#gender").val();
        p.phone = $("#phone").val();
        p.email = $("#email").val();
        p.notes = $("#notes").val();

        editId = null;

        showAlert("Patient Updated Successfully");

    } else {

        // Add new patient
        let patient = {
            id: getNextId(),
            name: $("#name").val(),
            age: $("#age").val(),
            gender: $("#gender").val(),
            phone: $("#phone").val(),
            email: $("#email").val(),
            notes: $("#notes").val()
        };

        patients.push(patient);

        showAlert("Patient Added Successfully");
    }

    // Save and refresh UI
    setData("patients", patients);
    renderPatients();
    resetForm();
}


// ================= CRUD OPERATIONS =================

// Edit patient
function editPatient(id) {

    let p = patients.find(x => x.id === id);

    toggleForm(false);

    $("#name").val(p.name);
    $("#age").val(p.age);
    $("#gender").val(p.gender);
    $("#phone").val(p.phone);
    $("#email").val(p.email);
    $("#notes").val(p.notes);

    editId = id;
    viewMode = false;

    showAlert("Editing Mode Enabled");
}


// View patient (read-only)
function viewPatient(id) {

    let p = patients.find(x => x.id === id);

    $("#name").val(p.name);
    $("#age").val(p.age);
    $("#gender").val(p.gender);
    $("#phone").val(p.phone);
    $("#email").val(p.email);
    $("#notes").val(p.notes);

    toggleForm(true);
    viewMode = true;

    showAlert("Viewing Details");
}


// Delete patient (UPDATED)
function deletePatient(id) {

    if (!confirm("Are you sure you want to delete this patient?")) return;

    patients = patients.filter(p => p.id !== id);

    setData("patients", patients);
    renderPatients();

    showAlert("Deleted Successfully");
}


// ================= RENDERING =================

// Render full patient list
function renderPatients() {

    let html = "";

    patients.forEach(p => {
        html += `
        <tr>
            <td>${p.id}</td>
            <td>${p.name}</td>
            <td>${p.phone}</td>
            <td>${p.email}</td>
            <td>
                <button class="btn btn-info btn-sm me-1" onclick="viewPatient(${p.id})">Details</button>
                <button class="btn btn-warning btn-sm me-1" onclick="editPatient(${p.id})">Edit</button>
                <button class="btn btn-danger btn-sm" onclick="deletePatient(${p.id})">Delete</button>
            </td>
        </tr>`;
    });

    $("#tbl").html(html);
}


// Render filtered list (used in search)
function renderFilteredPatients(list) {

    let html = "";

    list.forEach(p => {
        html += `
        <tr>
            <td>${p.id}</td>
            <td>${p.name}</td>
            <td>${p.phone}</td>
            <td>${p.email}</td>
            <td>
                <button class="btn btn-info btn-sm me-1" onclick="viewPatient(${p.id})">Details</button>
                <button class="btn btn-warning btn-sm me-1" onclick="editPatient(${p.id})">Edit</button>
                <button class="btn btn-danger btn-sm" onclick="deletePatient(${p.id})">Delete</button>
            </td>
        </tr>`;
    });

    $("#tbl").html(html);
}


// ================= SEARCH =================

// Search on Enter key press
$("#patientSearch").keypress(function (e) {

    if (e.which === 13) {

        let key = $(this).val().toLowerCase().trim();

        // If empty → show all
        if (key === "") {
            renderPatients();
            return;
        }

        // Filter logic
        let filtered = patients.filter(p =>
            p.name.toLowerCase().includes(key) ||
            p.phone.includes(key) ||
            p.email.toLowerCase().includes(key)
        );

        if (filtered.length === 0) {
            showAlert("No patient found", "error");
        }

        renderFilteredPatients(filtered);

        // Clear search input
        $(this).val("");
    }
});


// ================= UI EVENTS =================

// Reset table when clicking "View Patients"
$('a[href="#patientList"]').click(function () {
    renderPatients();
});


// ================= INITIAL LOAD =================
renderPatients();