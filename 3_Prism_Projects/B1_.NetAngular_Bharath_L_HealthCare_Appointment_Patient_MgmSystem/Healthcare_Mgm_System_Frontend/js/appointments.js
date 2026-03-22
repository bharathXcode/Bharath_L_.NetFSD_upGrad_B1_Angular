// ================= INITIAL STATE =================

// Load appointments from localStorage
let appointments = getData("appointments") || [];

// Tracks edit mode
let editId = null;


// ================= ID NORMALIZATION =================

// Ensures IDs are always sequential (1,2,3...)
function normalizeIds() {

    appointments.sort((a, b) => a.id - b.id);

    appointments.forEach((a, index) => {
        a.id = index + 1;
    });

    setData("appointments", appointments);
}


// ================= DEFAULT DATA =================

if (appointments.length === 0) {
    appointments = [
        {
            id: 1,
            patient: "John",
            doctor: "Dr.Raj",
            date: "2026-03-20",
            time: "10:00",
            status: "Pending"
        }
    ];

    setData("appointments", appointments);
}


// ================= LOAD PATIENTS =================

// Populate patient dropdown
function loadPatients() {

    let patients = getData("patients");

    $("#patient").html(`<option value="">Select Patient</option>`);

    patients.forEach(p => {
        $("#patient").append(`
            <option value="${p.name}">
                ${p.id} | ${p.name} | ${p.phone} | ${p.email}
            </option>
        `);
    });
}


// ================= SEARCH (PATIENT + DOCTOR) =================

$("#patientSearch").keypress(function (e) {

    if (e.which === 13) {

        let key = $(this).val().toLowerCase().trim();

        let patients = getData("patients");
        let doctors = getData("doctors");

        // Patient search
        let patientMatch = patients.find(p =>
            p.name.toLowerCase().includes(key) ||
            p.phone.includes(key) ||
            p.email.toLowerCase().includes(key)
        );

        if (patientMatch) {
            $("#patient").val(patientMatch.name);
            showAlert("Patient Selected");
            $(this).val("");
            return;
        }

        // Doctor search
        let doctorMatch = doctors.find(d =>
            d.name.toLowerCase().includes(key)
        );

        if (doctorMatch) {

            // Auto-fill date
            $("#date").val(doctorMatch.date);

            loadDoctors();

            // Select doctor and load slots
            setTimeout(() => {
                $("#doctor").val(doctorMatch.id);
                loadSlots();
            }, 100);

            showAlert("Doctor Selected with available slots");
            $(this).val("");
            return;
        }

        // Not found
        showAlert("No patient or doctor found", "error");
        $(this).val("");
    }
});


// ================= LOAD DOCTORS =================

// Load doctors based on selected date
function loadDoctors() {

    let date = $("#date").val();
    let doctors = getData("doctors");

    $("#doctor").prop("disabled", false);
    $("#doctor").html(`<option value="">Select Doctor</option>`);

    let filtered = doctors.filter(d => d.date === date);

    if (filtered.length === 0) {
        $("#doctor").html(`<option>No doctors available</option>`);
        return;
    }

    filtered.forEach(d => {
        $("#doctor").append(`<option value="${d.id}">${d.name}</option>`);
    });
}


// ================= LOAD TIME SLOTS =================

// Generate available slots based on doctor schedule
function loadSlots() {

    let doctorId = $("#doctor").val();
    let date = $("#date").val();

    let doctors = getData("doctors");
    let d = doctors.find(x => x.id == doctorId);

    $("#slot").prop("disabled", false);
    $("#slot").empty();

    if (!d) return;

    let start = new Date(`2000 ${d.start}`);
    let end = new Date(`2000 ${d.end}`);

    // Generate hourly slots
    while (start < end) {

        let time = start.toTimeString().slice(0, 5);

        // Check if slot already booked
        let booked = appointments.some(a =>
            a.doctor === d.name &&
            a.date === date &&
            a.time === time &&
            a.id !== editId // allow same slot in edit
        );

        if (!booked) {
            $("#slot").append(`<option>${time}</option>`);
        }

        start.setHours(start.getHours() + 1);
    }
}


