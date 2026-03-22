// ================= STATE =================

// Tracks current doctor being edited
let editId = null;


// ================= DATA UTILITIES =================

// Fetch doctors from localStorage
function getDoctors() {
    let data = getData("doctors");
    return Array.isArray(data) ? data : [];
}

// Save doctors to localStorage
function saveDoctors(data) {
    setData("doctors", data);
}


// ================= INITIAL LOAD =================

// Load doctors data
let doctors = getDoctors();

// Seed default data if empty
if (doctors.length === 0) {
    doctors = [
        { id: 1, name: "Dr.Raj", spec: "Cardio", date: "2026-03-20", start: "09:00", end: "12:00" },
        { id: 2, name: "Dr.Anna", spec: "Neuro", date: "2026-03-21", start: "14:00", end: "17:00" }
    ];

    saveDoctors(doctors);
}


// Fix older data (ensure start and end exist)
doctors = doctors.map(d => {
    if (!d.start || !d.end) {
        return {
            ...d,
            start: "09:00",
            end: "10:00"
        };
    }
    return d;
});

saveDoctors(doctors);


// ================= STATIC DATA =================

// Predefined specializations
let specs = ["Cardio", "Neuro", "Dermatology"];


// ================= LOAD FUNCTIONS =================

// Load specialization dropdown
function loadSpecs() {
    $("#specDropdown").html(`<option value="">Select</option>`);

    specs.forEach(s => {
        $("#specDropdown").append(`<option>${s}</option>`);
    });
}


// Load time dropdowns (hours + minutes)
function loadTime() {

    // Hours (1–12)
    for (let i = 1; i <= 12; i++) {
        $("#startHour,#endHour").append(`<option value="${i}">${i}</option>`);
    }

    // Minutes (00–59)
    for (let i = 0; i <= 59; i++) {
        let m = i.toString().padStart(2, "0");
        $("#startMin,#endMin").append(`<option value="${m}">${m}</option>`);
    }
}


// ================= ID GENERATION =================

function getNextId() {
    let docs = getDoctors();
    return docs.length
        ? Math.max(...docs.map(d => d.id)) + 1
        : 1;
}


// ================= TIME UTILITIES =================

// Convert 12-hour format to 24-hour format
function to24(h, m, a) {

    h = parseInt(h);

    if (a === "PM" && h !== 12) h += 12;
    if (a === "AM" && h === 12) h = 0;

    return `${h.toString().padStart(2, "0")}:${m}`;
}


// Convert 24-hour format to display format
function format(t) {

    if (!t) return "--";

    let [h, m] = t.split(":");
    let hr = parseInt(h);

    let ap = hr >= 12 ? "PM" : "AM";
    hr = hr % 12 || 12;

    return `${hr}:${m} ${ap}`;
}


// ================= ADD / UPDATE =================

function addDoctor() {

    let doctors = getDoctors();

    let name = $("#name").val().trim();
    let spec = $("#specInput").val().trim() || $("#specDropdown").val();
    let date = $("#date").val();

    let sh = $("#startHour").val();
    let sm = $("#startMin").val();
    let sa = $("#startAmpm").val();

    let eh = $("#endHour").val();
    let em = $("#endMin").val();
    let ea = $("#endAmpm").val();

    // Basic validation
    if (!name || !spec || !date || !sh || !eh) {
        return showAlert("All fields required", "error");
    }

    let start = to24(sh, sm, sa);
    let end = to24(eh, em, ea);

    // Ensure minimum 1 hour slot
    let diff = (new Date(`2000 ${end}`) - new Date(`2000 ${start}`)) / 3600000;

    if (diff < 1) {
        return showAlert("Minimum 1 hour slot required", "error");
    }

    // Update existing doctor
    if (editId !== null) {

        let d = doctors.find(x => x.id === editId);

        d.name = name;
        d.spec = spec;
        d.date = date;
        d.start = start;
        d.end = end;

        editId = null;

        showAlert("Doctor Updated");

    } else {

        // Add new doctor
        doctors.push({
            id: getNextId(),
            name,
            spec,
            date,
            start,
            end
        });

        showAlert("Doctor Added");
    }

    saveDoctors(doctors);
    renderDoctors();

    // Reset form
    $("input").val("");
    $("#specDropdown").val("");
}


// ================= CRUD =================

// Edit doctor
function editDoctor(id) {

    let doctors = getDoctors();
    let d = doctors.find(x => x.id === id);

    $("#name").val(d.name);
    $("#date").val(d.date);

    setTime(d.start, "start");
    setTime(d.end, "end");

    // Handle specialization source
    if (specs.includes(d.spec)) {
        $("#specDropdown").val(d.spec);
        $("#specInput").val("");
    } else {
        $("#specInput").val(d.spec);
    }

    editId = id;
}


// Set time fields from stored value
function setTime(t, p) {

    if (!t) return;

    let [h, m] = t.split(":");
    let hr = parseInt(h);

    let ap = hr >= 12 ? "PM" : "AM";
    hr = hr % 12 || 12;

    $(`#${p}Hour`).val(hr);
    $(`#${p}Min`).val(m);
    $(`#${p}Ampm`).val(ap);
}


// Delete doctor
function deleteDoctor(id){

    if(!confirm("Are you sure you want to delete this doctor?")) return;

    let doctors = getDoctors();
    doctors = doctors.filter(d => d.id !== id);

    saveDoctors(doctors);
    renderDoctors();

    showAlert("Deleted Successfully");
}


// ================= RENDER =================

// Render all doctors
function renderDoctors() {

    let doctors = getDoctors();

    let html = "";

    doctors.forEach(d => {
        html += `
        <tr>
            <td>${d.id}</td>
            <td>${d.name}</td>
            <td>${d.spec || "--"}</td>
            <td>${d.date || "--"}</td>
            <td>${format(d.start)} - ${format(d.end)}</td>
            <td>
                <button class="btn btn-warning btn-sm me-1" onclick="editDoctor(${d.id})">Edit</button>
                <button class="btn btn-danger btn-sm" onclick="deleteDoctor(${d.id})">Delete</button>
            </td>
        </tr>`;
    });

    $("#tbl").html(html);
}


// Render filtered doctors (search)
function renderFilteredDoctors(list) {

    let html = "";

    list.forEach(d => {
        html += `
        <tr>
            <td>${d.id}</td>
            <td>${d.name}</td>
            <td>${d.spec || "--"}</td>
            <td>${d.date || "--"}</td>
            <td>${format(d.start)} - ${format(d.end)}</td>
            <td>
                <button class="btn btn-warning btn-sm me-1" onclick="editDoctor(${d.id})">Edit</button>
                <button class="btn btn-danger btn-sm" onclick="deleteDoctor(${d.id})">Delete</button>
            </td>
        </tr>`;
    });

    $("#tbl").html(html);
}


// ================= SEARCH =================

$("#doctorSearch").keypress(function (e) {

    if (e.which === 13) {

        let key = $(this).val().toLowerCase().trim();

        if (key === "") {
            renderDoctors();
            return;
        }

        let doctors = getDoctors();

        let filtered = doctors.filter(d =>
            d.name.toLowerCase().includes(key)
        );

        if (filtered.length === 0) {
            showAlert("No doctor found", "error");
        }

        renderFilteredDoctors(filtered);

        $(this).val("");
    }
});


// ================= UI EVENTS =================

// Reset view when clicking "View Doctors"
$('a[href="#doctorList"]').click(function () {
    renderDoctors();
});


// ================= INITIALIZATION =================

$(document).ready(function () {
    loadSpecs();
    loadTime();
    renderDoctors();
});