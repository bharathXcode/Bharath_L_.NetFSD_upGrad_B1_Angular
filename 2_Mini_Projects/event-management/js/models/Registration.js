export default class Registration{

constructor(id,eventId,name,email,phone){

this.id=id
this.eventId=eventId
this.name=name
this.email=email
this.phone=phone

}

validate(){

if(!this.name)
throw "Name required"

let emailPattern=/^[^ ]+@[^ ]+\.[a-z]{2,3}$/

if(!emailPattern.test(this.email))
throw "Invalid email"

let phonePattern=/^[0-9]{10}$/

if(!phonePattern.test(this.phone))
throw "Phone must be 10 digits"

}

}