// ================= STATUS LOGIC =================

// Determine appointment status dynamically
function getStatus(date, time, currentStatus) {

    // Preserve manual statuses
    if (currentStatus === "Completed" || currentStatus === "Cancelled") {
        return currentStatus;
    }

    let now = new Date();
    let appointmentTime = new Date(`${date}T${time}`);

    if (appointmentTime > now) return "Pending";

    return "Booked";
}


// ================= BOOK / UPDATE =================

function book() {

    let patient = $("#patient").val();
    let doctorId = $("#doctor").val();
    let date = $("#date").val();
    let time = $("#slot").val();

    let doctors = getData("doctors");
    let doctor = doctors.find(d => d.id == doctorId)?.name;

    // Validation
    if (!patient || !doctor || !date || !time) {
        return showAlert("Fill all fields", "error");
    }

    // Edit existing appointment
    if (editId) {

        let a = appointments.find(x => x.id === editId);

        a.patient = patient;
        a.doctor = doctor;
        a.date = date;
        a.time = time;

        editId = null;

        showAlert("Appointment Updated");

    } else {

        // Sequential ID generation
        let newId = appointments.length + 1;

        if (newId > 100) {
            return showAlert("Max 100 appointments allowed", "error");
        }

        appointments.push({
            id: newId,
            patient,
            doctor,
            date,
            time,
            status: "Pending"
        });

        showAlert("Appointment Booked");
    }

    setData("appointments", appointments);
    renderAppointments();
    loadSlots();
}


// ================= CRUD =================

// Edit appointment
function editAppointment(id) {

    let a = appointments.find(x => x.id === id);

    editId = id;

    $("#patient").val(a.patient);
    $("#date").val(a.date);

    loadDoctors();

    setTimeout(() => {

        let doctors = getData("doctors");
        let d = doctors.find(x => x.name === a.doctor);

        $("#doctor").val(d?.id);

        loadSlots();

        setTimeout(() => {
            $("#slot").val(a.time);
        }, 100);

    }, 100);

    showAlert("Edit mode enabled");
}


// Delete appointment
function deleteAppointment(id){

    if(!confirm("Are you sure you want to delete this appointment?")) return;

    appointments = appointments.filter(a => a.id !== id);

    normalizeIds();

    setData("appointments", appointments);
    renderAppointments();

    showAlert("Appointment Deleted");
}


// Update status manually
function updateStatus(id, status) {

    let a = appointments.find(x => x.id === id);

    a.status = status;

    setData("appointments", appointments);
    renderAppointments();
}


// ================= RENDER =================

// Render appointment table
function renderAppointments() {

    let filter = $("#filter").val();
    let html = "";

    appointments.forEach(a => {

        let status = getStatus(a.date, a.time, a.status);

        // Apply filter
        if (filter && status !== filter) return;

        let badge =
            status === "Pending" ? "warning" :
            status === "Booked" ? "success" :
            status === "Completed" ? "primary" :
            "danger";

        html += `
        <tr>
            <td>${a.id}</td>
            <td>${a.patient}</td>
            <td>${a.doctor}</td>
            <td>${a.date}</td>
            <td>${a.time}</td>
            <td><span class="badge bg-${badge}">${status}</span></td>
            <td>
                <button class="btn btn-sm btn-warning" onclick="editAppointment(${a.id})">Edit</button>
                <button class="btn btn-sm btn-danger" onclick="deleteAppointment(${a.id})">Delete</button>
                <button class="btn btn-sm btn-success" onclick="updateStatus(${a.id},'Completed')">Done</button>
                <button class="btn btn-sm btn-danger" onclick="updateStatus(${a.id},'Cancelled')">Cancel</button>
            </td>
        </tr>`;
    });

    $("#tbl").html(html);
}


// ================= EVENTS =================

// Reload doctors when date changes
$("#date").change(function () {
    loadDoctors();
    $("#slot").prop("disabled", true);
});

// Load slots when doctor changes
$("#doctor").change(loadSlots);


// ================= INITIALIZATION =================

$(document).ready(function () {

    normalizeIds(); // Fix old IDs

    loadPatients();
    renderAppointments();
});