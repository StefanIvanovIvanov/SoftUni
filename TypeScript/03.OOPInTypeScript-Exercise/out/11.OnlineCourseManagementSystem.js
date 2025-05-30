"use strict";
class Course {
    title;
    duration;
    constructor(title, duration) {
        this.title = title;
        this.duration = duration;
    }
}
class ProgrammingCourse extends Course {
    language;
    constructor(title, duration, language) {
        super(title, duration);
        this.language = language;
    }
    getDescription() {
        return `Programming Course: ${this.title} in ${this.language} - ${this.duration} hours`;
    }
}
class DesignCourse extends Course {
    tools;
    constructor(title, duration, tools) {
        super(title, duration);
        this.tools = tools;
    }
    getDescription() {
        return `Design Course: ${this.title} using ${this.tools.join(', ')} - ${this.duration} hours`;
    }
}
const jsCourse = new ProgrammingCourse("Intro to JavaScript", 40, "JavaScript");
const uiCourse = new DesignCourse("UX Fundamentals", 30, ["Figma", "Sketch"]);
console.log(jsCourse.getDescription());
console.log(uiCourse.getDescription());
//# sourceMappingURL=11.OnlineCourseManagementSystem.js.map