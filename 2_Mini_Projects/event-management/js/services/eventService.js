import {api} from "../utils/api.js"

export const eventService={

getEvents: async()=>{

return await api.get("events")

},

addEvent: async(event)=>{

return await api.post("events",event)

},

updateEvent: async(id,event)=>{

return await api.put(`events/${id}`,event)

},

deleteEvent: async(id)=>{

return await api.delete(`events/${id}`)

}

}