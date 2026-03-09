import {eventService} from "../services/eventService.js"

export async function loadEvents(){

try{

let events=await eventService.getEvents()

let container=document.getElementById("events")

container.innerHTML=events.map(e=>`

<div class="card">

<h3>${e.title}</h3>

<p>${e.description}</p>

<p>Date: ${e.date}</p>

<p>Location: ${e.location}</p>

<p>Seats Left: ${e.availableSeats}</p>

<a href="register.html?eventId=${e.id}">Register</a>

</div>

`).join("")

}

catch(err){

alert(err)

}

}



export function addEventController(){

document.getElementById("eventForm")
.addEventListener("submit",async(e)=>{

e.preventDefault()

let event={

title:document.getElementById("title").value,
location:document.getElementById("location").value,
date:document.getElementById("date").value,
capacity:Number(document.getElementById("capacity").value),
availableSeats:Number(document.getElementById("capacity").value)

}

await eventService.addEvent(event)

alert("Event added")

})

}