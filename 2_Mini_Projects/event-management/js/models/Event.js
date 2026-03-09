export default class Event{

constructor(id,title,description,date,location,capacity,availableSeats){

this.id=id
this.title=title
this.description=description
this.date=date
this.location=location
this.capacity=capacity
this.availableSeats=availableSeats

}

validate(){

if(!this.title) throw "Title required"

if(!this.location) throw "Location required"

if(this.capacity<=0) throw "Capacity must be positive"

let today=new Date().toISOString().split("T")[0]

if(this.date<today)
throw "Date cannot be past date"

}

checkSeatAvailability(){

return this.availableSeats>0

}

}