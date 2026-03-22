export default class Event {
    constructor(title, date, location, capacity) {
        this.title = title;
        this.date = date;
        this.location = location;
        this.capacity = capacity;
    }

    isValid() {
        return this.title && this.date && this.location && this.capacity > 0;
    }
}