class Student {
    constructor(name) {
        this.name = name;
        this.marks = [];
    }

    addMark(mark) {
        if (mark >= 0 && mark <= 100) {
            this.marks.push(mark);
        } else {
            console.log("Invalid mark. Must be between 0 and 100.");
        }
    }

    getAverage() {
        let total = this.marks.reduce((sum, m) => sum + m, 0);
        return total / this.marks.length;
    }

    getGrade() {
        let avg = this.getAverage();

        if (avg >= 90) return "A";
        else if (avg >= 75) return "B";
        else if (avg >= 50) return "C";
        else return "Fail";
    }
}

let s1 = new Student("Rahul");
s1.addMark(95);
s1.addMark(80);
s1.addMark(70);

console.log("Average:", s1.getAverage());
console.log("Grade:", s1.getGrade());