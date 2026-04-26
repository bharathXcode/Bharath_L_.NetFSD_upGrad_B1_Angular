class Student {
    rollNo: number;
    studName: string;
    marksInEng: number;
    marksInMaths: number;
    marksInScience: number;

    constructor(rollNo: number, name: string, eng: number, maths: number, science: number) {
        this.rollNo = rollNo;
        this.studName = name;
        this.marksInEng = eng;
        this.marksInMaths = maths;
        this.marksInScience = science;
    }

    calculateResults(): void {
        const total = this.marksInEng + this.marksInMaths + this.marksInScience;
        const percentage = total / 3;

        console.log("Student Name:", this.studName);
        console.log("Total Marks:", total);
        console.log("Percentage:", percentage.toFixed(2) + "%");
    }
}

// Usage
const student = new Student(1, "Bharath", 85, 90, 88);
student.calculateResults();