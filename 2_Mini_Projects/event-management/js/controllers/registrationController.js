import {registrationService} from "../services/registrationService.js"
import {eventService} from "../services/eventService.js"

export function registerController(){

document.getElementById("registerForm")
.addEventListener("submit",async(e)=>{

e.preventDefault()

let params=new URLSearchParams(window.location.search)

let eventId=params.get("eventId")

let name=document.getElementById("name").value
let email=document.getElementById("email").value
let phone=document.getElementById("phone").value


await registrationService.register({

eventId:Number(eventId),
participantName:name,
email,
phone

})

let events=await eventService.getEvents()

let event=events.find(e=>e.id==eventId)

event.availableSeats--

await eventService.updateEvent(eventId,event)

alert("Registration successful")

})

}