import {api} from "../utils/api.js"

export const registrationService={

getRegistrations: async()=>{

return await api.get("registrations")

},

register: async(data)=>{

return await api.post("registrations",data)

}

}